using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
    /// <summary>
    /// 数据访问类:JobEnterpriseResumeFavoriteDAL
    /// </summary>
    public partial class JobEnterpriseResumeFavoriteDAL
    {
        public JobEnterpriseResumeFavoriteDAL()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FavoriteID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@FavoriteID", SqlDbType.Int,4)
			};
            parameters[0].Value = FavoriteID;

            int result = DbHelperSQL.RunProcedure("JobEnterpriseResumeFavorite_Exists", parameters, out rowsAffected);
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
        public int Add(zlzw.Model.JobEnterpriseResumeFavoriteModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@FavoriteID", SqlDbType.Int,4),
					new SqlParameter("@FavoriteGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@FavoriteStatus", SqlDbType.Int,4),
					new SqlParameter("@FavoriteType", SqlDbType.Int,4),
					new SqlParameter("@FavoriteCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@FavoriteCustomCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseKey", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseName", SqlDbType.NVarChar,50),
					new SqlParameter("@PersonResumeKey", SqlDbType.NVarChar,50),
					new SqlParameter("@PersonResumeName", SqlDbType.NVarChar,50),
					new SqlParameter("@PersonUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@PersonUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@FavoriteMemo", SqlDbType.NVarChar,-1),
					new SqlParameter("@FavoriteDate", SqlDbType.DateTime),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = model.FavoriteStatus;
            parameters[3].Value = model.FavoriteType;
            parameters[4].Value = model.FavoriteCategory;
            parameters[5].Value = model.FavoriteCustomCategory;
            parameters[6].Value = model.EnterpriseKey;
            parameters[7].Value = model.EnterpriseName;
            parameters[8].Value = model.PersonResumeKey;
            parameters[9].Value = model.PersonResumeName;
            parameters[10].Value = model.PersonUserKey;
            parameters[11].Value = model.PersonUserName;
            parameters[12].Value = model.FavoriteMemo;
            parameters[13].Value = model.FavoriteDate;
            parameters[14].Value = model.PropertyNames;
            parameters[15].Value = model.PropertyValues;

            DbHelperSQL.RunProcedure("JobEnterpriseResumeFavorite_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(zlzw.Model.JobEnterpriseResumeFavoriteModel model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@FavoriteID", SqlDbType.Int,4),
					new SqlParameter("@FavoriteGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@FavoriteStatus", SqlDbType.Int,4),
					new SqlParameter("@FavoriteType", SqlDbType.Int,4),
					new SqlParameter("@FavoriteCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@FavoriteCustomCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseKey", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseName", SqlDbType.NVarChar,50),
					new SqlParameter("@PersonResumeKey", SqlDbType.NVarChar,50),
					new SqlParameter("@PersonResumeName", SqlDbType.NVarChar,50),
					new SqlParameter("@PersonUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@PersonUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@FavoriteMemo", SqlDbType.NVarChar,-1),
					new SqlParameter("@FavoriteDate", SqlDbType.DateTime),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.FavoriteID;
            parameters[1].Value = model.FavoriteGuid;
            parameters[2].Value = model.FavoriteStatus;
            parameters[3].Value = model.FavoriteType;
            parameters[4].Value = model.FavoriteCategory;
            parameters[5].Value = model.FavoriteCustomCategory;
            parameters[6].Value = model.EnterpriseKey;
            parameters[7].Value = model.EnterpriseName;
            parameters[8].Value = model.PersonResumeKey;
            parameters[9].Value = model.PersonResumeName;
            parameters[10].Value = model.PersonUserKey;
            parameters[11].Value = model.PersonUserName;
            parameters[12].Value = model.FavoriteMemo;
            parameters[13].Value = model.FavoriteDate;
            parameters[14].Value = model.PropertyNames;
            parameters[15].Value = model.PropertyValues;

            DbHelperSQL.RunProcedure("JobEnterpriseResumeFavorite_Update", parameters, out rowsAffected);
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
        public bool Delete(int FavoriteID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@FavoriteID", SqlDbType.Int,4)
			};
            parameters[0].Value = FavoriteID;

            DbHelperSQL.RunProcedure("JobEnterpriseResumeFavorite_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string FavoriteIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from JobEnterpriseResumeFavorite ");
            strSql.Append(" where FavoriteID in (" + FavoriteIDlist + ")  ");
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
        public zlzw.Model.JobEnterpriseResumeFavoriteModel GetModel(int FavoriteID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@FavoriteID", SqlDbType.Int,4)
			};
            parameters[0].Value = FavoriteID;

            zlzw.Model.JobEnterpriseResumeFavoriteModel model = new zlzw.Model.JobEnterpriseResumeFavoriteModel();
            DataSet ds = DbHelperSQL.RunProcedure("JobEnterpriseResumeFavorite_GetModel", parameters, "ds");
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
        public zlzw.Model.JobEnterpriseResumeFavoriteModel DataRowToModel(DataRow row)
        {
            zlzw.Model.JobEnterpriseResumeFavoriteModel model = new zlzw.Model.JobEnterpriseResumeFavoriteModel();
            if (row != null)
            {
                if (row["FavoriteID"] != null && row["FavoriteID"].ToString() != "")
                {
                    model.FavoriteID = int.Parse(row["FavoriteID"].ToString());
                }
                if (row["FavoriteGuid"] != null && row["FavoriteGuid"].ToString() != "")
                {
                    model.FavoriteGuid = new Guid(row["FavoriteGuid"].ToString());
                }
                if (row["FavoriteStatus"] != null && row["FavoriteStatus"].ToString() != "")
                {
                    model.FavoriteStatus = int.Parse(row["FavoriteStatus"].ToString());
                }
                if (row["FavoriteType"] != null && row["FavoriteType"].ToString() != "")
                {
                    model.FavoriteType = int.Parse(row["FavoriteType"].ToString());
                }
                if (row["FavoriteCategory"] != null)
                {
                    model.FavoriteCategory = row["FavoriteCategory"].ToString();
                }
                if (row["FavoriteCustomCategory"] != null)
                {
                    model.FavoriteCustomCategory = row["FavoriteCustomCategory"].ToString();
                }
                if (row["EnterpriseKey"] != null)
                {
                    model.EnterpriseKey = row["EnterpriseKey"].ToString();
                }
                if (row["EnterpriseName"] != null)
                {
                    model.EnterpriseName = row["EnterpriseName"].ToString();
                }
                if (row["PersonResumeKey"] != null)
                {
                    model.PersonResumeKey = row["PersonResumeKey"].ToString();
                }
                if (row["PersonResumeName"] != null)
                {
                    model.PersonResumeName = row["PersonResumeName"].ToString();
                }
                if (row["PersonUserKey"] != null)
                {
                    model.PersonUserKey = row["PersonUserKey"].ToString();
                }
                if (row["PersonUserName"] != null)
                {
                    model.PersonUserName = row["PersonUserName"].ToString();
                }
                if (row["FavoriteMemo"] != null)
                {
                    model.FavoriteMemo = row["FavoriteMemo"].ToString();
                }
                if (row["FavoriteDate"] != null && row["FavoriteDate"].ToString() != "")
                {
                    model.FavoriteDate = DateTime.Parse(row["FavoriteDate"].ToString());
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
            strSql.Append("select FavoriteID,FavoriteGuid,FavoriteStatus,FavoriteType,FavoriteCategory,FavoriteCustomCategory,EnterpriseKey,EnterpriseName,PersonResumeKey,PersonResumeName,PersonUserKey,PersonUserName,FavoriteMemo,FavoriteDate,PropertyNames,PropertyValues ");
            strSql.Append(" FROM JobEnterpriseResumeFavorite ");
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
            strSql.Append(" FavoriteID,FavoriteGuid,FavoriteStatus,FavoriteType,FavoriteCategory,FavoriteCustomCategory,EnterpriseKey,EnterpriseName,PersonResumeKey,PersonResumeName,PersonUserKey,PersonUserName,FavoriteMemo,FavoriteDate,PropertyNames,PropertyValues ");
            strSql.Append(" FROM JobEnterpriseResumeFavorite ");
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
            strSql.Append("select count(1) FROM JobEnterpriseResumeFavorite ");
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
                strSql.Append("order by T.FavoriteID desc");
            }
            strSql.Append(")AS Row, T.*  from JobEnterpriseResumeFavorite T ");
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
            parameters[0].Value = "JobEnterpriseResumeFavorite";
            parameters[1].Value = "FavoriteID";
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
            parameters[0].Value = "JobEnterpriseResumeFavorite";
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