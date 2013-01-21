using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
    /// <summary>
    /// 数据访问类:GeneralActivityDAL
    /// </summary>
    public partial class GeneralActivityDAL
    {
        public GeneralActivityDAL()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ActivityID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ActivityID", SqlDbType.Int,4)
			};
            parameters[0].Value = ActivityID;

            int result = DbHelperSQL.RunProcedure("GeneralActivity_Exists", parameters, out rowsAffected);
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
        public int Add(zlzw.Model.GeneralActivityModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ActivityID", SqlDbType.Int,4),
					new SqlParameter("@ActivityGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ActivityType", SqlDbType.Int,4),
					new SqlParameter("@ActivityKind", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ActivityCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityDate", SqlDbType.DateTime),
					new SqlParameter("@ActivityAreaCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityAreaDetails", SqlDbType.NVarChar,200),
					new SqlParameter("@ActivityAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@ActivityAddressDetails", SqlDbType.NVarChar,200),
					new SqlParameter("@ActivityTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityDesc", SqlDbType.NVarChar,-1),
					new SqlParameter("@ActivitySummary", SqlDbType.NVarChar,-1),
					new SqlParameter("@ActivityAddon", SqlDbType.NVarChar,-1),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@CreateUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@SpecialType", SqlDbType.Int,4),
					new SqlParameter("@JoinUserCount", SqlDbType.Int,4),
					new SqlParameter("@ActivityReviewDetails", SqlDbType.NVarChar,-1),
					new SqlParameter("@ActivityReviewKey", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityReviewTarget", SqlDbType.NVarChar,200),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = model.ActivityType;
            parameters[3].Value = Guid.NewGuid();
            parameters[4].Value = model.ActivityCategory;
            parameters[5].Value = model.ActivityDate;
            parameters[6].Value = model.ActivityAreaCode;
            parameters[7].Value = model.ActivityAreaDetails;
            parameters[8].Value = model.ActivityAddress;
            parameters[9].Value = model.ActivityAddressDetails;
            parameters[10].Value = model.ActivityTitle;
            parameters[11].Value = model.ActivityDesc;
            parameters[12].Value = model.ActivitySummary;
            parameters[13].Value = model.ActivityAddon;
            parameters[14].Value = model.PublishDate;
            parameters[15].Value = model.CanUsable;
            parameters[16].Value = model.CreateUserKey;
            parameters[17].Value = model.CreateUserName;
            parameters[18].Value = model.SpecialType;
            parameters[19].Value = model.JoinUserCount;
            parameters[20].Value = model.ActivityReviewDetails;
            parameters[21].Value = model.ActivityReviewKey;
            parameters[22].Value = model.ActivityReviewTarget;
            parameters[23].Value = model.PropertyNames;
            parameters[24].Value = model.PropertyValues;

            DbHelperSQL.RunProcedure("GeneralActivity_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(zlzw.Model.GeneralActivityModel model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ActivityID", SqlDbType.Int,4),
					new SqlParameter("@ActivityGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ActivityType", SqlDbType.Int,4),
					new SqlParameter("@ActivityKind", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ActivityCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityDate", SqlDbType.DateTime),
					new SqlParameter("@ActivityAreaCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityAreaDetails", SqlDbType.NVarChar,200),
					new SqlParameter("@ActivityAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@ActivityAddressDetails", SqlDbType.NVarChar,200),
					new SqlParameter("@ActivityTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityDesc", SqlDbType.NVarChar,-1),
					new SqlParameter("@ActivitySummary", SqlDbType.NVarChar,-1),
					new SqlParameter("@ActivityAddon", SqlDbType.NVarChar,-1),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@CreateUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@SpecialType", SqlDbType.Int,4),
					new SqlParameter("@JoinUserCount", SqlDbType.Int,4),
					new SqlParameter("@ActivityReviewDetails", SqlDbType.NVarChar,-1),
					new SqlParameter("@ActivityReviewKey", SqlDbType.NVarChar,50),
					new SqlParameter("@ActivityReviewTarget", SqlDbType.NVarChar,200),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.ActivityID;
            parameters[1].Value = model.ActivityGuid;
            parameters[2].Value = model.ActivityType;
            parameters[3].Value = model.ActivityKind;
            parameters[4].Value = model.ActivityCategory;
            parameters[5].Value = model.ActivityDate;
            parameters[6].Value = model.ActivityAreaCode;
            parameters[7].Value = model.ActivityAreaDetails;
            parameters[8].Value = model.ActivityAddress;
            parameters[9].Value = model.ActivityAddressDetails;
            parameters[10].Value = model.ActivityTitle;
            parameters[11].Value = model.ActivityDesc;
            parameters[12].Value = model.ActivitySummary;
            parameters[13].Value = model.ActivityAddon;
            parameters[14].Value = model.PublishDate;
            parameters[15].Value = model.CanUsable;
            parameters[16].Value = model.CreateUserKey;
            parameters[17].Value = model.CreateUserName;
            parameters[18].Value = model.SpecialType;
            parameters[19].Value = model.JoinUserCount;
            parameters[20].Value = model.ActivityReviewDetails;
            parameters[21].Value = model.ActivityReviewKey;
            parameters[22].Value = model.ActivityReviewTarget;
            parameters[23].Value = model.PropertyNames;
            parameters[24].Value = model.PropertyValues;

            DbHelperSQL.RunProcedure("GeneralActivity_Update", parameters, out rowsAffected);
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
        public bool Delete(int ActivityID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ActivityID", SqlDbType.Int,4)
			};
            parameters[0].Value = ActivityID;

            DbHelperSQL.RunProcedure("GeneralActivity_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string ActivityIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GeneralActivity ");
            strSql.Append(" where ActivityID in (" + ActivityIDlist + ")  ");
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
        public zlzw.Model.GeneralActivityModel GetModel(int ActivityID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ActivityID", SqlDbType.Int,4)
			};
            parameters[0].Value = ActivityID;

            zlzw.Model.GeneralActivityModel model = new zlzw.Model.GeneralActivityModel();
            DataSet ds = DbHelperSQL.RunProcedure("GeneralActivity_GetModel", parameters, "ds");
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
        public zlzw.Model.GeneralActivityModel DataRowToModel(DataRow row)
        {
            zlzw.Model.GeneralActivityModel model = new zlzw.Model.GeneralActivityModel();
            if (row != null)
            {
                if (row["ActivityID"] != null && row["ActivityID"].ToString() != "")
                {
                    model.ActivityID = int.Parse(row["ActivityID"].ToString());
                }
                if (row["ActivityGuid"] != null && row["ActivityGuid"].ToString() != "")
                {
                    model.ActivityGuid = new Guid(row["ActivityGuid"].ToString());
                }
                if (row["ActivityType"] != null && row["ActivityType"].ToString() != "")
                {
                    model.ActivityType = int.Parse(row["ActivityType"].ToString());
                }
                if (row["ActivityKind"] != null && row["ActivityKind"].ToString() != "")
                {
                    model.ActivityKind = new Guid(row["ActivityKind"].ToString());
                }
                if (row["ActivityCategory"] != null)
                {
                    model.ActivityCategory = row["ActivityCategory"].ToString();
                }
                if (row["ActivityDate"] != null && row["ActivityDate"].ToString() != "")
                {
                    model.ActivityDate = DateTime.Parse(row["ActivityDate"].ToString());
                }
                if (row["ActivityAreaCode"] != null)
                {
                    model.ActivityAreaCode = row["ActivityAreaCode"].ToString();
                }
                if (row["ActivityAreaDetails"] != null)
                {
                    model.ActivityAreaDetails = row["ActivityAreaDetails"].ToString();
                }
                if (row["ActivityAddress"] != null)
                {
                    model.ActivityAddress = row["ActivityAddress"].ToString();
                }
                if (row["ActivityAddressDetails"] != null)
                {
                    model.ActivityAddressDetails = row["ActivityAddressDetails"].ToString();
                }
                if (row["ActivityTitle"] != null)
                {
                    model.ActivityTitle = row["ActivityTitle"].ToString();
                }
                if (row["ActivityDesc"] != null)
                {
                    model.ActivityDesc = row["ActivityDesc"].ToString();
                }
                if (row["ActivitySummary"] != null)
                {
                    model.ActivitySummary = row["ActivitySummary"].ToString();
                }
                if (row["ActivityAddon"] != null)
                {
                    model.ActivityAddon = row["ActivityAddon"].ToString();
                }
                if (row["PublishDate"] != null && row["PublishDate"].ToString() != "")
                {
                    model.PublishDate = DateTime.Parse(row["PublishDate"].ToString());
                }
                if (row["CanUsable"] != null && row["CanUsable"].ToString() != "")
                {
                    model.CanUsable = int.Parse(row["CanUsable"].ToString());
                }
                if (row["CreateUserKey"] != null)
                {
                    model.CreateUserKey = row["CreateUserKey"].ToString();
                }
                if (row["CreateUserName"] != null)
                {
                    model.CreateUserName = row["CreateUserName"].ToString();
                }
                if (row["SpecialType"] != null && row["SpecialType"].ToString() != "")
                {
                    model.SpecialType = int.Parse(row["SpecialType"].ToString());
                }
                if (row["JoinUserCount"] != null && row["JoinUserCount"].ToString() != "")
                {
                    model.JoinUserCount = int.Parse(row["JoinUserCount"].ToString());
                }
                if (row["ActivityReviewDetails"] != null)
                {
                    model.ActivityReviewDetails = row["ActivityReviewDetails"].ToString();
                }
                if (row["ActivityReviewKey"] != null)
                {
                    model.ActivityReviewKey = row["ActivityReviewKey"].ToString();
                }
                if (row["ActivityReviewTarget"] != null)
                {
                    model.ActivityReviewTarget = row["ActivityReviewTarget"].ToString();
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
            strSql.Append("select ActivityID,ActivityGuid,ActivityType,ActivityKind,ActivityCategory,ActivityDate,ActivityAreaCode,ActivityAreaDetails,ActivityAddress,ActivityAddressDetails,ActivityTitle,ActivityDesc,ActivitySummary,ActivityAddon,PublishDate,CanUsable,CreateUserKey,CreateUserName,SpecialType,JoinUserCount,ActivityReviewDetails,ActivityReviewKey,ActivityReviewTarget,PropertyNames,PropertyValues ");
            strSql.Append(" FROM GeneralActivity ");
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
            strSql.Append(" ActivityID,ActivityGuid,ActivityType,ActivityKind,ActivityCategory,ActivityDate,ActivityAreaCode,ActivityAreaDetails,ActivityAddress,ActivityAddressDetails,ActivityTitle,ActivityDesc,ActivitySummary,ActivityAddon,PublishDate,CanUsable,CreateUserKey,CreateUserName,SpecialType,JoinUserCount,ActivityReviewDetails,ActivityReviewKey,ActivityReviewTarget,PropertyNames,PropertyValues ");
            strSql.Append(" FROM GeneralActivity ");
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
            strSql.Append("select count(1) FROM GeneralActivity ");
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
                strSql.Append("order by T.ActivityID desc");
            }
            strSql.Append(")AS Row, T.*  from GeneralActivity T ");
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
            parameters[0].Value = "GeneralActivity";
            parameters[1].Value = "ActivityID";
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
            parameters[0].Value = "GeneralActivity";
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