﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace zlzw.DAL
{
    /// <summary>
    /// 数据访问类:ParticipatingCompaniesListDAL
    /// </summary>
    public partial class ParticipatingCompaniesListDAL
    {
        public ParticipatingCompaniesListDAL()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ParticipatingCompaniesID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ParticipatingCompaniesID", SqlDbType.Int,4)
			};
            parameters[0].Value = ParticipatingCompaniesID;

            int result = DbHelperSQL.RunProcedure("ParticipatingCompaniesList_Exists", parameters, out rowsAffected);
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
        public int Add(zlzw.Model.ParticipatingCompaniesListModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ParticipatingCompaniesID", SqlDbType.Int,4),
					new SqlParameter("@ParticipatingCompaniesGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EnterpriseGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ParticipatingCompaniesContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@IsEnable", SqlDbType.Int,4),
					new SqlParameter("@Other01", SqlDbType.NVarChar,50),
					new SqlParameter("@Other02", SqlDbType.NVarChar,50),
					new SqlParameter("@Other03", SqlDbType.NVarChar,50),
					new SqlParameter("@Other04", SqlDbType.NVarChar,50)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = Guid.NewGuid();
            parameters[2].Value = model.EnterpriseGuid;
            parameters[3].Value = model.ParticipatingCompaniesContent;
            parameters[4].Value = model.IsShow;
            parameters[5].Value = model.PublishDate;
            parameters[6].Value = model.IsEnable;
            parameters[7].Value = model.Other01;
            parameters[8].Value = model.Other02;
            parameters[9].Value = model.Other03;
            parameters[10].Value = model.Other04;

            DbHelperSQL.RunProcedure("ParticipatingCompaniesList_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(zlzw.Model.ParticipatingCompaniesListModel model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ParticipatingCompaniesID", SqlDbType.Int,4),
					new SqlParameter("@ParticipatingCompaniesGUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EnterpriseGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ParticipatingCompaniesContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@PublishDate", SqlDbType.DateTime),
					new SqlParameter("@IsEnable", SqlDbType.Int,4),
					new SqlParameter("@Other01", SqlDbType.NVarChar,50),
					new SqlParameter("@Other02", SqlDbType.NVarChar,50),
					new SqlParameter("@Other03", SqlDbType.NVarChar,50),
					new SqlParameter("@Other04", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ParticipatingCompaniesID;
            parameters[1].Value = model.ParticipatingCompaniesGUID;
            parameters[2].Value = model.EnterpriseGuid;
            parameters[3].Value = model.ParticipatingCompaniesContent;
            parameters[4].Value = model.IsShow;
            parameters[5].Value = model.PublishDate;
            parameters[6].Value = model.IsEnable;
            parameters[7].Value = model.Other01;
            parameters[8].Value = model.Other02;
            parameters[9].Value = model.Other03;
            parameters[10].Value = model.Other04;

            DbHelperSQL.RunProcedure("ParticipatingCompaniesList_Update", parameters, out rowsAffected);
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
        public bool Delete(int ParticipatingCompaniesID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ParticipatingCompaniesID", SqlDbType.Int,4)
			};
            parameters[0].Value = ParticipatingCompaniesID;

            DbHelperSQL.RunProcedure("ParticipatingCompaniesList_Delete", parameters, out rowsAffected);
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
        public bool DeleteList(string ParticipatingCompaniesIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ParticipatingCompaniesList ");
            strSql.Append(" where ParticipatingCompaniesID in (" + ParticipatingCompaniesIDlist + ")  ");
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
        public zlzw.Model.ParticipatingCompaniesListModel GetModel(int ParticipatingCompaniesID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ParticipatingCompaniesID", SqlDbType.Int,4)
			};
            parameters[0].Value = ParticipatingCompaniesID;

            zlzw.Model.ParticipatingCompaniesListModel model = new zlzw.Model.ParticipatingCompaniesListModel();
            DataSet ds = DbHelperSQL.RunProcedure("ParticipatingCompaniesList_GetModel", parameters, "ds");
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
        public zlzw.Model.ParticipatingCompaniesListModel DataRowToModel(DataRow row)
        {
            zlzw.Model.ParticipatingCompaniesListModel model = new zlzw.Model.ParticipatingCompaniesListModel();
            if (row != null)
            {
                if (row["ParticipatingCompaniesID"] != null && row["ParticipatingCompaniesID"].ToString() != "")
                {
                    model.ParticipatingCompaniesID = int.Parse(row["ParticipatingCompaniesID"].ToString());
                }
                if (row["ParticipatingCompaniesGUID"] != null && row["ParticipatingCompaniesGUID"].ToString() != "")
                {
                    model.ParticipatingCompaniesGUID = new Guid(row["ParticipatingCompaniesGUID"].ToString());
                }
                if (row["EnterpriseGuid"] != null && row["EnterpriseGuid"].ToString() != "")
                {
                    model.EnterpriseGuid = new Guid(row["EnterpriseGuid"].ToString());
                }
                if (row["ParticipatingCompaniesContent"] != null)
                {
                    model.ParticipatingCompaniesContent = row["ParticipatingCompaniesContent"].ToString();
                }
                if (row["IsShow"] != null && row["IsShow"].ToString() != "")
                {
                    model.IsShow = int.Parse(row["IsShow"].ToString());
                }
                if (row["PublishDate"] != null && row["PublishDate"].ToString() != "")
                {
                    model.PublishDate = DateTime.Parse(row["PublishDate"].ToString());
                }
                if (row["IsEnable"] != null && row["IsEnable"].ToString() != "")
                {
                    model.IsEnable = int.Parse(row["IsEnable"].ToString());
                }
                if (row["Other01"] != null)
                {
                    model.Other01 = row["Other01"].ToString();
                }
                if (row["Other02"] != null)
                {
                    model.Other02 = row["Other02"].ToString();
                }
                if (row["Other03"] != null)
                {
                    model.Other03 = row["Other03"].ToString();
                }
                if (row["Other04"] != null)
                {
                    model.Other04 = row["Other04"].ToString();
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
            strSql.Append("select ParticipatingCompaniesID,ParticipatingCompaniesGUID,EnterpriseGuid,ParticipatingCompaniesContent,IsShow,PublishDate,IsEnable,Other01,Other02,Other03,Other04 ");
            strSql.Append(" FROM ParticipatingCompaniesList ");
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
            strSql.Append(" ParticipatingCompaniesID,ParticipatingCompaniesGUID,EnterpriseGuid,ParticipatingCompaniesContent,IsShow,PublishDate,IsEnable,Other01,Other02,Other03,Other04 ");
            strSql.Append(" FROM ParticipatingCompaniesList ");
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
            strSql.Append("select count(1) FROM ParticipatingCompaniesList ");
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
                strSql.Append("order by T.ParticipatingCompaniesID desc");
            }
            strSql.Append(")AS Row, T.*  from ParticipatingCompaniesList T ");
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
            parameters[0].Value = "ParticipatingCompaniesList";
            parameters[1].Value = "ParticipatingCompaniesID";
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
            parameters[0].Value = "ParticipatingCompaniesList";
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