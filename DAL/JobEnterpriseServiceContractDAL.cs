using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
    /// <summary>
    /// 数据访问类:JobEnterpriseServiceContractDAL
    /// </summary>
    public partial class JobEnterpriseServiceContractDAL
    {
        public JobEnterpriseServiceContractDAL()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ServiceContractID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ServiceContractID", SqlDbType.Int,4)
			};
            parameters[0].Value = ServiceContractID;

            int result = DbHelperSQL.RunProcedure("JobEnterpriseServiceContract_Exists", parameters, out rowsAffected);
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
        public int Add(zlzw.Model.JobEnterpriseServiceContractModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ServiceContractID", SqlDbType.Int,4),
					new SqlParameter("@ServiceContractGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EnterpriseServiceKey", SqlDbType.NVarChar,50),
					new SqlParameter("@ServiceContractStatus", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseKey", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseName", SqlDbType.NVarChar,50),
					new SqlParameter("@ServiceContractStartDate", SqlDbType.DateTime),
					new SqlParameter("@ServiceContractEndDate", SqlDbType.DateTime),
					new SqlParameter("@ServiceContractMemo", SqlDbType.NVarChar,-1),
					new SqlParameter("@ServiceFee", SqlDbType.Decimal,9),
					new SqlParameter("@ServiceFeeIsPaid", SqlDbType.Int,4),
					new SqlParameter("@ServiceFeeManageUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@ServiceFeeManageUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = model.EnterpriseServiceKey;
            parameters[3].Value = model.ServiceContractStatus;
            parameters[4].Value = model.EnterpriseKey;
            parameters[5].Value = model.EnterpriseName;
            parameters[6].Value = model.ServiceContractStartDate;
            parameters[7].Value = model.ServiceContractEndDate;
            parameters[8].Value = model.ServiceContractMemo;
            parameters[9].Value = model.ServiceFee;
            parameters[10].Value = model.ServiceFeeIsPaid;
            parameters[11].Value = model.ServiceFeeManageUserName;
            parameters[12].Value = model.ServiceFeeManageUserKey;
            parameters[13].Value = model.CreateUserKey;
            parameters[14].Value = model.CreateUserName;
            parameters[15].Value = model.CreateDate;
            parameters[16].Value = model.CanUsable;
            parameters[17].Value = model.PropertyNames;
            parameters[18].Value = model.PropertyValues;

            DbHelperSQL.RunProcedure("JobEnterpriseServiceContract_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(zlzw.Model.JobEnterpriseServiceContractModel model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ServiceContractID", SqlDbType.Int,4),
					new SqlParameter("@ServiceContractGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EnterpriseServiceKey", SqlDbType.NVarChar,50),
					new SqlParameter("@ServiceContractStatus", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseKey", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseName", SqlDbType.NVarChar,50),
					new SqlParameter("@ServiceContractStartDate", SqlDbType.DateTime),
					new SqlParameter("@ServiceContractEndDate", SqlDbType.DateTime),
					new SqlParameter("@ServiceContractMemo", SqlDbType.NVarChar,-1),
					new SqlParameter("@ServiceFee", SqlDbType.Decimal,9),
					new SqlParameter("@ServiceFeeIsPaid", SqlDbType.Int,4),
					new SqlParameter("@ServiceFeeManageUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@ServiceFeeManageUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.ServiceContractID;
            parameters[1].Value = model.ServiceContractGuid;
            parameters[2].Value = model.EnterpriseServiceKey;
            parameters[3].Value = model.ServiceContractStatus;
            parameters[4].Value = model.EnterpriseKey;
            parameters[5].Value = model.EnterpriseName;
            parameters[6].Value = model.ServiceContractStartDate;
            parameters[7].Value = model.ServiceContractEndDate;
            parameters[8].Value = model.ServiceContractMemo;
            parameters[9].Value = model.ServiceFee;
            parameters[10].Value = model.ServiceFeeIsPaid;
            parameters[11].Value = model.ServiceFeeManageUserName;
            parameters[12].Value = model.ServiceFeeManageUserKey;
            parameters[13].Value = model.CreateUserKey;
            parameters[14].Value = model.CreateUserName;
            parameters[15].Value = model.CreateDate;
            parameters[16].Value = model.CanUsable;
            parameters[17].Value = model.PropertyNames;
            parameters[18].Value = model.PropertyValues;

            DbHelperSQL.RunProcedure("JobEnterpriseServiceContract_Update", parameters, out rowsAffected);
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
        public bool Delete(int ServiceContractID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ServiceContractID", SqlDbType.Int,4)
			};
            parameters[0].Value = ServiceContractID;

            DbHelperSQL.RunProcedure("JobEnterpriseServiceContract_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string ServiceContractIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from JobEnterpriseServiceContract ");
            strSql.Append(" where ServiceContractID in (" + ServiceContractIDlist + ")  ");
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
        public zlzw.Model.JobEnterpriseServiceContractModel GetModel(int ServiceContractID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ServiceContractID", SqlDbType.Int,4)
			};
            parameters[0].Value = ServiceContractID;

            zlzw.Model.JobEnterpriseServiceContractModel model = new zlzw.Model.JobEnterpriseServiceContractModel();
            DataSet ds = DbHelperSQL.RunProcedure("JobEnterpriseServiceContract_GetModel", parameters, "ds");
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
        public zlzw.Model.JobEnterpriseServiceContractModel DataRowToModel(DataRow row)
        {
            zlzw.Model.JobEnterpriseServiceContractModel model = new zlzw.Model.JobEnterpriseServiceContractModel();
            if (row != null)
            {
                if (row["ServiceContractID"] != null && row["ServiceContractID"].ToString() != "")
                {
                    model.ServiceContractID = int.Parse(row["ServiceContractID"].ToString());
                }
                if (row["ServiceContractGuid"] != null && row["ServiceContractGuid"].ToString() != "")
                {
                    model.ServiceContractGuid = new Guid(row["ServiceContractGuid"].ToString());
                }
                if (row["EnterpriseServiceKey"] != null)
                {
                    model.EnterpriseServiceKey = row["EnterpriseServiceKey"].ToString();
                }
                if (row["ServiceContractStatus"] != null && row["ServiceContractStatus"].ToString() != "")
                {
                    model.ServiceContractStatus = int.Parse(row["ServiceContractStatus"].ToString());
                }
                if (row["EnterpriseKey"] != null)
                {
                    model.EnterpriseKey = row["EnterpriseKey"].ToString();
                }
                if (row["EnterpriseName"] != null)
                {
                    model.EnterpriseName = row["EnterpriseName"].ToString();
                }
                if (row["ServiceContractStartDate"] != null && row["ServiceContractStartDate"].ToString() != "")
                {
                    model.ServiceContractStartDate = DateTime.Parse(row["ServiceContractStartDate"].ToString());
                }
                if (row["ServiceContractEndDate"] != null && row["ServiceContractEndDate"].ToString() != "")
                {
                    model.ServiceContractEndDate = DateTime.Parse(row["ServiceContractEndDate"].ToString());
                }
                if (row["ServiceContractMemo"] != null)
                {
                    model.ServiceContractMemo = row["ServiceContractMemo"].ToString();
                }
                if (row["ServiceFee"] != null && row["ServiceFee"].ToString() != "")
                {
                    model.ServiceFee = decimal.Parse(row["ServiceFee"].ToString());
                }
                if (row["ServiceFeeIsPaid"] != null && row["ServiceFeeIsPaid"].ToString() != "")
                {
                    model.ServiceFeeIsPaid = int.Parse(row["ServiceFeeIsPaid"].ToString());
                }
                if (row["ServiceFeeManageUserName"] != null)
                {
                    model.ServiceFeeManageUserName = row["ServiceFeeManageUserName"].ToString();
                }
                if (row["ServiceFeeManageUserKey"] != null)
                {
                    model.ServiceFeeManageUserKey = row["ServiceFeeManageUserKey"].ToString();
                }
                if (row["CreateUserKey"] != null)
                {
                    model.CreateUserKey = row["CreateUserKey"].ToString();
                }
                if (row["CreateUserName"] != null)
                {
                    model.CreateUserName = row["CreateUserName"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["CanUsable"] != null && row["CanUsable"].ToString() != "")
                {
                    model.CanUsable = int.Parse(row["CanUsable"].ToString());
                }
                if (row["PropertyNames"] != null)
                {
                    model.PropertyNames = row["PropertyNames"].ToString();
                }
                if (row["PropertyValues"] != null)
                {
                    model.PropertyValues = row["PropertyValues"].ToString();
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
            strSql.Append("select ServiceContractID,ServiceContractGuid,EnterpriseServiceKey,ServiceContractStatus,EnterpriseKey,EnterpriseName,ServiceContractStartDate,ServiceContractEndDate,ServiceContractMemo,ServiceFee,ServiceFeeIsPaid,ServiceFeeManageUserName,ServiceFeeManageUserKey,CreateUserKey,CreateUserName,CreateDate,CanUsable,PropertyNames,PropertyValues ");
            strSql.Append(" FROM JobEnterpriseServiceContract ");
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
            strSql.Append(" ServiceContractID,ServiceContractGuid,EnterpriseServiceKey,ServiceContractStatus,EnterpriseKey,EnterpriseName,ServiceContractStartDate,ServiceContractEndDate,ServiceContractMemo,ServiceFee,ServiceFeeIsPaid,ServiceFeeManageUserName,ServiceFeeManageUserKey,CreateUserKey,CreateUserName,CreateDate,CanUsable,PropertyNames,PropertyValues ");
            strSql.Append(" FROM JobEnterpriseServiceContract ");
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
            strSql.Append("select count(1) FROM JobEnterpriseServiceContract ");
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
                strSql.Append("order by T.ServiceContractID desc");
            }
            strSql.Append(")AS Row, T.*  from JobEnterpriseServiceContract T ");
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
            parameters[0].Value = "JobEnterpriseServiceContract";
            parameters[1].Value = "ServiceContractID";
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
            parameters[0].Value = "JobEnterpriseServiceContract";
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