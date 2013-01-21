using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
	/// <summary>
	/// 数据访问类:JobPersonResumeDAL
	/// </summary>
	public partial class JobPersonResumeDAL
	{
		public JobPersonResumeDAL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ResumeID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ResumeID", SqlDbType.Int,4)
			};
			parameters[0].Value = ResumeID;

			int result= DbHelperSQL.RunProcedure("JobPersonResume_Exists",parameters,out rowsAffected);
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
		public int Add(zlzw.Model.JobPersonResumeModel model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ResumeID", SqlDbType.Int,4),
					new SqlParameter("@ResumeGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ResumeStatus", SqlDbType.Int,4),
					new SqlParameter("@ResumeName", SqlDbType.NVarChar,50),
					new SqlParameter("@OwnerUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@OwnerUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkExperienceYears", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@RefreshDate", SqlDbType.DateTime),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@SelfEvaluate", SqlDbType.NVarChar,2000),
					new SqlParameter("@JobWorkType", SqlDbType.Int,4),
					new SqlParameter("@JobWorkPlaceKeys", SqlDbType.NVarChar,200),
					new SqlParameter("@JobWorkPlaceNames", SqlDbType.NVarChar,200),
					new SqlParameter("@JobFeildTypes", SqlDbType.NVarChar,200),
					new SqlParameter("@JobFeildKinds", SqlDbType.NVarChar,200),
					new SqlParameter("@JobPositionTypes", SqlDbType.NVarChar,200),
					new SqlParameter("@JobPositionKinds", SqlDbType.NVarChar,200),
					new SqlParameter("@JobSalary", SqlDbType.Int,4),
					new SqlParameter("@JobCurrentWorkStatus", SqlDbType.Int,4),
					new SqlParameter("@ResumeType", SqlDbType.Int,4),
					new SqlParameter("@ResumeKind", SqlDbType.NVarChar,50),
					new SqlParameter("@EducationExperience", SqlDbType.NVarChar,-1),
					new SqlParameter("@WorkExperience", SqlDbType.NVarChar,-1),
					new SqlParameter("@HopeJob", SqlDbType.NVarChar,200),
					new SqlParameter("@HopeRoomAndBoard", SqlDbType.Int,4),
					new SqlParameter("@PersonalSkills", SqlDbType.NVarChar,200),
					new SqlParameter("@SkillsCertificate", SqlDbType.NVarChar,200),
					new SqlParameter("@CurrentSalary", SqlDbType.NVarChar,50),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = model.ResumeStatus;
			parameters[3].Value = model.ResumeName;
			parameters[4].Value = model.OwnerUserKey;
			parameters[5].Value = model.OwnerUserName;
			parameters[6].Value = model.WorkExperienceYears;
			parameters[7].Value = model.CreateDate;
			parameters[8].Value = model.UpdateDate;
			parameters[9].Value = model.RefreshDate;
			parameters[10].Value = model.CanUsable;
			parameters[11].Value = model.SelfEvaluate;
			parameters[12].Value = model.JobWorkType;
			parameters[13].Value = model.JobWorkPlaceKeys;
			parameters[14].Value = model.JobWorkPlaceNames;
			parameters[15].Value = model.JobFeildTypes;
			parameters[16].Value = model.JobFeildKinds;
			parameters[17].Value = model.JobPositionTypes;
			parameters[18].Value = model.JobPositionKinds;
			parameters[19].Value = model.JobSalary;
			parameters[20].Value = model.JobCurrentWorkStatus;
			parameters[21].Value = model.ResumeType;
			parameters[22].Value = model.ResumeKind;
			parameters[23].Value = model.EducationExperience;
			parameters[24].Value = model.WorkExperience;
			parameters[25].Value = model.HopeJob;
			parameters[26].Value = model.HopeRoomAndBoard;
			parameters[27].Value = model.PersonalSkills;
			parameters[28].Value = model.SkillsCertificate;
			parameters[29].Value = model.CurrentSalary;
			parameters[30].Value = model.PropertyNames;
			parameters[31].Value = model.PropertyValues;

			DbHelperSQL.RunProcedure("JobPersonResume_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(zlzw.Model.JobPersonResumeModel model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@ResumeID", SqlDbType.Int,4),
					new SqlParameter("@ResumeGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ResumeStatus", SqlDbType.Int,4),
					new SqlParameter("@ResumeName", SqlDbType.NVarChar,50),
					new SqlParameter("@OwnerUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@OwnerUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkExperienceYears", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@RefreshDate", SqlDbType.DateTime),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@SelfEvaluate", SqlDbType.NVarChar,2000),
					new SqlParameter("@JobWorkType", SqlDbType.Int,4),
					new SqlParameter("@JobWorkPlaceKeys", SqlDbType.NVarChar,200),
					new SqlParameter("@JobWorkPlaceNames", SqlDbType.NVarChar,200),
					new SqlParameter("@JobFeildTypes", SqlDbType.NVarChar,200),
					new SqlParameter("@JobFeildKinds", SqlDbType.NVarChar,200),
					new SqlParameter("@JobPositionTypes", SqlDbType.NVarChar,200),
					new SqlParameter("@JobPositionKinds", SqlDbType.NVarChar,200),
					new SqlParameter("@JobSalary", SqlDbType.Int,4),
					new SqlParameter("@JobCurrentWorkStatus", SqlDbType.Int,4),
					new SqlParameter("@ResumeType", SqlDbType.Int,4),
					new SqlParameter("@ResumeKind", SqlDbType.NVarChar,50),
					new SqlParameter("@EducationExperience", SqlDbType.NVarChar,-1),
					new SqlParameter("@WorkExperience", SqlDbType.NVarChar,-1),
					new SqlParameter("@HopeJob", SqlDbType.NVarChar,200),
					new SqlParameter("@HopeRoomAndBoard", SqlDbType.Int,4),
					new SqlParameter("@PersonalSkills", SqlDbType.NVarChar,200),
					new SqlParameter("@SkillsCertificate", SqlDbType.NVarChar,200),
					new SqlParameter("@CurrentSalary", SqlDbType.NVarChar,50),
					new SqlParameter("@PropertyNames", SqlDbType.NVarChar,-1),
					new SqlParameter("@PropertyValues", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.ResumeID;
			parameters[1].Value = model.ResumeGuid;
			parameters[2].Value = model.ResumeStatus;
			parameters[3].Value = model.ResumeName;
			parameters[4].Value = model.OwnerUserKey;
			parameters[5].Value = model.OwnerUserName;
			parameters[6].Value = model.WorkExperienceYears;
			parameters[7].Value = model.CreateDate;
			parameters[8].Value = model.UpdateDate;
			parameters[9].Value = model.RefreshDate;
			parameters[10].Value = model.CanUsable;
			parameters[11].Value = model.SelfEvaluate;
			parameters[12].Value = model.JobWorkType;
			parameters[13].Value = model.JobWorkPlaceKeys;
			parameters[14].Value = model.JobWorkPlaceNames;
			parameters[15].Value = model.JobFeildTypes;
			parameters[16].Value = model.JobFeildKinds;
			parameters[17].Value = model.JobPositionTypes;
			parameters[18].Value = model.JobPositionKinds;
			parameters[19].Value = model.JobSalary;
			parameters[20].Value = model.JobCurrentWorkStatus;
			parameters[21].Value = model.ResumeType;
			parameters[22].Value = model.ResumeKind;
			parameters[23].Value = model.EducationExperience;
			parameters[24].Value = model.WorkExperience;
			parameters[25].Value = model.HopeJob;
			parameters[26].Value = model.HopeRoomAndBoard;
			parameters[27].Value = model.PersonalSkills;
			parameters[28].Value = model.SkillsCertificate;
			parameters[29].Value = model.CurrentSalary;
			parameters[30].Value = model.PropertyNames;
			parameters[31].Value = model.PropertyValues;

			DbHelperSQL.RunProcedure("JobPersonResume_Update",parameters,out rowsAffected);
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
		public bool Delete(int ResumeID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@ResumeID", SqlDbType.Int,4)
			};
			parameters[0].Value = ResumeID;

			DbHelperSQL.RunProcedure("JobPersonResume_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string ResumeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from JobPersonResume ");
			strSql.Append(" where ResumeID in ("+ResumeIDlist + ")  ");
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
		public zlzw.Model.JobPersonResumeModel GetModel(int ResumeID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@ResumeID", SqlDbType.Int,4)
			};
			parameters[0].Value = ResumeID;

			zlzw.Model.JobPersonResumeModel model=new zlzw.Model.JobPersonResumeModel();
			DataSet ds= DbHelperSQL.RunProcedure("JobPersonResume_GetModel",parameters,"ds");
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
		public zlzw.Model.JobPersonResumeModel DataRowToModel(DataRow row)
		{
			zlzw.Model.JobPersonResumeModel model=new zlzw.Model.JobPersonResumeModel();
			if (row != null)
			{
				if(row["ResumeID"]!=null && row["ResumeID"].ToString()!="")
				{
					model.ResumeID=int.Parse(row["ResumeID"].ToString());
				}
				if(row["ResumeGuid"]!=null && row["ResumeGuid"].ToString()!="")
				{
					model.ResumeGuid= new Guid(row["ResumeGuid"].ToString());
				}
				if(row["ResumeStatus"]!=null && row["ResumeStatus"].ToString()!="")
				{
					model.ResumeStatus=int.Parse(row["ResumeStatus"].ToString());
				}
				if(row["ResumeName"]!=null)
				{
					model.ResumeName=row["ResumeName"].ToString();
				}
				if(row["OwnerUserKey"]!=null)
				{
					model.OwnerUserKey=row["OwnerUserKey"].ToString();
				}
				if(row["OwnerUserName"]!=null)
				{
					model.OwnerUserName=row["OwnerUserName"].ToString();
				}
				if(row["WorkExperienceYears"]!=null && row["WorkExperienceYears"].ToString()!="")
				{
					model.WorkExperienceYears=int.Parse(row["WorkExperienceYears"].ToString());
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
				if(row["SelfEvaluate"]!=null)
				{
					model.SelfEvaluate=row["SelfEvaluate"].ToString();
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
				if(row["JobCurrentWorkStatus"]!=null && row["JobCurrentWorkStatus"].ToString()!="")
				{
					model.JobCurrentWorkStatus=int.Parse(row["JobCurrentWorkStatus"].ToString());
				}
				if(row["ResumeType"]!=null && row["ResumeType"].ToString()!="")
				{
					model.ResumeType=int.Parse(row["ResumeType"].ToString());
				}
				if(row["ResumeKind"]!=null)
				{
					model.ResumeKind=row["ResumeKind"].ToString();
				}
				if(row["EducationExperience"]!=null)
				{
					model.EducationExperience=row["EducationExperience"].ToString();
				}
				if(row["WorkExperience"]!=null)
				{
					model.WorkExperience=row["WorkExperience"].ToString();
				}
				if(row["HopeJob"]!=null)
				{
					model.HopeJob=row["HopeJob"].ToString();
				}
				if(row["HopeRoomAndBoard"]!=null && row["HopeRoomAndBoard"].ToString()!="")
				{
					model.HopeRoomAndBoard=int.Parse(row["HopeRoomAndBoard"].ToString());
				}
				if(row["PersonalSkills"]!=null)
				{
					model.PersonalSkills=row["PersonalSkills"].ToString();
				}
				if(row["SkillsCertificate"]!=null)
				{
					model.SkillsCertificate=row["SkillsCertificate"].ToString();
				}
				if(row["CurrentSalary"]!=null)
				{
					model.CurrentSalary=row["CurrentSalary"].ToString();
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
			strSql.Append("select ResumeID,ResumeGuid,ResumeStatus,ResumeName,OwnerUserKey,OwnerUserName,WorkExperienceYears,CreateDate,UpdateDate,RefreshDate,CanUsable,SelfEvaluate,JobWorkType,JobWorkPlaceKeys,JobWorkPlaceNames,JobFeildTypes,JobFeildKinds,JobPositionTypes,JobPositionKinds,JobSalary,JobCurrentWorkStatus,ResumeType,ResumeKind,EducationExperience,WorkExperience,HopeJob,HopeRoomAndBoard,PersonalSkills,SkillsCertificate,CurrentSalary,PropertyNames,PropertyValues ");
			strSql.Append(" FROM JobPersonResume ");
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
			strSql.Append(" ResumeID,ResumeGuid,ResumeStatus,ResumeName,OwnerUserKey,OwnerUserName,WorkExperienceYears,CreateDate,UpdateDate,RefreshDate,CanUsable,SelfEvaluate,JobWorkType,JobWorkPlaceKeys,JobWorkPlaceNames,JobFeildTypes,JobFeildKinds,JobPositionTypes,JobPositionKinds,JobSalary,JobCurrentWorkStatus,ResumeType,ResumeKind,EducationExperience,WorkExperience,HopeJob,HopeRoomAndBoard,PersonalSkills,SkillsCertificate,CurrentSalary,PropertyNames,PropertyValues ");
			strSql.Append(" FROM JobPersonResume ");
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
			strSql.Append("select count(1) FROM JobPersonResume ");
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
				strSql.Append("order by T.ResumeID desc");
			}
			strSql.Append(")AS Row, T.*  from JobPersonResume T ");
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
			parameters[0].Value = "JobPersonResume";
			parameters[1].Value = "ResumeID";
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
            parameters[0].Value = "JobPersonResume";
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