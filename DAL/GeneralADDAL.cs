using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
    /// <summary>
    /// 数据访问类:GeneralADDAL
    /// </summary>
    public partial class GeneralADDAL
    {
        public GeneralADDAL()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ADID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ADID", SqlDbType.Int,4)
			};
            parameters[0].Value = ADID;

            int result = DbHelperSQL.RunProcedure("GeneralAD_Exists", parameters, out rowsAffected);
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
        public int Add(zlzw.Model.GeneralADModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ADID", SqlDbType.Int,4),
					new SqlParameter("@ADGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ADName", SqlDbType.NVarChar,50),
					new SqlParameter("@ADImageKey", SqlDbType.NVarChar,50),
					new SqlParameter("@ADImagePath", SqlDbType.NVarChar,200),
					new SqlParameter("@ADScript", SqlDbType.NVarChar,2000),
					new SqlParameter("@ADTargetUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@ADType", SqlDbType.Int,4),
					new SqlParameter("@ADKind", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ADCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@ADStatus", SqlDbType.Int,4),
					new SqlParameter("@DisplayStartDate", SqlDbType.DateTime),
					new SqlParameter("@DisplayEndDate", SqlDbType.DateTime),
					new SqlParameter("@ADDesc", SqlDbType.NVarChar,-1),
					new SqlParameter("@ADMemo", SqlDbType.NVarChar,-1),
					new SqlParameter("@ADOrderNumber", SqlDbType.Int,4),
					new SqlParameter("@ADWidth", SqlDbType.Int,4),
					new SqlParameter("@ADHeight", SqlDbType.Int,4),
					new SqlParameter("@CreateUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@RefreshDate", SqlDbType.DateTime),
					new SqlParameter("@ADOwnerKey", SqlDbType.NVarChar,50),
					new SqlParameter("@ADOwnerName", SqlDbType.NVarChar,50),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = model.ADName;
            parameters[3].Value = model.ADImageKey;
            parameters[4].Value = model.ADImagePath;
            parameters[5].Value = model.ADScript;
            parameters[6].Value = model.ADTargetUrl;
            parameters[7].Value = model.ADType;
            parameters[8].Value = Guid.NewGuid();
            parameters[9].Value = model.ADCategory;
            parameters[10].Value = model.ADStatus;
            parameters[11].Value = model.DisplayStartDate;
            parameters[12].Value = model.DisplayEndDate;
            parameters[13].Value = model.ADDesc;
            parameters[14].Value = model.ADMemo;
            parameters[15].Value = model.ADOrderNumber;
            parameters[16].Value = model.ADWidth;
            parameters[17].Value = model.ADHeight;
            parameters[18].Value = model.CreateUserKey;
            parameters[19].Value = model.CreateUserName;
            parameters[20].Value = model.CreateDate;
            parameters[21].Value = model.UpdateDate;
            parameters[22].Value = model.RefreshDate;
            parameters[23].Value = model.ADOwnerKey;
            parameters[24].Value = model.ADOwnerName;
            parameters[25].Value = model.CanUsable;
            parameters[26].Value = model.PropertyNames;
            parameters[27].Value = model.PropertyValues;

            DbHelperSQL.RunProcedure("GeneralAD_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(zlzw.Model.GeneralADModel model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ADID", SqlDbType.Int,4),
					new SqlParameter("@ADGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ADName", SqlDbType.NVarChar,50),
					new SqlParameter("@ADImageKey", SqlDbType.NVarChar,50),
					new SqlParameter("@ADImagePath", SqlDbType.NVarChar,200),
					new SqlParameter("@ADScript", SqlDbType.NVarChar,2000),
					new SqlParameter("@ADTargetUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@ADType", SqlDbType.Int,4),
					new SqlParameter("@ADKind", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ADCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@ADStatus", SqlDbType.Int,4),
					new SqlParameter("@DisplayStartDate", SqlDbType.DateTime),
					new SqlParameter("@DisplayEndDate", SqlDbType.DateTime),
					new SqlParameter("@ADDesc", SqlDbType.NVarChar,-1),
					new SqlParameter("@ADMemo", SqlDbType.NVarChar,-1),
					new SqlParameter("@ADOrderNumber", SqlDbType.Int,4),
					new SqlParameter("@ADWidth", SqlDbType.Int,4),
					new SqlParameter("@ADHeight", SqlDbType.Int,4),
					new SqlParameter("@CreateUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@RefreshDate", SqlDbType.DateTime),
					new SqlParameter("@ADOwnerKey", SqlDbType.NVarChar,50),
					new SqlParameter("@ADOwnerName", SqlDbType.NVarChar,50),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.ADID;
            parameters[1].Value = model.ADGuid;
            parameters[2].Value = model.ADName;
            parameters[3].Value = model.ADImageKey;
            parameters[4].Value = model.ADImagePath;
            parameters[5].Value = model.ADScript;
            parameters[6].Value = model.ADTargetUrl;
            parameters[7].Value = model.ADType;
            parameters[8].Value = model.ADKind;
            parameters[9].Value = model.ADCategory;
            parameters[10].Value = model.ADStatus;
            parameters[11].Value = model.DisplayStartDate;
            parameters[12].Value = model.DisplayEndDate;
            parameters[13].Value = model.ADDesc;
            parameters[14].Value = model.ADMemo;
            parameters[15].Value = model.ADOrderNumber;
            parameters[16].Value = model.ADWidth;
            parameters[17].Value = model.ADHeight;
            parameters[18].Value = model.CreateUserKey;
            parameters[19].Value = model.CreateUserName;
            parameters[20].Value = model.CreateDate;
            parameters[21].Value = model.UpdateDate;
            parameters[22].Value = model.RefreshDate;
            parameters[23].Value = model.ADOwnerKey;
            parameters[24].Value = model.ADOwnerName;
            parameters[25].Value = model.CanUsable;
            parameters[26].Value = model.PropertyNames;
            parameters[27].Value = model.PropertyValues;

            DbHelperSQL.RunProcedure("GeneralAD_Update", parameters, out rowsAffected);
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
        public bool Delete(int ADID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ADID", SqlDbType.Int,4)
			};
            parameters[0].Value = ADID;

            DbHelperSQL.RunProcedure("GeneralAD_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string ADIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GeneralAD ");
            strSql.Append(" where ADID in (" + ADIDlist + ")  ");
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
        public zlzw.Model.GeneralADModel GetModel(int ADID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ADID", SqlDbType.Int,4)
			};
            parameters[0].Value = ADID;

            zlzw.Model.GeneralADModel model = new zlzw.Model.GeneralADModel();
            DataSet ds = DbHelperSQL.RunProcedure("GeneralAD_GetModel", parameters, "ds");
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
        public zlzw.Model.GeneralADModel DataRowToModel(DataRow row)
        {
            zlzw.Model.GeneralADModel model = new zlzw.Model.GeneralADModel();
            if (row != null)
            {
                if (row["ADID"] != null && row["ADID"].ToString() != "")
                {
                    model.ADID = int.Parse(row["ADID"].ToString());
                }
                if (row["ADGuid"] != null && row["ADGuid"].ToString() != "")
                {
                    model.ADGuid = new Guid(row["ADGuid"].ToString());
                }
                if (row["ADName"] != null)
                {
                    model.ADName = row["ADName"].ToString();
                }
                if (row["ADImageKey"] != null)
                {
                    model.ADImageKey = row["ADImageKey"].ToString();
                }
                if (row["ADImagePath"] != null)
                {
                    model.ADImagePath = row["ADImagePath"].ToString();
                }
                if (row["ADScript"] != null)
                {
                    model.ADScript = row["ADScript"].ToString();
                }
                if (row["ADTargetUrl"] != null)
                {
                    model.ADTargetUrl = row["ADTargetUrl"].ToString();
                }
                if (row["ADType"] != null && row["ADType"].ToString() != "")
                {
                    model.ADType = int.Parse(row["ADType"].ToString());
                }
                if (row["ADKind"] != null && row["ADKind"].ToString() != "")
                {
                    model.ADKind = new Guid(row["ADKind"].ToString());
                }
                if (row["ADCategory"] != null)
                {
                    model.ADCategory = row["ADCategory"].ToString();
                }
                if (row["ADStatus"] != null && row["ADStatus"].ToString() != "")
                {
                    model.ADStatus = int.Parse(row["ADStatus"].ToString());
                }
                if (row["DisplayStartDate"] != null && row["DisplayStartDate"].ToString() != "")
                {
                    model.DisplayStartDate = DateTime.Parse(row["DisplayStartDate"].ToString());
                }
                if (row["DisplayEndDate"] != null && row["DisplayEndDate"].ToString() != "")
                {
                    model.DisplayEndDate = DateTime.Parse(row["DisplayEndDate"].ToString());
                }
                if (row["ADDesc"] != null)
                {
                    model.ADDesc = row["ADDesc"].ToString();
                }
                if (row["ADMemo"] != null)
                {
                    model.ADMemo = row["ADMemo"].ToString();
                }
                if (row["ADOrderNumber"] != null && row["ADOrderNumber"].ToString() != "")
                {
                    model.ADOrderNumber = int.Parse(row["ADOrderNumber"].ToString());
                }
                if (row["ADWidth"] != null && row["ADWidth"].ToString() != "")
                {
                    model.ADWidth = int.Parse(row["ADWidth"].ToString());
                }
                if (row["ADHeight"] != null && row["ADHeight"].ToString() != "")
                {
                    model.ADHeight = int.Parse(row["ADHeight"].ToString());
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
                if (row["UpdateDate"] != null && row["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
                }
                if (row["RefreshDate"] != null && row["RefreshDate"].ToString() != "")
                {
                    model.RefreshDate = DateTime.Parse(row["RefreshDate"].ToString());
                }
                if (row["ADOwnerKey"] != null)
                {
                    model.ADOwnerKey = row["ADOwnerKey"].ToString();
                }
                if (row["ADOwnerName"] != null)
                {
                    model.ADOwnerName = row["ADOwnerName"].ToString();
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
            strSql.Append("select ADID,ADGuid,ADName,ADImageKey,ADImagePath,ADScript,ADTargetUrl,ADType,ADKind,ADCategory,ADStatus,DisplayStartDate,DisplayEndDate,ADDesc,ADMemo,ADOrderNumber,ADWidth,ADHeight,CreateUserKey,CreateUserName,CreateDate,UpdateDate,RefreshDate,ADOwnerKey,ADOwnerName,CanUsable,PropertyNames,PropertyValues ");
            strSql.Append(" FROM GeneralAD ");
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
            strSql.Append(" ADID,ADGuid,ADName,ADImageKey,ADImagePath,ADScript,ADTargetUrl,ADType,ADKind,ADCategory,ADStatus,DisplayStartDate,DisplayEndDate,ADDesc,ADMemo,ADOrderNumber,ADWidth,ADHeight,CreateUserKey,CreateUserName,CreateDate,UpdateDate,RefreshDate,ADOwnerKey,ADOwnerName,CanUsable,PropertyNames,PropertyValues ");
            strSql.Append(" FROM GeneralAD ");
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
            strSql.Append("select count(1) FROM GeneralAD ");
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
                strSql.Append("order by T.ADID desc");
            }
            strSql.Append(")AS Row, T.*  from GeneralAD T ");
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
            parameters[0].Value = "GeneralAD";
            parameters[1].Value = "ADID";
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
            parameters[0].Value = "GeneralAD";
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