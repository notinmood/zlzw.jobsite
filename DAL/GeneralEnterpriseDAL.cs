using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
	/// <summary>
	/// 数据访问类:GeneralEnterpriseDAL
	/// </summary>
	public partial class GeneralEnterpriseDAL
	{
		public GeneralEnterpriseDAL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int EnterpriseID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)
			};
			parameters[0].Value = EnterpriseID;

			int result= DbHelperSQL.RunProcedure("GeneralEnterprise_Exists",parameters,out rowsAffected);
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
		public int Add(zlzw.Model.GeneralEnterpriseModel model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CompanyName", SqlDbType.NVarChar,200),
					new SqlParameter("@CompanyNameShort", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessType", SqlDbType.Int,4),
					new SqlParameter("@TradingName", SqlDbType.NVarChar,200),
					new SqlParameter("@IndustryKey", SqlDbType.NVarChar,200),
					new SqlParameter("@IndustryType", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TaxCode", SqlDbType.NVarChar,50),
					new SqlParameter("@PrincipleAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,50),
					new SqlParameter("@TelephoneOther", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@EstablishedYears", SqlDbType.Int,4),
					new SqlParameter("@EstablishedTime", SqlDbType.DateTime),
					new SqlParameter("@GrossIncome", SqlDbType.Decimal,9),
					new SqlParameter("@Profit", SqlDbType.Decimal,9),
					new SqlParameter("@AssociatedEnterpriseGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaCode", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaOther", SqlDbType.NVarChar,200),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@Longitude", SqlDbType.Decimal,9),
					new SqlParameter("@Lantitude", SqlDbType.Decimal,9),
					new SqlParameter("@BrokerKey", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@EnterpriseMemo", SqlDbType.NVarChar,-1),
					new SqlParameter("@EnterpriseAddon", SqlDbType.NVarChar,-1),
					new SqlParameter("@EnterpriseWWW", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffScope", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel1", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel2", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel3", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel4", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel5", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel6", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel7", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseRank", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseKind", SqlDbType.Int,4),
					new SqlParameter("@ManageUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@ManageUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@LastUpdateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@IsProtectedByOwner", SqlDbType.Int,4),
					new SqlParameter("@CooperateStatus", SqlDbType.Int,4),
					new SqlParameter("@BusinessLicense", SqlDbType.NVarChar,200),
					new SqlParameter("@ShengName", SqlDbType.NVarChar,50),
					new SqlParameter("@ShengCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ShiName", SqlDbType.NVarChar,50),
					new SqlParameter("@ShiCode", SqlDbType.NVarChar,50),
					new SqlParameter("@QuName", SqlDbType.NVarChar,50),
					new SqlParameter("@QuCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BusRoute", SqlDbType.NVarChar,200),
					new SqlParameter("@PropertyNames", SqlDbType.NText),
					new SqlParameter("@PropertyValues", SqlDbType.NText)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = model.CompanyName;
			parameters[3].Value = model.CompanyNameShort;
			parameters[4].Value = model.BusinessType;
			parameters[5].Value = model.TradingName;
			parameters[6].Value = model.IndustryKey;
			parameters[7].Value = model.IndustryType;
			parameters[8].Value = model.EnterpriseCode;
			parameters[9].Value = model.TaxCode;
			parameters[10].Value = model.PrincipleAddress;
			parameters[11].Value = model.PostCode;
			parameters[12].Value = model.Telephone;
			parameters[13].Value = model.TelephoneOther;
			parameters[14].Value = model.Fax;
			parameters[15].Value = model.Email;
			parameters[16].Value = model.EstablishedYears;
			parameters[17].Value = model.EstablishedTime;
			parameters[18].Value = model.GrossIncome;
			parameters[19].Value = model.Profit;
			parameters[20].Value = Guid.NewGuid();
			parameters[21].Value = model.ContactPerson;
			parameters[22].Value = model.AreaCode;
			parameters[23].Value = model.AreaOther;
			parameters[24].Value = model.CanUsable;
			parameters[25].Value = model.Longitude;
			parameters[26].Value = model.Lantitude;
			parameters[27].Value = model.BrokerKey;
			parameters[28].Value = model.EnterpriseDescription;
			parameters[29].Value = model.EnterpriseMemo;
			parameters[30].Value = model.EnterpriseAddon;
			parameters[31].Value = model.EnterpriseWWW;
			parameters[32].Value = model.StaffScope;
			parameters[33].Value = model.EnterpriseLevel;
			parameters[34].Value = model.EnterpriseLevel1;
			parameters[35].Value = model.EnterpriseLevel2;
			parameters[36].Value = model.EnterpriseLevel3;
			parameters[37].Value = model.EnterpriseLevel4;
			parameters[38].Value = model.EnterpriseLevel5;
			parameters[39].Value = model.EnterpriseLevel6;
			parameters[40].Value = model.EnterpriseLevel7;
			parameters[41].Value = model.EnterpriseRank;
			parameters[42].Value = model.EnterpriseKind;
			parameters[43].Value = model.ManageUserKey;
			parameters[44].Value = model.ManageUserName;
			parameters[45].Value = model.CreateUserKey;
			parameters[46].Value = model.CreateUserName;
			parameters[47].Value = model.CreateDate;
			parameters[48].Value = model.LastUpdateUserKey;
			parameters[49].Value = model.LastUpdateUserName;
			parameters[50].Value = model.LastUpdateDate;
			parameters[51].Value = model.IsProtectedByOwner;
			parameters[52].Value = model.CooperateStatus;
			parameters[53].Value = model.BusinessLicense;
			parameters[54].Value = model.ShengName;
			parameters[55].Value = model.ShengCode;
			parameters[56].Value = model.ShiName;
			parameters[57].Value = model.ShiCode;
			parameters[58].Value = model.QuName;
			parameters[59].Value = model.QuCode;
			parameters[60].Value = model.BusRoute;
			parameters[61].Value = model.PropertyNames;
			parameters[62].Value = model.PropertyValues;

			DbHelperSQL.RunProcedure("GeneralEnterprise_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(zlzw.Model.GeneralEnterpriseModel model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CompanyName", SqlDbType.NVarChar,200),
					new SqlParameter("@CompanyNameShort", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessType", SqlDbType.Int,4),
					new SqlParameter("@TradingName", SqlDbType.NVarChar,200),
					new SqlParameter("@IndustryKey", SqlDbType.NVarChar,200),
					new SqlParameter("@IndustryType", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TaxCode", SqlDbType.NVarChar,50),
					new SqlParameter("@PrincipleAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,50),
					new SqlParameter("@TelephoneOther", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@EstablishedYears", SqlDbType.Int,4),
					new SqlParameter("@EstablishedTime", SqlDbType.DateTime),
					new SqlParameter("@GrossIncome", SqlDbType.Decimal,9),
					new SqlParameter("@Profit", SqlDbType.Decimal,9),
					new SqlParameter("@AssociatedEnterpriseGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaCode", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaOther", SqlDbType.NVarChar,200),
					new SqlParameter("@CanUsable", SqlDbType.Int,4),
					new SqlParameter("@Longitude", SqlDbType.Decimal,9),
					new SqlParameter("@Lantitude", SqlDbType.Decimal,9),
					new SqlParameter("@BrokerKey", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@EnterpriseMemo", SqlDbType.NVarChar,-1),
					new SqlParameter("@EnterpriseAddon", SqlDbType.NVarChar,-1),
					new SqlParameter("@EnterpriseWWW", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffScope", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel1", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel2", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel3", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel4", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel5", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel6", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseLevel7", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseRank", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseKind", SqlDbType.Int,4),
					new SqlParameter("@ManageUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@ManageUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUserKey", SqlDbType.NVarChar,50),
					new SqlParameter("@LastUpdateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@IsProtectedByOwner", SqlDbType.Int,4),
					new SqlParameter("@CooperateStatus", SqlDbType.Int,4),
					new SqlParameter("@BusinessLicense", SqlDbType.NVarChar,200),
					new SqlParameter("@ShengName", SqlDbType.NVarChar,50),
					new SqlParameter("@ShengCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ShiName", SqlDbType.NVarChar,50),
					new SqlParameter("@ShiCode", SqlDbType.NVarChar,50),
					new SqlParameter("@QuName", SqlDbType.NVarChar,50),
					new SqlParameter("@QuCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BusRoute", SqlDbType.NVarChar,200),
					new SqlParameter("@PropertyNames", SqlDbType.NText),
					new SqlParameter("@PropertyValues", SqlDbType.NText)};
			parameters[0].Value = model.EnterpriseID;
			parameters[1].Value = model.EnterpriseGuid;
			parameters[2].Value = model.CompanyName;
			parameters[3].Value = model.CompanyNameShort;
			parameters[4].Value = model.BusinessType;
			parameters[5].Value = model.TradingName;
			parameters[6].Value = model.IndustryKey;
			parameters[7].Value = model.IndustryType;
			parameters[8].Value = model.EnterpriseCode;
			parameters[9].Value = model.TaxCode;
			parameters[10].Value = model.PrincipleAddress;
			parameters[11].Value = model.PostCode;
			parameters[12].Value = model.Telephone;
			parameters[13].Value = model.TelephoneOther;
			parameters[14].Value = model.Fax;
			parameters[15].Value = model.Email;
			parameters[16].Value = model.EstablishedYears;
			parameters[17].Value = model.EstablishedTime;
			parameters[18].Value = model.GrossIncome;
			parameters[19].Value = model.Profit;
			parameters[20].Value = model.AssociatedEnterpriseGuid;
			parameters[21].Value = model.ContactPerson;
			parameters[22].Value = model.AreaCode;
			parameters[23].Value = model.AreaOther;
			parameters[24].Value = model.CanUsable;
			parameters[25].Value = model.Longitude;
			parameters[26].Value = model.Lantitude;
			parameters[27].Value = model.BrokerKey;
			parameters[28].Value = model.EnterpriseDescription;
			parameters[29].Value = model.EnterpriseMemo;
			parameters[30].Value = model.EnterpriseAddon;
			parameters[31].Value = model.EnterpriseWWW;
			parameters[32].Value = model.StaffScope;
			parameters[33].Value = model.EnterpriseLevel;
			parameters[34].Value = model.EnterpriseLevel1;
			parameters[35].Value = model.EnterpriseLevel2;
			parameters[36].Value = model.EnterpriseLevel3;
			parameters[37].Value = model.EnterpriseLevel4;
			parameters[38].Value = model.EnterpriseLevel5;
			parameters[39].Value = model.EnterpriseLevel6;
			parameters[40].Value = model.EnterpriseLevel7;
			parameters[41].Value = model.EnterpriseRank;
			parameters[42].Value = model.EnterpriseKind;
			parameters[43].Value = model.ManageUserKey;
			parameters[44].Value = model.ManageUserName;
			parameters[45].Value = model.CreateUserKey;
			parameters[46].Value = model.CreateUserName;
			parameters[47].Value = model.CreateDate;
			parameters[48].Value = model.LastUpdateUserKey;
			parameters[49].Value = model.LastUpdateUserName;
			parameters[50].Value = model.LastUpdateDate;
			parameters[51].Value = model.IsProtectedByOwner;
			parameters[52].Value = model.CooperateStatus;
			parameters[53].Value = model.BusinessLicense;
			parameters[54].Value = model.ShengName;
			parameters[55].Value = model.ShengCode;
			parameters[56].Value = model.ShiName;
			parameters[57].Value = model.ShiCode;
			parameters[58].Value = model.QuName;
			parameters[59].Value = model.QuCode;
			parameters[60].Value = model.BusRoute;
			parameters[61].Value = model.PropertyNames;
			parameters[62].Value = model.PropertyValues;

			DbHelperSQL.RunProcedure("GeneralEnterprise_Update",parameters,out rowsAffected);
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
		public bool Delete(int EnterpriseID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)
			};
			parameters[0].Value = EnterpriseID;

			DbHelperSQL.RunProcedure("GeneralEnterprise_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string EnterpriseIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GeneralEnterprise ");
			strSql.Append(" where EnterpriseID in ("+EnterpriseIDlist + ")  ");
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
		public zlzw.Model.GeneralEnterpriseModel GetModel(int EnterpriseID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)
			};
			parameters[0].Value = EnterpriseID;

			zlzw.Model.GeneralEnterpriseModel model=new zlzw.Model.GeneralEnterpriseModel();
			DataSet ds= DbHelperSQL.RunProcedure("GeneralEnterprise_GetModel",parameters,"ds");
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
		public zlzw.Model.GeneralEnterpriseModel DataRowToModel(DataRow row)
		{
			zlzw.Model.GeneralEnterpriseModel model=new zlzw.Model.GeneralEnterpriseModel();
			if (row != null)
			{
				if(row["EnterpriseID"]!=null && row["EnterpriseID"].ToString()!="")
				{
					model.EnterpriseID=int.Parse(row["EnterpriseID"].ToString());
				}
				if(row["EnterpriseGuid"]!=null && row["EnterpriseGuid"].ToString()!="")
				{
					model.EnterpriseGuid= new Guid(row["EnterpriseGuid"].ToString());
				}
				if(row["CompanyName"]!=null)
				{
					model.CompanyName=row["CompanyName"].ToString();
				}
				if(row["CompanyNameShort"]!=null)
				{
					model.CompanyNameShort=row["CompanyNameShort"].ToString();
				}
				if(row["BusinessType"]!=null && row["BusinessType"].ToString()!="")
				{
					model.BusinessType=int.Parse(row["BusinessType"].ToString());
				}
				if(row["TradingName"]!=null)
				{
					model.TradingName=row["TradingName"].ToString();
				}
				if(row["IndustryKey"]!=null)
				{
					model.IndustryKey=row["IndustryKey"].ToString();
				}
				if(row["IndustryType"]!=null && row["IndustryType"].ToString()!="")
				{
					model.IndustryType=int.Parse(row["IndustryType"].ToString());
				}
				if(row["EnterpriseCode"]!=null)
				{
					model.EnterpriseCode=row["EnterpriseCode"].ToString();
				}
				if(row["TaxCode"]!=null)
				{
					model.TaxCode=row["TaxCode"].ToString();
				}
				if(row["PrincipleAddress"]!=null)
				{
					model.PrincipleAddress=row["PrincipleAddress"].ToString();
				}
				if(row["PostCode"]!=null)
				{
					model.PostCode=row["PostCode"].ToString();
				}
				if(row["Telephone"]!=null)
				{
					model.Telephone=row["Telephone"].ToString();
				}
				if(row["TelephoneOther"]!=null)
				{
					model.TelephoneOther=row["TelephoneOther"].ToString();
				}
				if(row["Fax"]!=null)
				{
					model.Fax=row["Fax"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["EstablishedYears"]!=null && row["EstablishedYears"].ToString()!="")
				{
					model.EstablishedYears=int.Parse(row["EstablishedYears"].ToString());
				}
				if(row["EstablishedTime"]!=null && row["EstablishedTime"].ToString()!="")
				{
					model.EstablishedTime=DateTime.Parse(row["EstablishedTime"].ToString());
				}
				if(row["GrossIncome"]!=null && row["GrossIncome"].ToString()!="")
				{
					model.GrossIncome=decimal.Parse(row["GrossIncome"].ToString());
				}
				if(row["Profit"]!=null && row["Profit"].ToString()!="")
				{
					model.Profit=decimal.Parse(row["Profit"].ToString());
				}
				if(row["AssociatedEnterpriseGuid"]!=null && row["AssociatedEnterpriseGuid"].ToString()!="")
				{
					model.AssociatedEnterpriseGuid= new Guid(row["AssociatedEnterpriseGuid"].ToString());
				}
				if(row["ContactPerson"]!=null)
				{
					model.ContactPerson=row["ContactPerson"].ToString();
				}
				if(row["AreaCode"]!=null)
				{
					model.AreaCode=row["AreaCode"].ToString();
				}
				if(row["AreaOther"]!=null)
				{
					model.AreaOther=row["AreaOther"].ToString();
				}
				if(row["CanUsable"]!=null && row["CanUsable"].ToString()!="")
				{
					model.CanUsable=int.Parse(row["CanUsable"].ToString());
				}
				if(row["Longitude"]!=null && row["Longitude"].ToString()!="")
				{
					model.Longitude=decimal.Parse(row["Longitude"].ToString());
				}
				if(row["Lantitude"]!=null && row["Lantitude"].ToString()!="")
				{
					model.Lantitude=decimal.Parse(row["Lantitude"].ToString());
				}
				if(row["BrokerKey"]!=null)
				{
					model.BrokerKey=row["BrokerKey"].ToString();
				}
				if(row["EnterpriseDescription"]!=null)
				{
					model.EnterpriseDescription=row["EnterpriseDescription"].ToString();
				}
				if(row["EnterpriseMemo"]!=null)
				{
					model.EnterpriseMemo=row["EnterpriseMemo"].ToString();
				}
				if(row["EnterpriseAddon"]!=null)
				{
					model.EnterpriseAddon=row["EnterpriseAddon"].ToString();
				}
				if(row["EnterpriseWWW"]!=null)
				{
					model.EnterpriseWWW=row["EnterpriseWWW"].ToString();
				}
				if(row["StaffScope"]!=null && row["StaffScope"].ToString()!="")
				{
					model.StaffScope=int.Parse(row["StaffScope"].ToString());
				}
				if(row["EnterpriseLevel"]!=null && row["EnterpriseLevel"].ToString()!="")
				{
					model.EnterpriseLevel=int.Parse(row["EnterpriseLevel"].ToString());
				}
				if(row["EnterpriseLevel1"]!=null && row["EnterpriseLevel1"].ToString()!="")
				{
					model.EnterpriseLevel1=int.Parse(row["EnterpriseLevel1"].ToString());
				}
				if(row["EnterpriseLevel2"]!=null && row["EnterpriseLevel2"].ToString()!="")
				{
					model.EnterpriseLevel2=int.Parse(row["EnterpriseLevel2"].ToString());
				}
				if(row["EnterpriseLevel3"]!=null && row["EnterpriseLevel3"].ToString()!="")
				{
					model.EnterpriseLevel3=int.Parse(row["EnterpriseLevel3"].ToString());
				}
				if(row["EnterpriseLevel4"]!=null && row["EnterpriseLevel4"].ToString()!="")
				{
					model.EnterpriseLevel4=int.Parse(row["EnterpriseLevel4"].ToString());
				}
				if(row["EnterpriseLevel5"]!=null && row["EnterpriseLevel5"].ToString()!="")
				{
					model.EnterpriseLevel5=int.Parse(row["EnterpriseLevel5"].ToString());
				}
				if(row["EnterpriseLevel6"]!=null && row["EnterpriseLevel6"].ToString()!="")
				{
					model.EnterpriseLevel6=int.Parse(row["EnterpriseLevel6"].ToString());
				}
				if(row["EnterpriseLevel7"]!=null && row["EnterpriseLevel7"].ToString()!="")
				{
					model.EnterpriseLevel7=int.Parse(row["EnterpriseLevel7"].ToString());
				}
				if(row["EnterpriseRank"]!=null)
				{
					model.EnterpriseRank=row["EnterpriseRank"].ToString();
				}
				if(row["EnterpriseKind"]!=null && row["EnterpriseKind"].ToString()!="")
				{
					model.EnterpriseKind=int.Parse(row["EnterpriseKind"].ToString());
				}
				if(row["ManageUserKey"]!=null)
				{
					model.ManageUserKey=row["ManageUserKey"].ToString();
				}
				if(row["ManageUserName"]!=null)
				{
					model.ManageUserName=row["ManageUserName"].ToString();
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
				if(row["LastUpdateUserKey"]!=null)
				{
					model.LastUpdateUserKey=row["LastUpdateUserKey"].ToString();
				}
				if(row["LastUpdateUserName"]!=null)
				{
					model.LastUpdateUserName=row["LastUpdateUserName"].ToString();
				}
				if(row["LastUpdateDate"]!=null && row["LastUpdateDate"].ToString()!="")
				{
					model.LastUpdateDate=DateTime.Parse(row["LastUpdateDate"].ToString());
				}
				if(row["IsProtectedByOwner"]!=null && row["IsProtectedByOwner"].ToString()!="")
				{
					model.IsProtectedByOwner=int.Parse(row["IsProtectedByOwner"].ToString());
				}
				if(row["CooperateStatus"]!=null && row["CooperateStatus"].ToString()!="")
				{
					model.CooperateStatus=int.Parse(row["CooperateStatus"].ToString());
				}
				if(row["BusinessLicense"]!=null)
				{
					model.BusinessLicense=row["BusinessLicense"].ToString();
				}
				if(row["ShengName"]!=null)
				{
					model.ShengName=row["ShengName"].ToString();
				}
				if(row["ShengCode"]!=null)
				{
					model.ShengCode=row["ShengCode"].ToString();
				}
				if(row["ShiName"]!=null)
				{
					model.ShiName=row["ShiName"].ToString();
				}
				if(row["ShiCode"]!=null)
				{
					model.ShiCode=row["ShiCode"].ToString();
				}
				if(row["QuName"]!=null)
				{
					model.QuName=row["QuName"].ToString();
				}
				if(row["QuCode"]!=null)
				{
					model.QuCode=row["QuCode"].ToString();
				}
				if(row["BusRoute"]!=null)
				{
					model.BusRoute=row["BusRoute"].ToString();
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
			strSql.Append("select EnterpriseID,EnterpriseGuid,CompanyName,CompanyNameShort,BusinessType,TradingName,IndustryKey,IndustryType,EnterpriseCode,TaxCode,PrincipleAddress,PostCode,Telephone,TelephoneOther,Fax,Email,EstablishedYears,EstablishedTime,GrossIncome,Profit,AssociatedEnterpriseGuid,ContactPerson,AreaCode,AreaOther,CanUsable,Longitude,Lantitude,BrokerKey,EnterpriseDescription,EnterpriseMemo,EnterpriseAddon,EnterpriseWWW,StaffScope,EnterpriseLevel,EnterpriseLevel1,EnterpriseLevel2,EnterpriseLevel3,EnterpriseLevel4,EnterpriseLevel5,EnterpriseLevel6,EnterpriseLevel7,EnterpriseRank,EnterpriseKind,ManageUserKey,ManageUserName,CreateUserKey,CreateUserName,CreateDate,LastUpdateUserKey,LastUpdateUserName,LastUpdateDate,IsProtectedByOwner,CooperateStatus,BusinessLicense,ShengName,ShengCode,ShiName,ShiCode,QuName,QuCode,BusRoute,PropertyNames,PropertyValues ");
			strSql.Append(" FROM GeneralEnterprise ");
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
			strSql.Append(" EnterpriseID,EnterpriseGuid,CompanyName,CompanyNameShort,BusinessType,TradingName,IndustryKey,IndustryType,EnterpriseCode,TaxCode,PrincipleAddress,PostCode,Telephone,TelephoneOther,Fax,Email,EstablishedYears,EstablishedTime,GrossIncome,Profit,AssociatedEnterpriseGuid,ContactPerson,AreaCode,AreaOther,CanUsable,Longitude,Lantitude,BrokerKey,EnterpriseDescription,EnterpriseMemo,EnterpriseAddon,EnterpriseWWW,StaffScope,EnterpriseLevel,EnterpriseLevel1,EnterpriseLevel2,EnterpriseLevel3,EnterpriseLevel4,EnterpriseLevel5,EnterpriseLevel6,EnterpriseLevel7,EnterpriseRank,EnterpriseKind,ManageUserKey,ManageUserName,CreateUserKey,CreateUserName,CreateDate,LastUpdateUserKey,LastUpdateUserName,LastUpdateDate,IsProtectedByOwner,CooperateStatus,BusinessLicense,ShengName,ShengCode,ShiName,ShiCode,QuName,QuCode,BusRoute,PropertyNames,PropertyValues ");
			strSql.Append(" FROM GeneralEnterprise ");
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
			strSql.Append("select count(1) FROM GeneralEnterprise ");
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
				strSql.Append("order by T.EnterpriseID desc");
			}
			strSql.Append(")AS Row, T.*  from GeneralEnterprise T ");
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
			parameters[0].Value = "GeneralEnterprise";
			parameters[1].Value = "EnterpriseID";
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
            parameters[0].Value = "GeneralEnterprise";
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