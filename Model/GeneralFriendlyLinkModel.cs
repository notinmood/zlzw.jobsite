using System;
namespace zlzw.Model
{
    /// <summary>
    /// GeneralFriendlyLinkModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class GeneralFriendlyLinkModel
    {
        public GeneralFriendlyLinkModel()
        { }
        #region Model
        private int _linkid;
        private Guid _linkguid;
        private int? _linktype;
        private string _linkcategory;
        private string _linktitle;
        private string _linktargeturl;
        private string _linkimagekey;
        private string _linkimagepath;
        private DateTime? _publishdate;
        private string _linkdesc;
        private int? _canusable;
        private int? _linkordernumber;
        private string _propertynames;
        private string _propertyvalues;
        /// <summary>
        /// 
        /// </summary>
        public int LinkID
        {
            set { _linkid = value; }
            get { return _linkid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid LinkGuid
        {
            set { _linkguid = value; }
            get { return _linkguid; }
        }
        /// <summary>
        /// 链接类型 是否为图片链接 0:文字 1：图片
        /// </summary>
        public int? LinkType
        {
            set { _linktype = value; }
            get { return _linktype; }
        }
        /// <summary>
        /// 友情链接分类（业务、公司性质）
        /// </summary>
        public string LinkCategory
        {
            set { _linkcategory = value; }
            get { return _linkcategory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkTitle
        {
            set { _linktitle = value; }
            get { return _linktitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkTargetUrl
        {
            set { _linktargeturl = value; }
            get { return _linktargeturl; }
        }
        /// <summary>
        /// GeneralImage表GUID关联
        /// </summary>
        public string LinkImageKey
        {
            set { _linkimagekey = value; }
            get { return _linkimagekey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkImagePath
        {
            set { _linkimagepath = value; }
            get { return _linkimagepath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PublishDate
        {
            set { _publishdate = value; }
            get { return _publishdate; }
        }
        /// <summary>
        /// 链接描述
        /// </summary>
        public string LinkDesc
        {
            set { _linkdesc = value; }
            get { return _linkdesc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CanUsable
        {
            set { _canusable = value; }
            get { return _canusable; }
        }
        /// <summary>
        /// 排序字段
        /// </summary>
        public int? LinkOrderNumber
        {
            set { _linkordernumber = value; }
            get { return _linkordernumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PropertyNames
        {
            set { _propertynames = value; }
            get { return _propertynames; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PropertyValues
        {
            set { _propertyvalues = value; }
            get { return _propertyvalues; }
        }
        #endregion Model

    }
}