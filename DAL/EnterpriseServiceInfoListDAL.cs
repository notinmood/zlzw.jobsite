using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
    /// <summary>
    /// 数据访问类:EnterpriseServiceInfoListDAL
    /// </summary>
    public partial class EnterpriseServiceInfoListDAL
    {
        public EnterpriseServiceInfoListDAL()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int EnterpriseServiceInfoID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseServiceInfoID", SqlDbType.Int,4)
			};
            parameters[0].Value = EnterpriseServiceInfoID;

            int result = DbHelperSQL.RunProcedure("EnterpriseServiceInfoList_Exists", parameters, out rowsAffected);
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
        public int Add(zlzw.Model.EnterpriseServiceInfoListModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseServiceInfoID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseServiceTypeGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EnterpriseServiceInfoGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EnterpriseServiceInfoTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseServiceInfointroduction", SqlDbType.NVarChar,200),
					new SqlParameter("@EnterpriseServiceInfoContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@PublishID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@IsEnable", SqlDbType.Int,4),
					new SqlParameter("@Other01", SqlDbType.NVarChar,50),
					new SqlParameter("@Other02", SqlDbType.NVarChar,50)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.EnterpriseServiceTypeGUID;
            parameters[2].Value = Guid.NewGuid();
            parameters[3].Value = model.EnterpriseServiceInfoTitle;
            parameters[4].Value = model.EnterpriseServiceInfointroduction;
            parameters[5].Value = model.EnterpriseServiceInfoContent;
            parameters[6].Value = model.PublishID;
            parameters[7].Value = model.PublishDate;
            parameters[8].Value = model.IsEnable;
            parameters[9].Value = model.Other01;
            parameters[10].Value = model.Other02;

            DbHelperSQL.RunProcedure("EnterpriseServiceInfoList_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(zlzw.Model.EnterpriseServiceInfoListModel model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseServiceInfoID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseServiceTypeGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EnterpriseServiceInfoGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EnterpriseServiceInfoTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseServiceInfointroduction", SqlDbType.NVarChar,200),
					new SqlParameter("@EnterpriseServiceInfoContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@PublishID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@IsEnable", SqlDbType.Int,4),
					new SqlParameter("@Other01", SqlDbType.NVarChar,50),
					new SqlParameter("@Other02", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.EnterpriseServiceInfoID;
            parameters[1].Value = model.EnterpriseServiceTypeGUID;
            parameters[2].Value = model.EnterpriseServiceInfoGUID;
            parameters[3].Value = model.EnterpriseServiceInfoTitle;
            parameters[4].Value = model.EnterpriseServiceInfointroduction;
            parameters[5].Value = model.EnterpriseServiceInfoContent;
            parameters[6].Value = model.PublishID;
            parameters[7].Value = model.PublishDate;
            parameters[8].Value = model.IsEnable;
            parameters[9].Value = model.Other01;
            parameters[10].Value = model.Other02;

            DbHelperSQL.RunProcedure("EnterpriseServiceInfoList_Update", parameters, out rowsAffected);
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
        public bool Delete(int EnterpriseServiceInfoID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseServiceInfoID", SqlDbType.Int,4)
			};
            parameters[0].Value = EnterpriseServiceInfoID;

            DbHelperSQL.RunProcedure("EnterpriseServiceInfoList_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string EnterpriseServiceInfoIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EnterpriseServiceInfoList ");
            strSql.Append(" where EnterpriseServiceInfoID in (" + EnterpriseServiceInfoIDlist + ")  ");
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
        public zlzw.Model.EnterpriseServiceInfoListModel GetModel(int EnterpriseServiceInfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseServiceInfoID", SqlDbType.Int,4)
			};
            parameters[0].Value = EnterpriseServiceInfoID;

            zlzw.Model.EnterpriseServiceInfoListModel model = new zlzw.Model.EnterpriseServiceInfoListModel();
            DataSet ds = DbHelperSQL.RunProcedure("EnterpriseServiceInfoList_GetModel", parameters, "ds");
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
        public zlzw.Model.EnterpriseServiceInfoListModel DataRowToModel(DataRow row)
        {
            zlzw.Model.EnterpriseServiceInfoListModel model = new zlzw.Model.EnterpriseServiceInfoListModel();
            if (row != null)
            {
                if (row["EnterpriseServiceInfoID"] != null && row["EnterpriseServiceInfoID"].ToString() != "")
                {
                    model.EnterpriseServiceInfoID = int.Parse(row["EnterpriseServiceInfoID"].ToString());
                }
                if (row["EnterpriseServiceTypeGUID"] != null && row["EnterpriseServiceTypeGUID"].ToString() != "")
                {
                    model.EnterpriseServiceTypeGUID = new Guid(row["EnterpriseServiceTypeGUID"].ToString());
                }
                if (row["EnterpriseServiceInfoGUID"] != null && row["EnterpriseServiceInfoGUID"].ToString() != "")
                {
                    model.EnterpriseServiceInfoGUID = new Guid(row["EnterpriseServiceInfoGUID"].ToString());
                }
                if (row["EnterpriseServiceInfoTitle"] != null)
                {
                    model.EnterpriseServiceInfoTitle = row["EnterpriseServiceInfoTitle"].ToString();
                }
                if (row["EnterpriseServiceInfointroduction"] != null)
                {
                    model.EnterpriseServiceInfointroduction = row["EnterpriseServiceInfointroduction"].ToString();
                }
                if (row["EnterpriseServiceInfoContent"] != null)
                {
                    model.EnterpriseServiceInfoContent = row["EnterpriseServiceInfoContent"].ToString();
                }
                if (row["PublishID"] != null && row["PublishID"].ToString() != "")
                {
                    model.PublishID = new Guid(row["PublishID"].ToString());
                }
                if (row["PublishDate"] != null && row["PublishDate"].ToString() != "")
                {
                    model.PublishDate = DateTime.Parse(row["PublishDate"].ToString());
                }
                if (row["IsEnable"] != null && row["IsEnable"].ToString() != "")
                {
                    model.IsEnable = int.Parse(row["IsEnable"].ToString());
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
            strSql.Append("select EnterpriseServiceInfoID,EnterpriseServiceTypeGUID,EnterpriseServiceInfoGUID,EnterpriseServiceInfoTitle,EnterpriseServiceInfointroduction,EnterpriseServiceInfoContent,PublishID,PublishDate,IsEnable,Other01,Other02 ");
            strSql.Append(" FROM EnterpriseServiceInfoList ");
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
            strSql.Append(" EnterpriseServiceInfoID,EnterpriseServiceTypeGUID,EnterpriseServiceInfoGUID,EnterpriseServiceInfoTitle,EnterpriseServiceInfointroduction,EnterpriseServiceInfoContent,PublishID,PublishDate,IsEnable,Other01,Other02 ");
            strSql.Append(" FROM EnterpriseServiceInfoList ");
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
            strSql.Append("select count(1) FROM EnterpriseServiceInfoList ");
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
                strSql.Append("order by T.EnterpriseServiceInfoID desc");
            }
            strSql.Append(")AS Row, T.*  from EnterpriseServiceInfoList T ");
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
            parameters[0].Value = "EnterpriseServiceInfoList";
            parameters[1].Value = "EnterpriseServiceInfoID";
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
            parameters[0].Value = "EnterpriseServiceInfoList";
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