using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utility;

namespace FineUI.Examples
{
    public partial class _default : PageBase
    {
        #region Page_Init

        protected void Page_Init(object sender, EventArgs e)
        {
            string menuType = "menu";
            HttpCookie menuCookie = Request.Cookies["Menu"];
            if (menuCookie != null)
            {
                menuType = menuCookie.Value;
            }

            // 注册客户端脚本，服务器端控件ID和客户端ID的映射关系
            JObject ids = GetClientIDS(btnExpandAll, btnCollapseAll, windowSourceCode, mainTabStrip);
            Accordion accordionMenu = InitAccordionMenu();
            ids.Add("mainMenu", accordionMenu.ClientID);
            ids.Add("menuType", "accordion");

            string idsScriptStr = String.Format("window.IDS={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
            PageContext.RegisterStartupScript(idsScriptStr);
        }

        private Accordion InitAccordionMenu()
        {
            Accordion accordionMenu = new Accordion();
            accordionMenu.ID = "accordionMenu";
            accordionMenu.EnableFill = true;
            accordionMenu.ShowBorder = false;
            accordionMenu.ShowHeader = false;
            Region2.Items.Add(accordionMenu);


            XmlDocument xmlDoc = XmlDataSource1.GetXmlDocument();
            XmlNodeList xmlNodes = xmlDoc.SelectNodes("/Tree/TreeNode");
            foreach (XmlNode xmlNode in xmlNodes)
            {
                if (xmlNode.HasChildNodes)
                {
                    AccordionPane accordionPane = new AccordionPane();
                    accordionPane.Title = xmlNode.Attributes["Text"].Value;
                    accordionPane.Layout = Layout.Fit;
                    accordionPane.ShowBorder = false;
                    accordionPane.BodyPadding = "2px 0 0 0";
                    accordionMenu.Items.Add(accordionPane);

                    Tree innerTree = new Tree();
                    innerTree.EnableArrows = true;
                    innerTree.ShowBorder = false;
                    innerTree.ShowHeader = false;
                    innerTree.EnableIcons = false;
                    innerTree.AutoScroll = true;
                    accordionPane.Items.Add(innerTree);

                    XmlDocument innerXmlDoc = new XmlDocument();
                    innerXmlDoc.LoadXml(String.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?><Tree>{0}</Tree>", xmlNode.InnerXml));

                    // 绑定AccordionPane内部的树控件
                    innerTree.DataSource = innerXmlDoc;
                    innerTree.DataBind();

                    // 重新设置每个节点的图标
                    ResolveTreeNode(innerTree.Nodes);
                }
            }

            return accordionMenu;
        }

        private Tree InitTreeMenu()
        {
            Tree treeMenu = new Tree();
            treeMenu.ID = "treeMenu";
            treeMenu.EnableArrows = true;
            treeMenu.ShowBorder = false;
            treeMenu.ShowHeader = false;
            treeMenu.EnableIcons = false;
            treeMenu.AutoScroll = true;
            Region2.Items.Add(treeMenu);

            // 绑定 XML 数据源到树控件
            treeMenu.DataSource = XmlDataSource1;
            treeMenu.DataBind();

            // 重新设置每个节点的图标
            ResolveTreeNode(treeMenu.Nodes);

            return treeMenu;
        }


        private JObject GetClientIDS(params ControlBase[] ctrls)
        {
            JObject jo = new JObject();
            foreach (ControlBase ctrl in ctrls)
            {
                jo.Add(ctrl.ID, ctrl.ClientID);
            }

            return jo;
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserID"] == null)
                {
                    Response.Write("<script type='text/javascript'>window.parent.location='login.aspx'</script>");
                    return;
                }
            }
        }

        #endregion

        #region Tree

        /// <summary>
        /// 重新设置每个节点的图标
        /// </summary>
        /// <param name="nodes"></param>
        private void ResolveTreeNode(FineUI.TreeNodeCollection nodes)
        {
            foreach (FineUI.TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    if (!String.IsNullOrEmpty(node.NavigateUrl))
                    {
                        node.IconUrl = GetIconForTreeNode(node.NavigateUrl);
                    }
                }
                else
                {
                    ResolveTreeNode(node.Nodes);
                }
            }
        }

        /// <summary>
        /// 根据链接地址返回相应的图标
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetIconForTreeNode(string url)
        {
            string iconUrl = "images/filetype/vs_unknow.png";
            url = url.ToLower();
            int lastDotIndex = url.LastIndexOf('.');
            string fileType = url.Substring(lastDotIndex + 1);
            if (fileType == "txt")
            {
                iconUrl = "images/filetype/vs_txt.png";
            }
            else if (fileType == "aspx")
            {
                iconUrl = "images/filetype/vs_aspx.png";
            }
            else if (fileType == "htm" || fileType == "html")
            {
                iconUrl = "images/filetype/vs_htm.png";
            }

            return iconUrl;
        }

        #endregion
    }
}
