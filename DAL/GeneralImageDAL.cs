using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
    /// <summary>
    /// 数据访问类:GeneralImageDAL
    /// </summary>
    public partial class GeneralImageDAL
    {
        public GeneralImageDAL()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ImageID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ImageID", SqlDbType.Int,4)
			};
            parameters[0].Value = ImageID;

            int result = DbHelperSQL.RunProcedure("GeneralImage_Exists", parameters, out rowsAffected);
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
        public int Add(zlzw.Model.GeneralImageModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ImageID", SqlDbType.Int,4),
					new SqlParameter("@ImageGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ImageName", SqlDbType.NVarChar,200),
					new SqlParameter("@RelativeGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ImageCategoryCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ImageKind", SqlDbType.NVarChar,50),
					new SqlParameter("@OwnerGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ImageRelativePath", SqlDbType.NVarChar,500),
					new SqlParameter("@ImageSize", SqlDbType.Int,4),
					new SqlParameter("@ImageWidth", SqlDbType.Int,4),
					new SqlParameter("@ImageHeight", SqlDbType.Int,4),
					new SqlParameter("@ImageStatus", SqlDbType.Int,4),
					new SqlParameter("@ImageOrder", SqlDbType.Int,4),
					new SqlParameter("@ImageIsMain", SqlDbType.Int,4),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@ImageType", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ImageDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@ImageDownCount", SqlDbType.Int,4),
					new SqlParameter("@ImageDisplayCount", SqlDbType.Int,4),
					new SqlParameter("@PropertyNames", SqlDbType.NText),
					new SqlParameter("@PropertyValues", SqlDbType.NText)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = model.ImageName;
            parameters[3].Value = Guid.NewGuid();
            parameters[4].Value = model.ImageCategoryCode;
            parameters[5].Value = model.ImageKind;
            parameters[6].Value = Guid.NewGuid();
            parameters[7].Value = model.ImageRelativePath;
            parameters[8].Value = model.ImageSize;
            parameters[9].Value = model.ImageWidth;
            parameters[10].Value = model.ImageHeight;
            parameters[11].Value = model.ImageStatus;
            parameters[12].Value = model.ImageOrder;
            parameters[13].Value = model.ImageIsMain;
            parameters[14].Value = model.CanUsable;
            parameters[15].Value = model.ImageType;
            parameters[16].Value = model.CreateTime;
            parameters[17].Value = model.ImageDescription;
            parameters[18].Value = model.ImageDownCount;
            parameters[19].Value = model.ImageDisplayCount;
            parameters[20].Value = model.PropertyNames;
            parameters[21].Value = model.PropertyValues;

            DbHelperSQL.RunProcedure("GeneralImage_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(zlzw.Model.GeneralImageModel model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ImageID", SqlDbType.Int,4),
					new SqlParameter("@ImageGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ImageName", SqlDbType.NVarChar,200),
					new SqlParameter("@RelativeGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ImageCategoryCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ImageKind", SqlDbType.NVarChar,50),
					new SqlParameter("@OwnerGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ImageRelativePath", SqlDbType.NVarChar,500),
					new SqlParameter("@ImageSize", SqlDbType.Int,4),
					new SqlParameter("@ImageWidth", SqlDbType.Int,4),
					new SqlParameter("@ImageHeight", SqlDbType.Int,4),
					new SqlParameter("@ImageStatus", SqlDbType.Int,4),
					new SqlParameter("@ImageOrder", SqlDbType.Int,4),
					new SqlParameter("@ImageIsMain", SqlDbType.Int,4),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@ImageType", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ImageDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@ImageDownCount", SqlDbType.Int,4),
					new SqlParameter("@ImageDisplayCount", SqlDbType.Int,4),
					new SqlParameter("@PropertyNames", SqlDbType.NText),
					new SqlParameter("@PropertyValues", SqlDbType.NText)};
            parameters[0].Value = model.ImageID;
            parameters[1].Value = model.ImageGuid;
            parameters[2].Value = model.ImageName;
            parameters[3].Value = model.RelativeGuid;
            parameters[4].Value = model.ImageCategoryCode;
            parameters[5].Value = model.ImageKind;
            parameters[6].Value = model.OwnerGuid;
            parameters[7].Value = model.ImageRelativePath;
            parameters[8].Value = model.ImageSize;
            parameters[9].Value = model.ImageWidth;
            parameters[10].Value = model.ImageHeight;
            parameters[11].Value = model.ImageStatus;
            parameters[12].Value = model.ImageOrder;
            parameters[13].Value = model.ImageIsMain;
            parameters[14].Value = model.CanUsable;
            parameters[15].Value = model.ImageType;
            parameters[16].Value = model.CreateTime;
            parameters[17].Value = model.ImageDescription;
            parameters[18].Value = model.ImageDownCount;
            parameters[19].Value = model.ImageDisplayCount;
            parameters[20].Value = model.PropertyNames;
            parameters[21].Value = model.PropertyValues;

            DbHelperSQL.RunProcedure("GeneralImage_Update", parameters, out rowsAffected);
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
        public bool Delete(int ImageID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ImageID", SqlDbType.Int,4)
			};
            parameters[0].Value = ImageID;

            DbHelperSQL.RunProcedure("GeneralImage_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string ImageIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GeneralImage ");
            strSql.Append(" where ImageID in (" + ImageIDlist + ")  ");
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
        public zlzw.Model.GeneralImageModel GetModel(int ImageID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ImageID", SqlDbType.Int,4)
			};
            parameters[0].Value = ImageID;

            zlzw.Model.GeneralImageModel model = new zlzw.Model.GeneralImageModel();
            DataSet ds = DbHelperSQL.RunProcedure("GeneralImage_GetModel", parameters, "ds");
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
        public zlzw.Model.GeneralImageModel DataRowToModel(DataRow row)
        {
            zlzw.Model.GeneralImageModel model = new zlzw.Model.GeneralImageModel();
            if (row != null)
            {
                if (row["ImageID"] != null && row["ImageID"].ToString() != "")
                {
                    model.ImageID = int.Parse(row["ImageID"].ToString());
                }
                if (row["ImageGuid"] != null && row["ImageGuid"].ToString() != "")
                {
                    model.ImageGuid = new Guid(row["ImageGuid"].ToString());
                }
                if (row["ImageName"] != null)
                {
                    model.ImageName = row["ImageName"].ToString();
                }
                if (row["RelativeGuid"] != null && row["RelativeGuid"].ToString() != "")
                {
                    model.RelativeGuid = new Guid(row["RelativeGuid"].ToString());
                }
                if (row["ImageCategoryCode"] != null)
                {
                    model.ImageCategoryCode = row["ImageCategoryCode"].ToString();
                }
                if (row["ImageKind"] != null)
                {
                    model.ImageKind = row["ImageKind"].ToString();
                }
                if (row["OwnerGuid"] != null && row["OwnerGuid"].ToString() != "")
                {
                    model.OwnerGuid = new Guid(row["OwnerGuid"].ToString());
                }
                if (row["ImageRelativePath"] != null)
                {
                    model.ImageRelativePath = row["ImageRelativePath"].ToString();
                }
                if (row["ImageSize"] != null && row["ImageSize"].ToString() != "")
                {
                    model.ImageSize = int.Parse(row["ImageSize"].ToString());
                }
                if (row["ImageWidth"] != null && row["ImageWidth"].ToString() != "")
                {
                    model.ImageWidth = int.Parse(row["ImageWidth"].ToString());
                }
                if (row["ImageHeight"] != null && row["ImageHeight"].ToString() != "")
                {
                    model.ImageHeight = int.Parse(row["ImageHeight"].ToString());
                }
                if (row["ImageStatus"] != null && row["ImageStatus"].ToString() != "")
                {
                    model.ImageStatus = int.Parse(row["ImageStatus"].ToString());
                }
                if (row["ImageOrder"] != null && row["ImageOrder"].ToString() != "")
                {
                    model.ImageOrder = int.Parse(row["ImageOrder"].ToString());
                }
                if (row["ImageIsMain"] != null && row["ImageIsMain"].ToString() != "")
                {
                    model.ImageIsMain = int.Parse(row["ImageIsMain"].ToString());
                }
                if (row["CanUsable"] != null && row["CanUsable"].ToString() != "")
                {
                    model.CanUsable = int.Parse(row["CanUsable"].ToString());
                }
                if (row["ImageType"] != null)
                {
                    model.ImageType = row["ImageType"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["ImageDescription"] != null)
                {
                    model.ImageDescription = row["ImageDescription"].ToString();
                }
                if (row["ImageDownCount"] != null && row["ImageDownCount"].ToString() != "")
                {
                    model.ImageDownCount = int.Parse(row["ImageDownCount"].ToString());
                }
                if (row["ImageDisplayCount"] != null && row["ImageDisplayCount"].ToString() != "")
                {
                    model.ImageDisplayCount = int.Parse(row["ImageDisplayCount"].ToString());
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
            strSql.Append("select ImageID,ImageGuid,ImageName,RelativeGuid,ImageCategoryCode,ImageKind,OwnerGuid,ImageRelativePath,ImageSize,ImageWidth,ImageHeight,ImageStatus,ImageOrder,ImageIsMain,CanUsable,ImageType,CreateTime,ImageDescription,ImageDownCount,ImageDisplayCount,PropertyNames,PropertyValues ");
            strSql.Append(" FROM GeneralImage ");
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
            strSql.Append(" ImageID,ImageGuid,ImageName,RelativeGuid,ImageCategoryCode,ImageKind,OwnerGuid,ImageRelativePath,ImageSize,ImageWidth,ImageHeight,ImageStatus,ImageOrder,ImageIsMain,CanUsable,ImageType,CreateTime,ImageDescription,ImageDownCount,ImageDisplayCount,PropertyNames,PropertyValues ");
            strSql.Append(" FROM GeneralImage ");
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
            strSql.Append("select count(1) FROM GeneralImage ");
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
                strSql.Append("order by T.ImageID desc");
            }
            strSql.Append(")AS Row, T.*  from GeneralImage T ");
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
            parameters[0].Value = "GeneralImage";
            parameters[1].Value = "ImageID";
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
            parameters[0].Value = "GeneralImage";
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