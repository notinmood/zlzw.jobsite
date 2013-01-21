using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
    /// <summary>
    /// 数据访问类:GeneralBasicSettingDAL
    /// </summary>
    public partial class GeneralBasicSettingDAL
    {
        public GeneralBasicSettingDAL()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SettingID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SettingID", SqlDbType.Int,4)
			};
            parameters[0].Value = SettingID;

            int result = DbHelperSQL.RunProcedure("GeneralBasicSetting_Exists", parameters, out rowsAffected);
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
        public int Add(zlzw.Model.GeneralBasicSettingModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SettingID", SqlDbType.Int,4),
					new SqlParameter("@SettingKey", SqlDbType.NVarChar,50),
					new SqlParameter("@SettingValue", SqlDbType.NVarChar,200),
					new SqlParameter("@SettingDesc", SqlDbType.NVarChar,-1),
					new SqlParameter("@SettingCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@DisplayName", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderNumber", SqlDbType.Int,4),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@IsInnerSetting", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.SettingKey;
            parameters[2].Value = model.SettingValue;
            parameters[3].Value = model.SettingDesc;
            parameters[4].Value = model.SettingCategory;
            parameters[5].Value = model.DisplayName;
            parameters[6].Value = model.OrderNumber;
            parameters[7].Value = model.CanUsable;
            parameters[8].Value = model.IsInnerSetting;

            DbHelperSQL.RunProcedure("GeneralBasicSetting_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(zlzw.Model.GeneralBasicSettingModel model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@SettingID", SqlDbType.Int,4),
					new SqlParameter("@SettingKey", SqlDbType.NVarChar,50),
					new SqlParameter("@SettingValue", SqlDbType.NVarChar,200),
					new SqlParameter("@SettingDesc", SqlDbType.NVarChar,-1),
					new SqlParameter("@SettingCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@DisplayName", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderNumber", SqlDbType.Int,4),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@IsInnerSetting", SqlDbType.Int,4)};
            parameters[0].Value = model.SettingID;
            parameters[1].Value = model.SettingKey;
            parameters[2].Value = model.SettingValue;
            parameters[3].Value = model.SettingDesc;
            parameters[4].Value = model.SettingCategory;
            parameters[5].Value = model.DisplayName;
            parameters[6].Value = model.OrderNumber;
            parameters[7].Value = model.CanUsable;
            parameters[8].Value = model.IsInnerSetting;

            DbHelperSQL.RunProcedure("GeneralBasicSetting_Update", parameters, out rowsAffected);
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
        public bool Delete(int SettingID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@SettingID", SqlDbType.Int,4)
			};
            parameters[0].Value = SettingID;

            DbHelperSQL.RunProcedure("GeneralBasicSetting_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string SettingIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GeneralBasicSetting ");
            strSql.Append(" where SettingID in (" + SettingIDlist + ")  ");
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
        public zlzw.Model.GeneralBasicSettingModel GetModel(int SettingID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SettingID", SqlDbType.Int,4)
			};
            parameters[0].Value = SettingID;

            zlzw.Model.GeneralBasicSettingModel model = new zlzw.Model.GeneralBasicSettingModel();
            DataSet ds = DbHelperSQL.RunProcedure("GeneralBasicSetting_GetModel", parameters, "ds");
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
        public zlzw.Model.GeneralBasicSettingModel DataRowToModel(DataRow row)
        {
            zlzw.Model.GeneralBasicSettingModel model = new zlzw.Model.GeneralBasicSettingModel();
            if (row != null)
            {
                if (row["SettingID"] != null && row["SettingID"].ToString() != "")
                {
                    model.SettingID = int.Parse(row["SettingID"].ToString());
                }
                if (row["SettingKey"] != null)
                {
                    model.SettingKey = row["SettingKey"].ToString();
                }
                if (row["SettingValue"] != null)
                {
                    model.SettingValue = row["SettingValue"].ToString();
                }
                if (row["SettingDesc"] != null)
                {
                    model.SettingDesc = row["SettingDesc"].ToString();
                }
                if (row["SettingCategory"] != null)
                {
                    model.SettingCategory = row["SettingCategory"].ToString();
                }
                if (row["DisplayName"] != null)
                {
                    model.DisplayName = row["DisplayName"].ToString();
                }
                if (row["OrderNumber"] != null && row["OrderNumber"].ToString() != "")
                {
                    model.OrderNumber = int.Parse(row["OrderNumber"].ToString());
                }
                if (row["CanUsable"] != null && row["CanUsable"].ToString() != "")
                {
                    model.CanUsable = int.Parse(row["CanUsable"].ToString());
                }
                if (row["IsInnerSetting"] != null && row["IsInnerSetting"].ToString() != "")
                {
                    model.IsInnerSetting = int.Parse(row["IsInnerSetting"].ToString());
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
            strSql.Append("select SettingID,SettingKey,SettingValue,SettingDesc,SettingCategory,DisplayName,OrderNumber,CanUsable,IsInnerSetting ");
            strSql.Append(" FROM GeneralBasicSetting ");
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
            strSql.Append(" SettingID,SettingKey,SettingValue,SettingDesc,SettingCategory,DisplayName,OrderNumber,CanUsable,IsInnerSetting ");
            strSql.Append(" FROM GeneralBasicSetting ");
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
            strSql.Append("select count(1) FROM GeneralBasicSetting ");
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
                strSql.Append("order by T.SettingID desc");
            }
            strSql.Append(")AS Row, T.*  from GeneralBasicSetting T ");
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
            parameters[0].Value = "GeneralBasicSetting";
            parameters[1].Value = "SettingID";
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
            parameters[0].Value = "GeneralBasicSetting";
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