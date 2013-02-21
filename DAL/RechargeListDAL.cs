using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
    /// <summary>
    /// 数据访问类:RechargeListDAL
    /// </summary>
    public partial class RechargeListDAL
    {
        public RechargeListDAL()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RechargeID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@RechargeID", SqlDbType.Int,4)
			};
            parameters[0].Value = RechargeID;

            int result = DbHelperSQL.RunProcedure("RechargeList_Exists", parameters, out rowsAffected);
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
        public int Add(zlzw.Model.RechargeListModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@RechargeID", SqlDbType.Int,4),
					new SqlParameter("@RechargeGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EnterpriseGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Expand_RechargeGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@RechargeSum", SqlDbType.Float,8),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@IsEnable", SqlDbType.Int,4),
					new SqlParameter("@Other01", SqlDbType.NVarChar,50),
					new SqlParameter("@Other02", SqlDbType.NVarChar,50),
					new SqlParameter("@Other03", SqlDbType.NVarChar,50)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = model.EnterpriseGuid;
            parameters[3].Value = model.UserGuid;
            parameters[4].Value = model.Expand_RechargeGUID;
            parameters[5].Value = model.RechargeSum;
            parameters[6].Value = model.PublishDate;
            parameters[7].Value = model.IsEnable;
            parameters[8].Value = model.Other01;
            parameters[9].Value = model.Other02;
            parameters[10].Value = model.Other03;

            DbHelperSQL.RunProcedure("RechargeList_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(zlzw.Model.RechargeListModel model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@RechargeID", SqlDbType.Int,4),
					new SqlParameter("@RechargeGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EnterpriseGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Expand_RechargeGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@RechargeSum", SqlDbType.Float,8),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@IsEnable", SqlDbType.Int,4),
					new SqlParameter("@Other01", SqlDbType.NVarChar,50),
					new SqlParameter("@Other02", SqlDbType.NVarChar,50),
					new SqlParameter("@Other03", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.RechargeID;
            parameters[1].Value = model.RechargeGUID;
            parameters[2].Value = model.EnterpriseGuid;
            parameters[3].Value = model.UserGuid;
            parameters[4].Value = model.Expand_RechargeGUID;
            parameters[5].Value = model.RechargeSum;
            parameters[6].Value = model.PublishDate;
            parameters[7].Value = model.IsEnable;
            parameters[8].Value = model.Other01;
            parameters[9].Value = model.Other02;
            parameters[10].Value = model.Other03;

            DbHelperSQL.RunProcedure("RechargeList_Update", parameters, out rowsAffected);
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
        public bool Delete(int RechargeID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@RechargeID", SqlDbType.Int,4)
			};
            parameters[0].Value = RechargeID;

            DbHelperSQL.RunProcedure("RechargeList_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string RechargeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RechargeList ");
            strSql.Append(" where RechargeID in (" + RechargeIDlist + ")  ");
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
        public zlzw.Model.RechargeListModel GetModel(int RechargeID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@RechargeID", SqlDbType.Int,4)
			};
            parameters[0].Value = RechargeID;

            zlzw.Model.RechargeListModel model = new zlzw.Model.RechargeListModel();
            DataSet ds = DbHelperSQL.RunProcedure("RechargeList_GetModel", parameters, "ds");
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
        public zlzw.Model.RechargeListModel DataRowToModel(DataRow row)
        {
            zlzw.Model.RechargeListModel model = new zlzw.Model.RechargeListModel();
            if (row != null)
            {
                if (row["RechargeID"] != null && row["RechargeID"].ToString() != "")
                {
                    model.RechargeID = int.Parse(row["RechargeID"].ToString());
                }
                if (row["RechargeGUID"] != null && row["RechargeGUID"].ToString() != "")
                {
                    model.RechargeGUID = new Guid(row["RechargeGUID"].ToString());
                }
                if (row["EnterpriseGuid"] != null && row["EnterpriseGuid"].ToString() != "")
                {
                    model.EnterpriseGuid = new Guid(row["EnterpriseGuid"].ToString());
                }
                if (row["UserGuid"] != null && row["UserGuid"].ToString() != "")
                {
                    model.UserGuid = new Guid(row["UserGuid"].ToString());
                }
                if (row["Expand_RechargeGUID"] != null && row["Expand_RechargeGUID"].ToString() != "")
                {
                    model.Expand_RechargeGUID = new Guid(row["Expand_RechargeGUID"].ToString());
                }
                if (row["RechargeSum"] != null && row["RechargeSum"].ToString() != "")
                {
                    model.RechargeSum = decimal.Parse(row["RechargeSum"].ToString());
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
                if (row["Other03"] != null)
                {
                    model.Other03 = row["Other03"].ToString();
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
            strSql.Append("select RechargeID,RechargeGUID,EnterpriseGuid,UserGuid,Expand_RechargeGUID,RechargeSum,PublishDate,IsEnable,Other01,Other02,Other03 ");
            strSql.Append(" FROM RechargeList ");
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
            strSql.Append(" RechargeID,RechargeGUID,EnterpriseGuid,UserGuid,Expand_RechargeGUID,RechargeSum,PublishDate,IsEnable,Other01,Other02,Other03 ");
            strSql.Append(" FROM RechargeList ");
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
            strSql.Append("select count(1) FROM RechargeList ");
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
                strSql.Append("order by T.RechargeID desc");
            }
            strSql.Append(")AS Row, T.*  from RechargeList T ");
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
            parameters[0].Value = "RechargeList";
            parameters[1].Value = "RechargeID";
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
            parameters[0].Value = "RechargeList";
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