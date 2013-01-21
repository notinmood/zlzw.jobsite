using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using zlzw.Model;
namespace zlzw.BLL
{
	/// <summary>
	/// JobPersonResumeBLL
	/// </summary>
	public partial class JobPersonResumeBLL
	{
		private readonly zlzw.DAL.JobPersonResumeDAL dal=new zlzw.DAL.JobPersonResumeDAL();
		public JobPersonResumeBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ResumeID)
		{
			return dal.Exists(ResumeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(zlzw.Model.JobPersonResumeModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(zlzw.Model.JobPersonResumeModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ResumeID)
		{
			
			return dal.Delete(ResumeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ResumeIDlist )
		{
			return dal.DeleteList(ResumeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public zlzw.Model.JobPersonResumeModel GetModel(int ResumeID)
		{
			
			return dal.GetModel(ResumeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public zlzw.Model.JobPersonResumeModel GetModelByCache(int ResumeID)
		{
			
			string CacheKey = "JobPersonResumeModelModel-" + ResumeID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ResumeID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (zlzw.Model.JobPersonResumeModel)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<zlzw.Model.JobPersonResumeModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<zlzw.Model.JobPersonResumeModel> DataTableToList(DataTable dt)
		{
			List<zlzw.Model.JobPersonResumeModel> modelList = new List<zlzw.Model.JobPersonResumeModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				zlzw.Model.JobPersonResumeModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod

        #region  ExtensionMethod

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
            return dal.GetList(PageSize, PageIndex, strColumns, strOrderColumn, nIsCount, strOrderType, strWhere);
        }

        #endregion  ExtensionMethod
	}
}