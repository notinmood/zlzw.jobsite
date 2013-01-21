using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
	/// <summary>
	/// 数据访问类:JobEnterpriseServiceDAL
	/// </summary>
	public partial class JobEnterpriseServiceDAL
	{
		public JobEnterpriseServiceDAL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int EnterpriseServiceID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseServiceID", SqlDbType.Int,4)
			};
			parameters[0].Value = EnterpriseServiceID;

			int result= DbHelperSQL.RunProcedure("JobEnterpriseService_Exists",parameters,out rowsAffected);
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
		public int Add(zlzw.Model.JobEnterpriseServiceModel model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseServiceID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseServiceGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EnterpriseServiceStatus", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseName", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseKey", SqlDbType.NVarChar,50),
					new SqlParameter("@JobPositionPublishAllowCount", SqlDbType.Int,4),
					new SqlParameter("@JobPositionPublishUsedCount", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseServiceCurrentContractKey", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseServiceCurrentContractStartDate", SqlDbType.DateTime),
					new SqlParameter("@EnterpriseServiceCurrentContractEndDate", SqlDbType.DateTime),
					new SqlParameter("@ResumeDownAllowCount", SqlDbType.Int,4),
					new SqlParameter("@ResumeDownUsedCount", SqlDbType.Int,4),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = model.EnterpriseServiceStatus;
			parameters[3].Value = model.EnterpriseName;
			parameters[4].Value = model.EnterpriseKey;
			parameters[5].Value = model.JobPositionPublishAllowCount;
			parameters[6].Value = model.JobPositionPublishUsedCount;
			parameters[7].Value = model.EnterpriseServiceCurrentContractKey;
			parameters[8].Value = model.EnterpriseServiceCurrentContractStartDate;
			parameters[9].Value = model.EnterpriseServiceCurrentContractEndDate;
			parameters[10].Value = model.ResumeDownAllowCount;
			parameters[11].Value = model.ResumeDownUsedCount;
			parameters[12].Value = model.CanUsable;
			parameters[13].Value = model.PublishDate;
			parameters[14].Value = model.PropertyNames;
			parameters[15].Value = model.PropertyValues;

			DbHelperSQL.RunProcedure("JobEnterpriseService_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(zlzw.Model.JobEnterpriseServiceModel model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseServiceID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseServiceGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EnterpriseServiceStatus", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseName", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseKey", SqlDbType.NVarChar,50),
					new SqlParameter("@JobPositionPublishAllowCount", SqlDbType.Int,4),
					new SqlParameter("@JobPositionPublishUsedCount", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseServiceCurrentContractKey", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseServiceCurrentContractStartDate", SqlDbType.DateTime),
					new SqlParameter("@EnterpriseServiceCurrentContractEndDate", SqlDbType.DateTime),
					new SqlParameter("@ResumeDownAllowCount", SqlDbType.Int,4),
					new SqlParameter("@ResumeDownUsedCount", SqlDbType.Int,4),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.EnterpriseServiceID;
			parameters[1].Value = model.EnterpriseServiceGuid;
			parameters[2].Value = model.EnterpriseServiceStatus;
			parameters[3].Value = model.EnterpriseName;
			parameters[4].Value = model.EnterpriseKey;
			parameters[5].Value = model.JobPositionPublishAllowCount;
			parameters[6].Value = model.JobPositionPublishUsedCount;
			parameters[7].Value = model.EnterpriseServiceCurrentContractKey;
			parameters[8].Value = model.EnterpriseServiceCurrentContractStartDate;
			parameters[9].Value = model.EnterpriseServiceCurrentContractEndDate;
			parameters[10].Value = model.ResumeDownAllowCount;
			parameters[11].Value = model.ResumeDownUsedCount;
			parameters[12].Value = model.CanUsable;
			parameters[13].Value = model.PublishDate;
			parameters[14].Value = model.PropertyNames;
			parameters[15].Value = model.PropertyValues;

			DbHelperSQL.RunProcedure("JobEnterpriseService_Update",parameters,out rowsAffected);
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
		public bool Delete(int EnterpriseServiceID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseServiceID", SqlDbType.Int,4)
			};
			parameters[0].Value = EnterpriseServiceID;

			DbHelperSQL.RunProcedure("JobEnterpriseService_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string EnterpriseServiceIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from JobEnterpriseService ");
			strSql.Append(" where EnterpriseServiceID in ("+EnterpriseServiceIDlist + ")  ");
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
		public zlzw.Model.JobEnterpriseServiceModel GetModel(int EnterpriseServiceID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseServiceID", SqlDbType.Int,4)
			};
			parameters[0].Value = EnterpriseServiceID;

			zlzw.Model.JobEnterpriseServiceModel model=new zlzw.Model.JobEnterpriseServiceModel();
			DataSet ds= DbHelperSQL.RunProcedure("JobEnterpriseService_GetModel",parameters,"ds");
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
		public zlzw.Model.JobEnterpriseServiceModel DataRowToModel(DataRow row)
		{
			zlzw.Model.JobEnterpriseServiceModel model=new zlzw.Model.JobEnterpriseServiceModel();
			if (row != null)
			{
				if(row["EnterpriseServiceID"]!=null && row["EnterpriseServiceID"].ToString()!="")
				{
					model.EnterpriseServiceID=int.Parse(row["EnterpriseServiceID"].ToString());
				}
				if(row["EnterpriseServiceGuid"]!=null && row["EnterpriseServiceGuid"].ToString()!="")
				{
					model.EnterpriseServiceGuid= new Guid(row["EnterpriseServiceGuid"].ToString());
				}
				if(row["EnterpriseServiceStatus"]!=null && row["EnterpriseServiceStatus"].ToString()!="")
				{
					model.EnterpriseServiceStatus=int.Parse(row["EnterpriseServiceStatus"].ToString());
				}
				if(row["EnterpriseName"]!=null)
				{
					model.EnterpriseName=row["EnterpriseName"].ToString();
				}
				if(row["EnterpriseKey"]!=null)
				{
					model.EnterpriseKey=row["EnterpriseKey"].ToString();
				}
				if(row["JobPositionPublishAllowCount"]!=null && row["JobPositionPublishAllowCount"].ToString()!="")
				{
					model.JobPositionPublishAllowCount=int.Parse(row["JobPositionPublishAllowCount"].ToString());
				}
				if(row["JobPositionPublishUsedCount"]!=null && row["JobPositionPublishUsedCount"].ToString()!="")
				{
					model.JobPositionPublishUsedCount=int.Parse(row["JobPositionPublishUsedCount"].ToString());
				}
				if(row["EnterpriseServiceCurrentContractKey"]!=null)
				{
					model.EnterpriseServiceCurrentContractKey=row["EnterpriseServiceCurrentContractKey"].ToString();
				}
				if(row["EnterpriseServiceCurrentContractStartDate"]!=null && row["EnterpriseServiceCurrentContractStartDate"].ToString()!="")
				{
					model.EnterpriseServiceCurrentContractStartDate=DateTime.Parse(row["EnterpriseServiceCurrentContractStartDate"].ToString());
				}
				if(row["EnterpriseServiceCurrentContractEndDate"]!=null && row["EnterpriseServiceCurrentContractEndDate"].ToString()!="")
				{
					model.EnterpriseServiceCurrentContractEndDate=DateTime.Parse(row["EnterpriseServiceCurrentContractEndDate"].ToString());
				}
				if(row["ResumeDownAllowCount"]!=null && row["ResumeDownAllowCount"].ToString()!="")
				{
					model.ResumeDownAllowCount=int.Parse(row["ResumeDownAllowCount"].ToString());
				}
				if(row["ResumeDownUsedCount"]!=null && row["ResumeDownUsedCount"].ToString()!="")
				{
					model.ResumeDownUsedCount=int.Parse(row["ResumeDownUsedCount"].ToString());
				}
				if(row["CanUsable"]!=null && row["CanUsable"].ToString()!="")
				{
					model.CanUsable=int.Parse(row["CanUsable"].ToString());
				}
				if(row["PublishDate"]!=null && row["PublishDate"].ToString()!="")
				{
					model.PublishDate=DateTime.Parse(row["PublishDate"].ToString());
				}
				if(row["PropertyNames"]!=null)
				{
					model.PropertyNames=row["PropertyNames"].ToString();
				}
				if(row["PropertyValues"]!=null)
				{
					model.PropertyValues=row["PropertyValues"].ToString();
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
			strSql.Append("select EnterpriseServiceID,EnterpriseServiceGuid,EnterpriseServiceStatus,EnterpriseName,EnterpriseKey,JobPositionPublishAllowCount,JobPositionPublishUsedCount,EnterpriseServiceCurrentContractKey,EnterpriseServiceCurrentContractStartDate,EnterpriseServiceCurrentContractEndDate,ResumeDownAllowCount,ResumeDownUsedCount,CanUsable,PublishDate,PropertyNames,PropertyValues ");
			strSql.Append(" FROM JobEnterpriseService ");
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
			strSql.Append(" EnterpriseServiceID,EnterpriseServiceGuid,EnterpriseServiceStatus,EnterpriseName,EnterpriseKey,JobPositionPublishAllowCount,JobPositionPublishUsedCount,EnterpriseServiceCurrentContractKey,EnterpriseServiceCurrentContractStartDate,EnterpriseServiceCurrentContractEndDate,ResumeDownAllowCount,ResumeDownUsedCount,CanUsable,PublishDate,PropertyNames,PropertyValues ");
			strSql.Append(" FROM JobEnterpriseService ");
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
			strSql.Append("select count(1) FROM JobEnterpriseService ");
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
				strSql.Append("order by T.EnterpriseServiceID desc");
			}
			strSql.Append(")AS Row, T.*  from JobEnterpriseService T ");
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
			parameters[0].Value = "JobEnterpriseService";
			parameters[1].Value = "EnterpriseServiceID";
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
            parameters[0].Value = "JobEnterpriseService";
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