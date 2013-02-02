using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
    /// <summary>
    /// 数据访问类:NavigateListDAL
    /// </summary>
    public partial class NavigateListDAL
    {
        public NavigateListDAL()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int NavigateID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@NavigateID", SqlDbType.Int,4)
			};
            parameters[0].Value = NavigateID;

            int result = DbHelperSQL.RunProcedure("NavigateList_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(zlzw.Model.NavigateListModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@NavigateID", SqlDbType.Int,4),
					new SqlParameter("@NavigateGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@NavigateName", SqlDbType.NVarChar,50),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@IsEnable", SqlDbType.Int,4),
					new SqlParameter("@OrderNumber", SqlDbType.Int,4),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@Other01", SqlDbType.NVarChar,50),
					new SqlParameter("@Other02", SqlDbType.NVarChar,50)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = model.NavigateName;
            parameters[3].Value = model.IsShow;
            parameters[4].Value = model.IsEnable;
            parameters[5].Value = model.OrderNumber;
            parameters[6].Value = model.PublishDate;
            parameters[7].Value = model.Other01;
            parameters[8].Value = model.Other02;

            DbHelperSQL.RunProcedure("NavigateList_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(zlzw.Model.NavigateListModel model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@NavigateID", SqlDbType.Int,4),
					new SqlParameter("@NavigateGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@NavigateName", SqlDbType.NVarChar,50),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@IsEnable", SqlDbType.Int,4),
					new SqlParameter("@OrderNumber", SqlDbType.Int,4),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@Other01", SqlDbType.NVarChar,50),
					new SqlParameter("@Other02", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.NavigateID;
            parameters[1].Value = model.NavigateGUID;
            parameters[2].Value = model.NavigateName;
            parameters[3].Value = model.IsShow;
            parameters[4].Value = model.IsEnable;
            parameters[5].Value = model.OrderNumber;
            parameters[6].Value = model.PublishDate;
            parameters[7].Value = model.Other01;
            parameters[8].Value = model.Other02;

            DbHelperSQL.RunProcedure("NavigateList_Update", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int NavigateID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@NavigateID", SqlDbType.Int,4)
			};
            parameters[0].Value = NavigateID;

            DbHelperSQL.RunProcedure("NavigateList_Delete", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string NavigateIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NavigateList ");
            strSql.Append(" where NavigateID in (" + NavigateIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public zlzw.Model.NavigateListModel GetModel(int NavigateID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@NavigateID", SqlDbType.Int,4)
			};
            parameters[0].Value = NavigateID;

            zlzw.Model.NavigateListModel model = new zlzw.Model.NavigateListModel();
            DataSet ds = DbHelperSQL.RunProcedure("NavigateList_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public zlzw.Model.NavigateListModel DataRowToModel(DataRow row)
        {
            zlzw.Model.NavigateListModel model = new zlzw.Model.NavigateListModel();
            if (row != null)
            {
                if (row["NavigateID"] != null && row["NavigateID"].ToString() != "")
                {
                    model.NavigateID = int.Parse(row["NavigateID"].ToString());
                }
                if (row["NavigateGUID"] != null && row["NavigateGUID"].ToString() != "")
                {
                    model.NavigateGUID = new Guid(row["NavigateGUID"].ToString());
                }
                if (row["NavigateName"] != null)
                {
                    model.NavigateName = row["NavigateName"].ToString();
                }
                if (row["IsShow"] != null && row["IsShow"].ToString() != "")
                {
                    model.IsShow = int.Parse(row["IsShow"].ToString());
                }
                if (row["IsEnable"] != null && row["IsEnable"].ToString() != "")
                {
                    model.IsEnable = int.Parse(row["IsEnable"].ToString());
                }
                if (row["OrderNumber"] != null && row["OrderNumber"].ToString() != "")
                {
                    model.OrderNumber = int.Parse(row["OrderNumber"].ToString());
                }
                if (row["PublishDate"] != null && row["PublishDate"].ToString() != "")
                {
                    model.PublishDate = DateTime.Parse(row["PublishDate"].ToString());
                }
                if (row["Other01"] != null)
                {
                    model.Other01 = row["Other01"].ToString();
                }
                if (row["Other02"] != null)
                {
                    model.Other02 = row["Other02"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NavigateID,NavigateGUID,NavigateName,IsShow,IsEnable,OrderNumber,PublishDate,Other01,Other02 ");
            strSql.Append(" FROM NavigateList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" NavigateID,NavigateGUID,NavigateName,IsShow,IsEnable,OrderNumber,PublishDate,Other01,Other02 ");
            strSql.Append(" FROM NavigateList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM NavigateList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.NavigateID desc");
            }
            strSql.Append(")AS Row, T.*  from NavigateList T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "NavigateList";
            parameters[1].Value = "NavigateID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method

        #region  MethodEx
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageSize">每页显示的行数</param>
        /// <param name="PageIndex">当前页数</param>
        /// <param name="strColumnsm">需要显示的列名</param>
        /// <param name="strOrderColumn">需要排序的列</param>
        /// <param name="nIsCount">是否返回记录总数</param>
        /// <param name="strOrderType">排序类型desc & asc</param>
        /// <returns></returns>
        public DataSet GetList(int PageSize, int PageIndex, string strColumns, string strOrderColumn, int nIsCount, string strOrderType, string strWhere)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),//表名
					new SqlParameter("@RetColumns", SqlDbType.VarChar, 1000),//需要显示的列名
					new SqlParameter("@Orderfld", SqlDbType.VarChar,255),//需要排序的字段名
					new SqlParameter("@PageSize", SqlDbType.Int),//总每页显示的行数
					new SqlParameter("@PageIndex", SqlDbType.Int),//当前页
					new SqlParameter("@IsCount", SqlDbType.Bit),//返回的记录总数。非0是返回
					new SqlParameter("@OrderType", SqlDbType.VarChar,50),//排序类型
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),//查询条件
					};
            parameters[0].Value = "NavigateList";
            parameters[1].Value = strColumns;
            parameters[2].Value = strOrderColumn;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Value = nIsCount;
            parameters[6].Value = strOrderType;
            parameters[7].Value = strWhere;
            return DbHelperSQL.RunProcedure("GetRecordFromPage", parameters, "ds");
        }
        #endregion  MethodEx
    }
}