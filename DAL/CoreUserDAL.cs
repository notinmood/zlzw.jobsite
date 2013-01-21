using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
	/// <summary>
	/// 数据访问类:CoreUserDAL
	/// </summary>
	public partial class CoreUserDAL
	{
		public CoreUserDAL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
			parameters[0].Value = UserID;

			int result= DbHelperSQL.RunProcedure("CoreUser_Exists",parameters,out rowsAffected);
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
		public int Add(zlzw.Model.CoreUserModel model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@PasswordEncrytType", SqlDbType.Int,4),
					new SqlParameter("@PasswordEncrytSalt", SqlDbType.NVarChar,50),
					new SqlParameter("@UserNameCN", SqlDbType.NVarChar,50),
					new SqlParameter("@UserNameEN", SqlDbType.NVarChar,50),
					new SqlParameter("@UserNameFirst", SqlDbType.NVarChar,20),
					new SqlParameter("@UserNameLast", SqlDbType.NVarChar,20),
					new SqlParameter("@UserNameMiddle", SqlDbType.NVarChar,20),
					new SqlParameter("@DepartmentID", SqlDbType.Int,4),
					new SqlParameter("@DepartmentGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@DepartmentCode", SqlDbType.NVarChar,20),
					new SqlParameter("@DepartmentUserType", SqlDbType.Int,4),
					new SqlParameter("@UserFullPath", SqlDbType.NVarChar,200),
					new SqlParameter("@AreaCode", SqlDbType.NVarChar,20),
					new SqlParameter("@UserEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@UserStatus", SqlDbType.Int,4),
					new SqlParameter("@UserRemark", SqlDbType.NVarChar,2000),
					new SqlParameter("@UserCardID", SqlDbType.NVarChar,20),
					new SqlParameter("@UserCardIDIssued", SqlDbType.NVarChar,200),
					new SqlParameter("@DriversLicenceNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@DriversLicenceNumberIssued", SqlDbType.NVarChar,200),
					new SqlParameter("@PassportCode", SqlDbType.NVarChar,50),
					new SqlParameter("@PassportCodeIssued", SqlDbType.NVarChar,200),
					new SqlParameter("@UserSex", SqlDbType.Int,4),
					new SqlParameter("@UserBirthDay", SqlDbType.DateTime),
					new SqlParameter("@MaritalStatus", SqlDbType.Int,4),
					new SqlParameter("@UserMobileNO", SqlDbType.NVarChar,50),
					new SqlParameter("@UserRegisterDate", SqlDbType.DateTime),
					new SqlParameter("@UserAgreeDate", SqlDbType.DateTime),
					new SqlParameter("@UserWorkStartDate", SqlDbType.DateTime),
					new SqlParameter("@UserWorkEndDate", SqlDbType.DateTime),
					new SqlParameter("@CompanyMail", SqlDbType.NVarChar,50),
					new SqlParameter("@UserTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPosition", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkTelphone", SqlDbType.NVarChar,50),
					new SqlParameter("@HomeTelephone", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@UserMacAddress", SqlDbType.NVarChar,20),
					new SqlParameter("@UserLastIP", SqlDbType.NVarChar,20),
					new SqlParameter("@UserLastDateTime", SqlDbType.DateTime),
					new SqlParameter("@BrokerKey", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseKey", SqlDbType.NVarChar,50),
					new SqlParameter("@UserHeight", SqlDbType.Decimal,9),
					new SqlParameter("@UserWeight", SqlDbType.Decimal,9),
					new SqlParameter("@UserNation", SqlDbType.NVarChar,50),
					new SqlParameter("@UserCountry", SqlDbType.NVarChar,50),
					new SqlParameter("@UserEducationalBackground", SqlDbType.Int,4),
					new SqlParameter("@UserEducationalSchool", SqlDbType.NVarChar,50),
					new SqlParameter("@SocialSecurityNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@CurrentResidence", SqlDbType.NVarChar,200),
					new SqlParameter("@PropertyNames", SqlDbType.NText),
					new SqlParameter("@PropertyValues", SqlDbType.NText)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.UserCode;
			parameters[4].Value = model.Password;
			parameters[5].Value = model.PasswordEncrytType;
			parameters[6].Value = model.PasswordEncrytSalt;
			parameters[7].Value = model.UserNameCN;
			parameters[8].Value = model.UserNameEN;
			parameters[9].Value = model.UserNameFirst;
			parameters[10].Value = model.UserNameLast;
			parameters[11].Value = model.UserNameMiddle;
			parameters[12].Value = model.DepartmentID;
			parameters[13].Value = Guid.NewGuid();
			parameters[14].Value = model.DepartmentCode;
			parameters[15].Value = model.DepartmentUserType;
			parameters[16].Value = model.UserFullPath;
			parameters[17].Value = model.AreaCode;
			parameters[18].Value = model.UserEmail;
			parameters[19].Value = model.UserType;
			parameters[20].Value = model.UserStatus;
			parameters[21].Value = model.UserRemark;
			parameters[22].Value = model.UserCardID;
			parameters[23].Value = model.UserCardIDIssued;
			parameters[24].Value = model.DriversLicenceNumber;
			parameters[25].Value = model.DriversLicenceNumberIssued;
			parameters[26].Value = model.PassportCode;
			parameters[27].Value = model.PassportCodeIssued;
			parameters[28].Value = model.UserSex;
			parameters[29].Value = model.UserBirthDay;
			parameters[30].Value = model.MaritalStatus;
			parameters[31].Value = model.UserMobileNO;
			parameters[32].Value = model.UserRegisterDate;
			parameters[33].Value = model.UserAgreeDate;
			parameters[34].Value = model.UserWorkStartDate;
			parameters[35].Value = model.UserWorkEndDate;
			parameters[36].Value = model.CompanyMail;
			parameters[37].Value = model.UserTitle;
			parameters[38].Value = model.UserPosition;
			parameters[39].Value = model.WorkTelphone;
			parameters[40].Value = model.HomeTelephone;
			parameters[41].Value = model.UserPhoto;
			parameters[42].Value = model.UserMacAddress;
			parameters[43].Value = model.UserLastIP;
			parameters[44].Value = model.UserLastDateTime;
			parameters[45].Value = model.BrokerKey;
			parameters[46].Value = model.EnterpriseKey;
			parameters[47].Value = model.UserHeight;
			parameters[48].Value = model.UserWeight;
			parameters[49].Value = model.UserNation;
			parameters[50].Value = model.UserCountry;
			parameters[51].Value = model.UserEducationalBackground;
			parameters[52].Value = model.UserEducationalSchool;
			parameters[53].Value = model.SocialSecurityNumber;
			parameters[54].Value = model.CurrentResidence;
			parameters[55].Value = model.PropertyNames;
			parameters[56].Value = model.PropertyValues;

			DbHelperSQL.RunProcedure("CoreUser_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(zlzw.Model.CoreUserModel model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@PasswordEncrytType", SqlDbType.Int,4),
					new SqlParameter("@PasswordEncrytSalt", SqlDbType.NVarChar,50),
					new SqlParameter("@UserNameCN", SqlDbType.NVarChar,50),
					new SqlParameter("@UserNameEN", SqlDbType.NVarChar,50),
					new SqlParameter("@UserNameFirst", SqlDbType.NVarChar,20),
					new SqlParameter("@UserNameLast", SqlDbType.NVarChar,20),
					new SqlParameter("@UserNameMiddle", SqlDbType.NVarChar,20),
					new SqlParameter("@DepartmentID", SqlDbType.Int,4),
					new SqlParameter("@DepartmentGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@DepartmentCode", SqlDbType.NVarChar,20),
					new SqlParameter("@DepartmentUserType", SqlDbType.Int,4),
					new SqlParameter("@UserFullPath", SqlDbType.NVarChar,200),
					new SqlParameter("@AreaCode", SqlDbType.NVarChar,20),
					new SqlParameter("@UserEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@UserStatus", SqlDbType.Int,4),
					new SqlParameter("@UserRemark", SqlDbType.NVarChar,2000),
					new SqlParameter("@UserCardID", SqlDbType.NVarChar,20),
					new SqlParameter("@UserCardIDIssued", SqlDbType.NVarChar,200),
					new SqlParameter("@DriversLicenceNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@DriversLicenceNumberIssued", SqlDbType.NVarChar,200),
					new SqlParameter("@PassportCode", SqlDbType.NVarChar,50),
					new SqlParameter("@PassportCodeIssued", SqlDbType.NVarChar,200),
					new SqlParameter("@UserSex", SqlDbType.Int,4),
					new SqlParameter("@UserBirthDay", SqlDbType.DateTime),
					new SqlParameter("@MaritalStatus", SqlDbType.Int,4),
					new SqlParameter("@UserMobileNO", SqlDbType.NVarChar,50),
					new SqlParameter("@UserRegisterDate", SqlDbType.DateTime),
					new SqlParameter("@UserAgreeDate", SqlDbType.DateTime),
					new SqlParameter("@UserWorkStartDate", SqlDbType.DateTime),
					new SqlParameter("@UserWorkEndDate", SqlDbType.DateTime),
					new SqlParameter("@CompanyMail", SqlDbType.NVarChar,50),
					new SqlParameter("@UserTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPosition", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkTelphone", SqlDbType.NVarChar,50),
					new SqlParameter("@HomeTelephone", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPhoto", SqlDbType.NVarChar,50),
					new SqlParameter("@UserMacAddress", SqlDbType.NVarChar,20),
					new SqlParameter("@UserLastIP", SqlDbType.NVarChar,20),
					new SqlParameter("@UserLastDateTime", SqlDbType.DateTime),
					new SqlParameter("@BrokerKey", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseKey", SqlDbType.NVarChar,50),
					new SqlParameter("@UserHeight", SqlDbType.Decimal,9),
					new SqlParameter("@UserWeight", SqlDbType.Decimal,9),
					new SqlParameter("@UserNation", SqlDbType.NVarChar,50),
					new SqlParameter("@UserCountry", SqlDbType.NVarChar,50),
					new SqlParameter("@UserEducationalBackground", SqlDbType.Int,4),
					new SqlParameter("@UserEducationalSchool", SqlDbType.NVarChar,50),
					new SqlParameter("@SocialSecurityNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@CurrentResidence", SqlDbType.NVarChar,200),
					new SqlParameter("@PropertyNames", SqlDbType.NText),
					new SqlParameter("@PropertyValues", SqlDbType.NText)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.UserGuid;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.UserCode;
			parameters[4].Value = model.Password;
			parameters[5].Value = model.PasswordEncrytType;
			parameters[6].Value = model.PasswordEncrytSalt;
			parameters[7].Value = model.UserNameCN;
			parameters[8].Value = model.UserNameEN;
			parameters[9].Value = model.UserNameFirst;
			parameters[10].Value = model.UserNameLast;
			parameters[11].Value = model.UserNameMiddle;
			parameters[12].Value = model.DepartmentID;
			parameters[13].Value = model.DepartmentGuid;
			parameters[14].Value = model.DepartmentCode;
			parameters[15].Value = model.DepartmentUserType;
			parameters[16].Value = model.UserFullPath;
			parameters[17].Value = model.AreaCode;
			parameters[18].Value = model.UserEmail;
			parameters[19].Value = model.UserType;
			parameters[20].Value = model.UserStatus;
			parameters[21].Value = model.UserRemark;
			parameters[22].Value = model.UserCardID;
			parameters[23].Value = model.UserCardIDIssued;
			parameters[24].Value = model.DriversLicenceNumber;
			parameters[25].Value = model.DriversLicenceNumberIssued;
			parameters[26].Value = model.PassportCode;
			parameters[27].Value = model.PassportCodeIssued;
			parameters[28].Value = model.UserSex;
			parameters[29].Value = model.UserBirthDay;
			parameters[30].Value = model.MaritalStatus;
			parameters[31].Value = model.UserMobileNO;
			parameters[32].Value = model.UserRegisterDate;
			parameters[33].Value = model.UserAgreeDate;
			parameters[34].Value = model.UserWorkStartDate;
			parameters[35].Value = model.UserWorkEndDate;
			parameters[36].Value = model.CompanyMail;
			parameters[37].Value = model.UserTitle;
			parameters[38].Value = model.UserPosition;
			parameters[39].Value = model.WorkTelphone;
			parameters[40].Value = model.HomeTelephone;
			parameters[41].Value = model.UserPhoto;
			parameters[42].Value = model.UserMacAddress;
			parameters[43].Value = model.UserLastIP;
			parameters[44].Value = model.UserLastDateTime;
			parameters[45].Value = model.BrokerKey;
			parameters[46].Value = model.EnterpriseKey;
			parameters[47].Value = model.UserHeight;
			parameters[48].Value = model.UserWeight;
			parameters[49].Value = model.UserNation;
			parameters[50].Value = model.UserCountry;
			parameters[51].Value = model.UserEducationalBackground;
			parameters[52].Value = model.UserEducationalSchool;
			parameters[53].Value = model.SocialSecurityNumber;
			parameters[54].Value = model.CurrentResidence;
			parameters[55].Value = model.PropertyNames;
			parameters[56].Value = model.PropertyValues;

			DbHelperSQL.RunProcedure("CoreUser_Update",parameters,out rowsAffected);
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
		public bool Delete(int UserID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
			parameters[0].Value = UserID;

			DbHelperSQL.RunProcedure("CoreUser_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CoreUser ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
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
		public zlzw.Model.CoreUserModel GetModel(int UserID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
			parameters[0].Value = UserID;

			zlzw.Model.CoreUserModel model=new zlzw.Model.CoreUserModel();
			DataSet ds= DbHelperSQL.RunProcedure("CoreUser_GetModel",parameters,"ds");
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
		public zlzw.Model.CoreUserModel DataRowToModel(DataRow row)
		{
			zlzw.Model.CoreUserModel model=new zlzw.Model.CoreUserModel();
			if (row != null)
			{
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["UserGuid"]!=null && row["UserGuid"].ToString()!="")
				{
					model.UserGuid= new Guid(row["UserGuid"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserCode"]!=null)
				{
					model.UserCode=row["UserCode"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["PasswordEncrytType"]!=null && row["PasswordEncrytType"].ToString()!="")
				{
					model.PasswordEncrytType=int.Parse(row["PasswordEncrytType"].ToString());
				}
				if(row["PasswordEncrytSalt"]!=null)
				{
					model.PasswordEncrytSalt=row["PasswordEncrytSalt"].ToString();
				}
				if(row["UserNameCN"]!=null)
				{
					model.UserNameCN=row["UserNameCN"].ToString();
				}
				if(row["UserNameEN"]!=null)
				{
					model.UserNameEN=row["UserNameEN"].ToString();
				}
				if(row["UserNameFirst"]!=null)
				{
					model.UserNameFirst=row["UserNameFirst"].ToString();
				}
				if(row["UserNameLast"]!=null)
				{
					model.UserNameLast=row["UserNameLast"].ToString();
				}
				if(row["UserNameMiddle"]!=null)
				{
					model.UserNameMiddle=row["UserNameMiddle"].ToString();
				}
				if(row["DepartmentID"]!=null && row["DepartmentID"].ToString()!="")
				{
					model.DepartmentID=int.Parse(row["DepartmentID"].ToString());
				}
				if(row["DepartmentGuid"]!=null && row["DepartmentGuid"].ToString()!="")
				{
					model.DepartmentGuid= new Guid(row["DepartmentGuid"].ToString());
				}
				if(row["DepartmentCode"]!=null)
				{
					model.DepartmentCode=row["DepartmentCode"].ToString();
				}
				if(row["DepartmentUserType"]!=null && row["DepartmentUserType"].ToString()!="")
				{
					model.DepartmentUserType=int.Parse(row["DepartmentUserType"].ToString());
				}
				if(row["UserFullPath"]!=null)
				{
					model.UserFullPath=row["UserFullPath"].ToString();
				}
				if(row["AreaCode"]!=null)
				{
					model.AreaCode=row["AreaCode"].ToString();
				}
				if(row["UserEmail"]!=null)
				{
					model.UserEmail=row["UserEmail"].ToString();
				}
				if(row["UserType"]!=null && row["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(row["UserType"].ToString());
				}
				if(row["UserStatus"]!=null && row["UserStatus"].ToString()!="")
				{
					model.UserStatus=int.Parse(row["UserStatus"].ToString());
				}
				if(row["UserRemark"]!=null)
				{
					model.UserRemark=row["UserRemark"].ToString();
				}
				if(row["UserCardID"]!=null)
				{
					model.UserCardID=row["UserCardID"].ToString();
				}
				if(row["UserCardIDIssued"]!=null)
				{
					model.UserCardIDIssued=row["UserCardIDIssued"].ToString();
				}
				if(row["DriversLicenceNumber"]!=null)
				{
					model.DriversLicenceNumber=row["DriversLicenceNumber"].ToString();
				}
				if(row["DriversLicenceNumberIssued"]!=null)
				{
					model.DriversLicenceNumberIssued=row["DriversLicenceNumberIssued"].ToString();
				}
				if(row["PassportCode"]!=null)
				{
					model.PassportCode=row["PassportCode"].ToString();
				}
				if(row["PassportCodeIssued"]!=null)
				{
					model.PassportCodeIssued=row["PassportCodeIssued"].ToString();
				}
				if(row["UserSex"]!=null && row["UserSex"].ToString()!="")
				{
					model.UserSex=int.Parse(row["UserSex"].ToString());
				}
				if(row["UserBirthDay"]!=null && row["UserBirthDay"].ToString()!="")
				{
					model.UserBirthDay=DateTime.Parse(row["UserBirthDay"].ToString());
				}
				if(row["MaritalStatus"]!=null && row["MaritalStatus"].ToString()!="")
				{
					model.MaritalStatus=int.Parse(row["MaritalStatus"].ToString());
				}
				if(row["UserMobileNO"]!=null)
				{
					model.UserMobileNO=row["UserMobileNO"].ToString();
				}
				if(row["UserRegisterDate"]!=null && row["UserRegisterDate"].ToString()!="")
				{
					model.UserRegisterDate=DateTime.Parse(row["UserRegisterDate"].ToString());
				}
				if(row["UserAgreeDate"]!=null && row["UserAgreeDate"].ToString()!="")
				{
					model.UserAgreeDate=DateTime.Parse(row["UserAgreeDate"].ToString());
				}
				if(row["UserWorkStartDate"]!=null && row["UserWorkStartDate"].ToString()!="")
				{
					model.UserWorkStartDate=DateTime.Parse(row["UserWorkStartDate"].ToString());
				}
				if(row["UserWorkEndDate"]!=null && row["UserWorkEndDate"].ToString()!="")
				{
					model.UserWorkEndDate=DateTime.Parse(row["UserWorkEndDate"].ToString());
				}
				if(row["CompanyMail"]!=null)
				{
					model.CompanyMail=row["CompanyMail"].ToString();
				}
				if(row["UserTitle"]!=null)
				{
					model.UserTitle=row["UserTitle"].ToString();
				}
				if(row["UserPosition"]!=null)
				{
					model.UserPosition=row["UserPosition"].ToString();
				}
				if(row["WorkTelphone"]!=null)
				{
					model.WorkTelphone=row["WorkTelphone"].ToString();
				}
				if(row["HomeTelephone"]!=null)
				{
					model.HomeTelephone=row["HomeTelephone"].ToString();
				}
				if(row["UserPhoto"]!=null)
				{
					model.UserPhoto=row["UserPhoto"].ToString();
				}
				if(row["UserMacAddress"]!=null)
				{
					model.UserMacAddress=row["UserMacAddress"].ToString();
				}
				if(row["UserLastIP"]!=null)
				{
					model.UserLastIP=row["UserLastIP"].ToString();
				}
				if(row["UserLastDateTime"]!=null && row["UserLastDateTime"].ToString()!="")
				{
					model.UserLastDateTime=DateTime.Parse(row["UserLastDateTime"].ToString());
				}
				if(row["BrokerKey"]!=null)
				{
					model.BrokerKey=row["BrokerKey"].ToString();
				}
				if(row["EnterpriseKey"]!=null)
				{
					model.EnterpriseKey=row["EnterpriseKey"].ToString();
				}
				if(row["UserHeight"]!=null && row["UserHeight"].ToString()!="")
				{
					model.UserHeight=decimal.Parse(row["UserHeight"].ToString());
				}
				if(row["UserWeight"]!=null && row["UserWeight"].ToString()!="")
				{
					model.UserWeight=decimal.Parse(row["UserWeight"].ToString());
				}
				if(row["UserNation"]!=null)
				{
					model.UserNation=row["UserNation"].ToString();
				}
				if(row["UserCountry"]!=null)
				{
					model.UserCountry=row["UserCountry"].ToString();
				}
				if(row["UserEducationalBackground"]!=null && row["UserEducationalBackground"].ToString()!="")
				{
					model.UserEducationalBackground=int.Parse(row["UserEducationalBackground"].ToString());
				}
				if(row["UserEducationalSchool"]!=null)
				{
					model.UserEducationalSchool=row["UserEducationalSchool"].ToString();
				}
				if(row["SocialSecurityNumber"]!=null)
				{
					model.SocialSecurityNumber=row["SocialSecurityNumber"].ToString();
				}
				if(row["CurrentResidence"]!=null)
				{
					model.CurrentResidence=row["CurrentResidence"].ToString();
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
			strSql.Append("select UserID,UserGuid,UserName,UserCode,Password,PasswordEncrytType,PasswordEncrytSalt,UserNameCN,UserNameEN,UserNameFirst,UserNameLast,UserNameMiddle,DepartmentID,DepartmentGuid,DepartmentCode,DepartmentUserType,UserFullPath,AreaCode,UserEmail,UserType,UserStatus,UserRemark,UserCardID,UserCardIDIssued,DriversLicenceNumber,DriversLicenceNumberIssued,PassportCode,PassportCodeIssued,UserSex,UserBirthDay,MaritalStatus,UserMobileNO,UserRegisterDate,UserAgreeDate,UserWorkStartDate,UserWorkEndDate,CompanyMail,UserTitle,UserPosition,WorkTelphone,HomeTelephone,UserPhoto,UserMacAddress,UserLastIP,UserLastDateTime,BrokerKey,EnterpriseKey,UserHeight,UserWeight,UserNation,UserCountry,UserEducationalBackground,UserEducationalSchool,SocialSecurityNumber,CurrentResidence,PropertyNames,PropertyValues ");
			strSql.Append(" FROM CoreUser ");
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
			strSql.Append(" UserID,UserGuid,UserName,UserCode,Password,PasswordEncrytType,PasswordEncrytSalt,UserNameCN,UserNameEN,UserNameFirst,UserNameLast,UserNameMiddle,DepartmentID,DepartmentGuid,DepartmentCode,DepartmentUserType,UserFullPath,AreaCode,UserEmail,UserType,UserStatus,UserRemark,UserCardID,UserCardIDIssued,DriversLicenceNumber,DriversLicenceNumberIssued,PassportCode,PassportCodeIssued,UserSex,UserBirthDay,MaritalStatus,UserMobileNO,UserRegisterDate,UserAgreeDate,UserWorkStartDate,UserWorkEndDate,CompanyMail,UserTitle,UserPosition,WorkTelphone,HomeTelephone,UserPhoto,UserMacAddress,UserLastIP,UserLastDateTime,BrokerKey,EnterpriseKey,UserHeight,UserWeight,UserNation,UserCountry,UserEducationalBackground,UserEducationalSchool,SocialSecurityNumber,CurrentResidence,PropertyNames,PropertyValues ");
			strSql.Append(" FROM CoreUser ");
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
			strSql.Append("select count(1) FROM CoreUser ");
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
				strSql.Append("order by T.UserID desc");
			}
			strSql.Append(")AS Row, T.*  from CoreUser T ");
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
			parameters[0].Value = "CoreUser";
			parameters[1].Value = "UserID";
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
            parameters[0].Value = "CoreUser";
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