using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
	/// <summary>
	/// 数据访问类:JobEnterpriseJobPositionDAL
	/// </summary>
	public partial class JobEnterpriseJobPositionDAL
	{
		public JobEnterpriseJobPositionDAL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int JobPositionID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@JobPositionID", SqlDbType.Int,4)
			};
			parameters[0].Value = JobPositionID;

			int result= DbHelperSQL.RunProcedure("JobEnterpriseJobPosition_Exists",parameters,out rowsAffected);
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
		public int Add(zlzw.Model.JobEnterpriseJobPositionModel model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@JobPositionID", SqlDbType.Int,4),
					new SqlParameter("@JobPositionGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@JobPositionStatus", SqlDbType.Int,4),
					new SqlParameter("@JobPositionName", SqlDbType.NVarChar,200),
					new SqlParameter("@SpecialType", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseKey", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseName", SqlDbType.NVarChar,50),
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,50),
					new SqlParameter("@JobPositionType", SqlDbType.Int,4),
					new SqlParameter("@JobPositionKind", SqlDbType.NVarChar,50),
					new SqlParameter("@JobWorkType", SqlDbType.Int,4),
					new SqlParameter("@JobWorkPlaceKeys", SqlDbType.NVarChar,200),
					new SqlParameter("@JobWorkPlaceNames", SqlDbType.NVarChar,200),
					new SqlParameter("@JobFeildTypes", SqlDbType.NVarChar,200),
					new SqlParameter("@JobFeildKinds", SqlDbType.NVarChar,200),
					new SqlParameter("@JobPositionTypes", SqlDbType.NVarChar,200),
					new SqlParameter("@JobPositionKinds", SqlDbType.NVarChar,200),
					new SqlParameter("@JobSalary", SqlDbType.Int,4),
					new SqlParameter("@JobSalaryDetails", SqlDbType.NVarChar,50),
					new SqlParameter("@NeedPersonCount", SqlDbType.Int,4),
					new SqlParameter("@NeedEducation", SqlDbType.Int,4),
					new SqlParameter("@NeedAge", SqlDbType.NVarChar,50),
					new SqlParameter("@NeedSex", SqlDbType.Int,4),
					new SqlParameter("@NeedWorkExperience", SqlDbType.Int,4),
					new SqlParameter("@NeedMangeExperience", SqlDbType.Int,4),
					new SqlParameter("@JobPositionDesc", SqlDbType.NVarChar,-1),
					new SqlParameter("@ContactInformation", SqlDbType.NVarChar,2000),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@ContactTelephone", SqlDbType.NVarChar,50),
					new SqlParameter("@ContactMail", SqlDbType.NVarChar,50),
					new SqlParameter("@JobPositionStartDate", SqlDbType.DateTime),
					new SqlParameter("@JobPositionEndDate", SqlDbType.DateTime),
					new SqlParameter("@BrowseCount", SqlDbType.Int,4),
					new SqlParameter("@ResumeCount", SqlDbType.Int,4),
					new SqlParameter("@CreateUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@RefreshDate", SqlDbType.DateTime),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@InterviewTime", SqlDbType.NVarChar,50),
					new SqlParameter("@InterviewAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@HopeRoomAndBoard", SqlDbType.Int,4),
					new SqlParameter("@ComprehensivePayroll", SqlDbType.NVarChar,200),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = model.JobPositionStatus;
			parameters[3].Value = model.JobPositionName;
			parameters[4].Value = model.SpecialType;
			parameters[5].Value = model.EnterpriseKey;
			parameters[6].Value = model.EnterpriseName;
			parameters[7].Value = model.DepartmentName;
			parameters[8].Value = model.JobPositionType;
			parameters[9].Value = model.JobPositionKind;
			parameters[10].Value = model.JobWorkType;
			parameters[11].Value = model.JobWorkPlaceKeys;
			parameters[12].Value = model.JobWorkPlaceNames;
			parameters[13].Value = model.JobFeildTypes;
			parameters[14].Value = model.JobFeildKinds;
			parameters[15].Value = model.JobPositionTypes;
			parameters[16].Value = model.JobPositionKinds;
			parameters[17].Value = model.JobSalary;
			parameters[18].Value = model.JobSalaryDetails;
			parameters[19].Value = model.NeedPersonCount;
			parameters[20].Value = model.NeedEducation;
			parameters[21].Value = model.NeedAge;
			parameters[22].Value = model.NeedSex;
			parameters[23].Value = model.NeedWorkExperience;
			parameters[24].Value = model.NeedMangeExperience;
			parameters[25].Value = model.JobPositionDesc;
			parameters[26].Value = model.ContactInformation;
			parameters[27].Value = model.ContactPerson;
			parameters[28].Value = model.ContactTelephone;
			parameters[29].Value = model.ContactMail;
			parameters[30].Value = model.JobPositionStartDate;
			parameters[31].Value = model.JobPositionEndDate;
			parameters[32].Value = model.BrowseCount;
			parameters[33].Value = model.ResumeCount;
			parameters[34].Value = model.CreateUserKey;
			parameters[35].Value = model.CreateUserName;
			parameters[36].Value = model.CreateDate;
			parameters[37].Value = model.UpdateDate;
			parameters[38].Value = model.RefreshDate;
			parameters[39].Value = model.CanUsable;
			parameters[40].Value = model.InterviewTime;
			parameters[41].Value = model.InterviewAddress;
			parameters[42].Value = model.HopeRoomAndBoard;
			parameters[43].Value = model.ComprehensivePayroll;
			parameters[44].Value = model.PropertyNames;
			parameters[45].Value = model.PropertyValues;

			DbHelperSQL.RunProcedure("JobEnterpriseJobPosition_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(zlzw.Model.JobEnterpriseJobPositionModel model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@JobPositionID", SqlDbType.Int,4),
					new SqlParameter("@JobPositionGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@JobPositionStatus", SqlDbType.Int,4),
					new SqlParameter("@JobPositionName", SqlDbType.NVarChar,200),
					new SqlParameter("@SpecialType", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseKey", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseName", SqlDbType.NVarChar,50),
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,50),
					new SqlParameter("@JobPositionType", SqlDbType.Int,4),
					new SqlParameter("@JobPositionKind", SqlDbType.NVarChar,50),
					new SqlParameter("@JobWorkType", SqlDbType.Int,4),
					new SqlParameter("@JobWorkPlaceKeys", SqlDbType.NVarChar,200),
					new SqlParameter("@JobWorkPlaceNames", SqlDbType.NVarChar,200),
					new SqlParameter("@JobFeildTypes", SqlDbType.NVarChar,200),
					new SqlParameter("@JobFeildKinds", SqlDbType.NVarChar,200),
					new SqlParameter("@JobPositionTypes", SqlDbType.NVarChar,200),
					new SqlParameter("@JobPositionKinds", SqlDbType.NVarChar,200),
					new SqlParameter("@JobSalary", SqlDbType.Int,4),
					new SqlParameter("@JobSalaryDetails", SqlDbType.NVarChar,50),
					new SqlParameter("@NeedPersonCount", SqlDbType.Int,4),
					new SqlParameter("@NeedEducation", SqlDbType.Int,4),
					new SqlParameter("@NeedAge", SqlDbType.NVarChar,50),
					new SqlParameter("@NeedSex", SqlDbType.Int,4),
					new SqlParameter("@NeedWorkExperience", SqlDbType.Int,4),
					new SqlParameter("@NeedMangeExperience", SqlDbType.Int,4),
					new SqlParameter("@JobPositionDesc", SqlDbType.NVarChar,-1),
					new SqlParameter("@ContactInformation", SqlDbType.NVarChar,2000),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@ContactTelephone", SqlDbType.NVarChar,50),
					new SqlParameter("@ContactMail", SqlDbType.NVarChar,50),
					new SqlParameter("@JobPositionStartDate", SqlDbType.DateTime),
					new SqlParameter("@JobPositionEndDate", SqlDbType.DateTime),
					new SqlParameter("@BrowseCount", SqlDbType.Int,4),
					new SqlParameter("@ResumeCount", SqlDbType.Int,4),
					new SqlParameter("@CreateUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@RefreshDate", SqlDbType.DateTime),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@InterviewTime", SqlDbType.NVarChar,50),
					new SqlParameter("@InterviewAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@HopeRoomAndBoard", SqlDbType.Int,4),
					new SqlParameter("@ComprehensivePayroll", SqlDbType.NVarChar,200),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.JobPositionID;
			parameters[1].Value = model.JobPositionGuid;
			parameters[2].Value = model.JobPositionStatus;
			parameters[3].Value = model.JobPositionName;
			parameters[4].Value = model.SpecialType;
			parameters[5].Value = model.EnterpriseKey;
			parameters[6].Value = model.EnterpriseName;
			parameters[7].Value = model.DepartmentName;
			parameters[8].Value = model.JobPositionType;
			parameters[9].Value = model.JobPositionKind;
			parameters[10].Value = model.JobWorkType;
			parameters[11].Value = model.JobWorkPlaceKeys;
			parameters[12].Value = model.JobWorkPlaceNames;
			parameters[13].Value = model.JobFeildTypes;
			parameters[14].Value = model.JobFeildKinds;
			parameters[15].Value = model.JobPositionTypes;
			parameters[16].Value = model.JobPositionKinds;
			parameters[17].Value = model.JobSalary;
			parameters[18].Value = model.JobSalaryDetails;
			parameters[19].Value = model.NeedPersonCount;
			parameters[20].Value = model.NeedEducation;
			parameters[21].Value = model.NeedAge;
			parameters[22].Value = model.NeedSex;
			parameters[23].Value = model.NeedWorkExperience;
			parameters[24].Value = model.NeedMangeExperience;
			parameters[25].Value = model.JobPositionDesc;
			parameters[26].Value = model.ContactInformation;
			parameters[27].Value = model.ContactPerson;
			parameters[28].Value = model.ContactTelephone;
			parameters[29].Value = model.ContactMail;
			parameters[30].Value = model.JobPositionStartDate;
			parameters[31].Value = model.JobPositionEndDate;
			parameters[32].Value = model.BrowseCount;
			parameters[33].Value = model.ResumeCount;
			parameters[34].Value = model.CreateUserKey;
			parameters[35].Value = model.CreateUserName;
			parameters[36].Value = model.CreateDate;
			parameters[37].Value = model.UpdateDate;
			parameters[38].Value = model.RefreshDate;
			parameters[39].Value = model.CanUsable;
			parameters[40].Value = model.InterviewTime;
			parameters[41].Value = model.InterviewAddress;
			parameters[42].Value = model.HopeRoomAndBoard;
			parameters[43].Value = model.ComprehensivePayroll;
			parameters[44].Value = model.PropertyNames;
			parameters[45].Value = model.PropertyValues;

			DbHelperSQL.RunProcedure("JobEnterpriseJobPosition_Update",parameters,out rowsAffected);
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
		public bool Delete(int JobPositionID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@JobPositionID", SqlDbType.Int,4)
			};
			parameters[0].Value = JobPositionID;

			DbHelperSQL.RunProcedure("JobEnterpriseJobPosition_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string JobPositionIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from JobEnterpriseJobPosition ");
			strSql.Append(" where JobPositionID in ("+JobPositionIDlist + ")  ");
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
		public zlzw.Model.JobEnterpriseJobPositionModel GetModel(int JobPositionID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@JobPositionID", SqlDbType.Int,4)
			};
			parameters[0].Value = JobPositionID;

			zlzw.Model.JobEnterpriseJobPositionModel model=new zlzw.Model.JobEnterpriseJobPositionModel();
			DataSet ds= DbHelperSQL.RunProcedure("JobEnterpriseJobPosition_GetModel",parameters,"ds");
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
		public zlzw.Model.JobEnterpriseJobPositionModel DataRowToModel(DataRow row)
		{
			zlzw.Model.JobEnterpriseJobPositionModel model=new zlzw.Model.JobEnterpriseJobPositionModel();
			if (row != null)
			{
				if(row["JobPositionID"]!=null && row["JobPositionID"].ToString()!="")
				{
					model.JobPositionID=int.Parse(row["JobPositionID"].ToString());
				}
				if(row["JobPositionGuid"]!=null && row["JobPositionGuid"].ToString()!="")
				{
					model.JobPositionGuid= new Guid(row["JobPositionGuid"].ToString());
				}
				if(row["JobPositionStatus"]!=null && row["JobPositionStatus"].ToString()!="")
				{
					model.JobPositionStatus=int.Parse(row["JobPositionStatus"].ToString());
				}
				if(row["JobPositionName"]!=null)
				{
					model.JobPositionName=row["JobPositionName"].ToString();
				}
				if(row["SpecialType"]!=null && row["SpecialType"].ToString()!="")
				{
					model.SpecialType=int.Parse(row["SpecialType"].ToString());
				}
				if(row["EnterpriseKey"]!=null)
				{
					model.EnterpriseKey=row["EnterpriseKey"].ToString();
				}
				if(row["EnterpriseName"]!=null)
				{
					model.EnterpriseName=row["EnterpriseName"].ToString();
				}
				if(row["DepartmentName"]!=null)
				{
					model.DepartmentName=row["DepartmentName"].ToString();
				}
				if(row["JobPositionType"]!=null && row["JobPositionType"].ToString()!="")
				{
					model.JobPositionType=int.Parse(row["JobPositionType"].ToString());
				}
				if(row["JobPositionKind"]!=null)
				{
					model.JobPositionKind=row["JobPositionKind"].ToString();
				}
				if(row["JobWorkType"]!=null && row["JobWorkType"].ToString()!="")
				{
					model.JobWorkType=int.Parse(row["JobWorkType"].ToString());
				}
				if(row["JobWorkPlaceKeys"]!=null)
				{
					model.JobWorkPlaceKeys=row["JobWorkPlaceKeys"].ToString();
				}
				if(row["JobWorkPlaceNames"]!=null)
				{
					model.JobWorkPlaceNames=row["JobWorkPlaceNames"].ToString();
				}
				if(row["JobFeildTypes"]!=null)
				{
					model.JobFeildTypes=row["JobFeildTypes"].ToString();
				}
				if(row["JobFeildKinds"]!=null)
				{
					model.JobFeildKinds=row["JobFeildKinds"].ToString();
				}
				if(row["JobPositionTypes"]!=null)
				{
					model.JobPositionTypes=row["JobPositionTypes"].ToString();
				}
				if(row["JobPositionKinds"]!=null)
				{
					model.JobPositionKinds=row["JobPositionKinds"].ToString();
				}
				if(row["JobSalary"]!=null && row["JobSalary"].ToString()!="")
				{
					model.JobSalary=int.Parse(row["JobSalary"].ToString());
				}
				if(row["JobSalaryDetails"]!=null)
				{
					model.JobSalaryDetails=row["JobSalaryDetails"].ToString();
				}
				if(row["NeedPersonCount"]!=null && row["NeedPersonCount"].ToString()!="")
				{
					model.NeedPersonCount=int.Parse(row["NeedPersonCount"].ToString());
				}
				if(row["NeedEducation"]!=null && row["NeedEducation"].ToString()!="")
				{
					model.NeedEducation=int.Parse(row["NeedEducation"].ToString());
				}
				if(row["NeedAge"]!=null)
				{
					model.NeedAge=row["NeedAge"].ToString();
				}
				if(row["NeedSex"]!=null && row["NeedSex"].ToString()!="")
				{
					model.NeedSex=int.Parse(row["NeedSex"].ToString());
				}
				if(row["NeedWorkExperience"]!=null && row["NeedWorkExperience"].ToString()!="")
				{
					model.NeedWorkExperience=int.Parse(row["NeedWorkExperience"].ToString());
				}
				if(row["NeedMangeExperience"]!=null && row["NeedMangeExperience"].ToString()!="")
				{
					model.NeedMangeExperience=int.Parse(row["NeedMangeExperience"].ToString());
				}
				if(row["JobPositionDesc"]!=null)
				{
					model.JobPositionDesc=row["JobPositionDesc"].ToString();
				}
				if(row["ContactInformation"]!=null)
				{
					model.ContactInformation=row["ContactInformation"].ToString();
				}
				if(row["ContactPerson"]!=null)
				{
					model.ContactPerson=row["ContactPerson"].ToString();
				}
				if(row["ContactTelephone"]!=null)
				{
					model.ContactTelephone=row["ContactTelephone"].ToString();
				}
				if(row["ContactMail"]!=null)
				{
					model.ContactMail=row["ContactMail"].ToString();
				}
				if(row["JobPositionStartDate"]!=null && row["JobPositionStartDate"].ToString()!="")
				{
					model.JobPositionStartDate=DateTime.Parse(row["JobPositionStartDate"].ToString());
				}
				if(row["JobPositionEndDate"]!=null && row["JobPositionEndDate"].ToString()!="")
				{
					model.JobPositionEndDate=DateTime.Parse(row["JobPositionEndDate"].ToString());
				}
				if(row["BrowseCount"]!=null && row["BrowseCount"].ToString()!="")
				{
					model.BrowseCount=int.Parse(row["BrowseCount"].ToString());
				}
				if(row["ResumeCount"]!=null && row["ResumeCount"].ToString()!="")
				{
					model.ResumeCount=int.Parse(row["ResumeCount"].ToString());
				}
				if(row["CreateUserKey"]!=null)
				{
					model.CreateUserKey=row["CreateUserKey"].ToString();
				}
				if(row["CreateUserName"]!=null)
				{
					model.CreateUserName=row["CreateUserName"].ToString();
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["UpdateDate"]!=null && row["UpdateDate"].ToString()!="")
				{
					model.UpdateDate=DateTime.Parse(row["UpdateDate"].ToString());
				}
				if(row["RefreshDate"]!=null && row["RefreshDate"].ToString()!="")
				{
					model.RefreshDate=DateTime.Parse(row["RefreshDate"].ToString());
				}
				if(row["CanUsable"]!=null && row["CanUsable"].ToString()!="")
				{
					model.CanUsable=int.Parse(row["CanUsable"].ToString());
				}
				if(row["InterviewTime"]!=null)
				{
					model.InterviewTime=row["InterviewTime"].ToString();
				}
				if(row["InterviewAddress"]!=null)
				{
					model.InterviewAddress=row["InterviewAddress"].ToString();
				}
				if(row["HopeRoomAndBoard"]!=null && row["HopeRoomAndBoard"].ToString()!="")
				{
					model.HopeRoomAndBoard=int.Parse(row["HopeRoomAndBoard"].ToString());
				}
				if(row["ComprehensivePayroll"]!=null)
				{
					model.ComprehensivePayroll=row["ComprehensivePayroll"].ToString();
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
			strSql.Append("select JobPositionID,JobPositionGuid,JobPositionStatus,JobPositionName,SpecialType,EnterpriseKey,EnterpriseName,DepartmentName,JobPositionType,JobPositionKind,JobWorkType,JobWorkPlaceKeys,JobWorkPlaceNames,JobFeildTypes,JobFeildKinds,JobPositionTypes,JobPositionKinds,JobSalary,JobSalaryDetails,NeedPersonCount,NeedEducation,NeedAge,NeedSex,NeedWorkExperience,NeedMangeExperience,JobPositionDesc,ContactInformation,ContactPerson,ContactTelephone,ContactMail,JobPositionStartDate,JobPositionEndDate,BrowseCount,ResumeCount,CreateUserKey,CreateUserName,CreateDate,UpdateDate,RefreshDate,CanUsable,InterviewTime,InterviewAddress,HopeRoomAndBoard,ComprehensivePayroll,PropertyNames,PropertyValues ");
			strSql.Append(" FROM JobEnterpriseJobPosition ");
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
			strSql.Append(" JobPositionID,JobPositionGuid,JobPositionStatus,JobPositionName,SpecialType,EnterpriseKey,EnterpriseName,DepartmentName,JobPositionType,JobPositionKind,JobWorkType,JobWorkPlaceKeys,JobWorkPlaceNames,JobFeildTypes,JobFeildKinds,JobPositionTypes,JobPositionKinds,JobSalary,JobSalaryDetails,NeedPersonCount,NeedEducation,NeedAge,NeedSex,NeedWorkExperience,NeedMangeExperience,JobPositionDesc,ContactInformation,ContactPerson,ContactTelephone,ContactMail,JobPositionStartDate,JobPositionEndDate,BrowseCount,ResumeCount,CreateUserKey,CreateUserName,CreateDate,UpdateDate,RefreshDate,CanUsable,InterviewTime,InterviewAddress,HopeRoomAndBoard,ComprehensivePayroll,PropertyNames,PropertyValues ");
			strSql.Append(" FROM JobEnterpriseJobPosition ");
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
			strSql.Append("select count(1) FROM JobEnterpriseJobPosition ");
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
				strSql.Append("order by T.JobPositionID desc");
			}
			strSql.Append(")AS Row, T.*  from JobEnterpriseJobPosition T ");
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
			parameters[0].Value = "JobEnterpriseJobPosition";
			parameters[1].Value = "JobPositionID";
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
            parameters[0].Value = "JobEnterpriseJobPosition";
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