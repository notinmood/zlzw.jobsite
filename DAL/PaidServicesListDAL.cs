using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
	/// <summary>
	/// 数据访问类:PaidServicesListDAL
	/// </summary>
	public partial class PaidServicesListDAL
	{
		public PaidServicesListDAL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PaidServicesID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@PaidServicesID", SqlDbType.Int,4)
			};
			parameters[0].Value = PaidServicesID;

			int result= DbHelperSQL.RunProcedure("PaidServicesList_Exists",parameters,out rowsAffected);
			if(result==1)
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
		public int Add(zlzw.Model.PaidServicesListModel model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@PaidServicesID", SqlDbType.Int,4),
					new SqlParameter("@PaidServicesGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@PublishJobCount", SqlDbType.Int,4),
					new SqlParameter("@PublishJobPrice", SqlDbType.Float,8),
					new SqlParameter("@MainResumeCount", SqlDbType.Int,4),
					new SqlParameter("@MainResumePrice", SqlDbType.Float,8),
					new SqlParameter("@SearchStrangeResumeCount", SqlDbType.Int,4),
					new SqlParameter("@SearchStrangeResumePrice", SqlDbType.Float,8),
					new SqlParameter("@DownloadStrangeResumeCount", SqlDbType.Int,4),
					new SqlParameter("@DownloadStrangeResumePrice", SqlDbType.Float,8),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@PublishID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@JobAdLargePrice", SqlDbType.Float,8),
					new SqlParameter("@JobAdSmallPrice", SqlDbType.Float,8),
					new SqlParameter("@EmergencyRecruitmentPrice", SqlDbType.Float,8),
					new SqlParameter("@Other01", SqlDbType.NVarChar,50),
					new SqlParameter("@Other02", SqlDbType.NChar,10),
					new SqlParameter("@Other03", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = model.PublishJobCount;
			parameters[3].Value = model.PublishJobPrice;
			parameters[4].Value = model.MainResumeCount;
			parameters[5].Value = model.MainResumePrice;
			parameters[6].Value = model.SearchStrangeResumeCount;
			parameters[7].Value = model.SearchStrangeResumePrice;
			parameters[8].Value = model.DownloadStrangeResumeCount;
			parameters[9].Value = model.DownloadStrangeResumePrice;
			parameters[10].Value = model.PublishDate;
            parameters[11].Value = model.PublishID;
			parameters[12].Value = model.JobAdLargePrice;
			parameters[13].Value = model.JobAdSmallPrice;
			parameters[14].Value = model.EmergencyRecruitmentPrice;
			parameters[15].Value = model.Other01;
			parameters[16].Value = model.Other02;
			parameters[17].Value = model.Other03;

			DbHelperSQL.RunProcedure("PaidServicesList_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(zlzw.Model.PaidServicesListModel model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@PaidServicesID", SqlDbType.Int,4),
					new SqlParameter("@PaidServicesGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@PublishJobCount", SqlDbType.Int,4),
					new SqlParameter("@PublishJobPrice", SqlDbType.Float,8),
					new SqlParameter("@MainResumeCount", SqlDbType.Int,4),
					new SqlParameter("@MainResumePrice", SqlDbType.Float,8),
					new SqlParameter("@SearchStrangeResumeCount", SqlDbType.Int,4),
					new SqlParameter("@SearchStrangeResumePrice", SqlDbType.Float,8),
					new SqlParameter("@DownloadStrangeResumeCount", SqlDbType.Int,4),
					new SqlParameter("@DownloadStrangeResumePrice", SqlDbType.Float,8),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@PublishID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@JobAdLargePrice", SqlDbType.Float,8),
					new SqlParameter("@JobAdSmallPrice", SqlDbType.Float,8),
					new SqlParameter("@EmergencyRecruitmentPrice", SqlDbType.Float,8),
					new SqlParameter("@Other01", SqlDbType.NVarChar,50),
					new SqlParameter("@Other02", SqlDbType.NChar,10),
					new SqlParameter("@Other03", SqlDbType.Int,4)};
			parameters[0].Value = model.PaidServicesID;
			parameters[1].Value = model.PaidServicesGUID;
			parameters[2].Value = model.PublishJobCount;
			parameters[3].Value = model.PublishJobPrice;
			parameters[4].Value = model.MainResumeCount;
			parameters[5].Value = model.MainResumePrice;
			parameters[6].Value = model.SearchStrangeResumeCount;
			parameters[7].Value = model.SearchStrangeResumePrice;
			parameters[8].Value = model.DownloadStrangeResumeCount;
			parameters[9].Value = model.DownloadStrangeResumePrice;
			parameters[10].Value = model.PublishDate;
			parameters[11].Value = model.PublishID;
			parameters[12].Value = model.JobAdLargePrice;
			parameters[13].Value = model.JobAdSmallPrice;
			parameters[14].Value = model.EmergencyRecruitmentPrice;
			parameters[15].Value = model.Other01;
			parameters[16].Value = model.Other02;
			parameters[17].Value = model.Other03;

			DbHelperSQL.RunProcedure("PaidServicesList_Update",parameters,out rowsAffected);
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
		public bool Delete(int PaidServicesID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@PaidServicesID", SqlDbType.Int,4)
			};
			parameters[0].Value = PaidServicesID;

			DbHelperSQL.RunProcedure("PaidServicesList_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string PaidServicesIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PaidServicesList ");
			strSql.Append(" where PaidServicesID in ("+PaidServicesIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public zlzw.Model.PaidServicesListModel GetModel(int PaidServicesID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@PaidServicesID", SqlDbType.Int,4)
			};
			parameters[0].Value = PaidServicesID;

			zlzw.Model.PaidServicesListModel model=new zlzw.Model.PaidServicesListModel();
			DataSet ds= DbHelperSQL.RunProcedure("PaidServicesList_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
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
		public zlzw.Model.PaidServicesListModel DataRowToModel(DataRow row)
		{
			zlzw.Model.PaidServicesListModel model=new zlzw.Model.PaidServicesListModel();
			if (row != null)
			{
				if(row["PaidServicesID"]!=null && row["PaidServicesID"].ToString()!="")
				{
					model.PaidServicesID=int.Parse(row["PaidServicesID"].ToString());
				}
				if(row["PaidServicesGUID"]!=null && row["PaidServicesGUID"].ToString()!="")
				{
					model.PaidServicesGUID= new Guid(row["PaidServicesGUID"].ToString());
				}
				if(row["PublishJobCount"]!=null && row["PublishJobCount"].ToString()!="")
				{
					model.PublishJobCount=int.Parse(row["PublishJobCount"].ToString());
				}
				if(row["PublishJobPrice"]!=null && row["PublishJobPrice"].ToString()!="")
				{
					model.PublishJobPrice=decimal.Parse(row["PublishJobPrice"].ToString());
				}
				if(row["MainResumeCount"]!=null && row["MainResumeCount"].ToString()!="")
				{
					model.MainResumeCount=int.Parse(row["MainResumeCount"].ToString());
				}
				if(row["MainResumePrice"]!=null && row["MainResumePrice"].ToString()!="")
				{
					model.MainResumePrice=decimal.Parse(row["MainResumePrice"].ToString());
				}
				if(row["SearchStrangeResumeCount"]!=null && row["SearchStrangeResumeCount"].ToString()!="")
				{
					model.SearchStrangeResumeCount=int.Parse(row["SearchStrangeResumeCount"].ToString());
				}
				if(row["SearchStrangeResumePrice"]!=null && row["SearchStrangeResumePrice"].ToString()!="")
				{
					model.SearchStrangeResumePrice=decimal.Parse(row["SearchStrangeResumePrice"].ToString());
				}
				if(row["DownloadStrangeResumeCount"]!=null && row["DownloadStrangeResumeCount"].ToString()!="")
				{
					model.DownloadStrangeResumeCount=int.Parse(row["DownloadStrangeResumeCount"].ToString());
				}
				if(row["DownloadStrangeResumePrice"]!=null && row["DownloadStrangeResumePrice"].ToString()!="")
				{
					model.DownloadStrangeResumePrice=decimal.Parse(row["DownloadStrangeResumePrice"].ToString());
				}
				if(row["PublishDate"]!=null && row["PublishDate"].ToString()!="")
				{
					model.PublishDate=DateTime.Parse(row["PublishDate"].ToString());
				}
				if(row["PublishID"]!=null && row["PublishID"].ToString()!="")
				{
					model.PublishID= new Guid(row["PublishID"].ToString());
				}
				if(row["JobAdLargePrice"]!=null && row["JobAdLargePrice"].ToString()!="")
				{
					model.JobAdLargePrice=decimal.Parse(row["JobAdLargePrice"].ToString());
				}
				if(row["JobAdSmallPrice"]!=null && row["JobAdSmallPrice"].ToString()!="")
				{
					model.JobAdSmallPrice=decimal.Parse(row["JobAdSmallPrice"].ToString());
				}
				if(row["EmergencyRecruitmentPrice"]!=null && row["EmergencyRecruitmentPrice"].ToString()!="")
				{
					model.EmergencyRecruitmentPrice=decimal.Parse(row["EmergencyRecruitmentPrice"].ToString());
				}
				if(row["Other01"]!=null)
				{
					model.Other01=row["Other01"].ToString();
				}
				if(row["Other02"]!=null)
				{
					model.Other02=row["Other02"].ToString();
				}
				if(row["Other03"]!=null && row["Other03"].ToString()!="")
				{
					model.Other03=int.Parse(row["Other03"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PaidServicesID,PaidServicesGUID,PublishJobCount,PublishJobPrice,MainResumeCount,MainResumePrice,SearchStrangeResumeCount,SearchStrangeResumePrice,DownloadStrangeResumeCount,DownloadStrangeResumePrice,PublishDate,PublishID,JobAdLargePrice,JobAdSmallPrice,EmergencyRecruitmentPrice,Other01,Other02,Other03 ");
			strSql.Append(" FROM PaidServicesList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" PaidServicesID,PaidServicesGUID,PublishJobCount,PublishJobPrice,MainResumeCount,MainResumePrice,SearchStrangeResumeCount,SearchStrangeResumePrice,DownloadStrangeResumeCount,DownloadStrangeResumePrice,PublishDate,PublishID,JobAdLargePrice,JobAdSmallPrice,EmergencyRecruitmentPrice,Other01,Other02,Other03 ");
			strSql.Append(" FROM PaidServicesList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM PaidServicesList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.PaidServicesID desc");
			}
			strSql.Append(")AS Row, T.*  from PaidServicesList T ");
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
			parameters[0].Value = "PaidServicesList";
			parameters[1].Value = "PaidServicesID";
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
            parameters[0].Value = "PaidServicesList";
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