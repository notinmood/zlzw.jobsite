using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using zlzw.Model;
namespace zlzw.BLL
{
    /// <summary>
    /// JobEnterpriseJobPositionBLL
    /// </summary>
    public partial class JobEnterpriseJobPositionBLL
    {
        private readonly zlzw.DAL.JobEnterpriseJobPositionDAL dal = new zlzw.DAL.JobEnterpriseJobPositionDAL();
        public JobEnterpriseJobPositionBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int JobPositionID)
        {
            return dal.Exists(JobPositionID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(zlzw.Model.JobEnterpriseJobPositionModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(zlzw.Model.JobEnterpriseJobPositionModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int JobPositionID)
        {

            return dal.Delete(JobPositionID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string JobPositionIDlist)
        {
            return dal.DeleteList(JobPositionIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public zlzw.Model.JobEnterpriseJobPositionModel GetModel(int JobPositionID)
        {

            return dal.GetModel(JobPositionID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public zlzw.Model.JobEnterpriseJobPositionModel GetModelByCache(int JobPositionID)
        {

            string CacheKey = "JobEnterpriseJobPositionModelModel-" + JobPositionID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(JobPositionID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (zlzw.Model.JobEnterpriseJobPositionModel)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<zlzw.Model.JobEnterpriseJobPositionModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<zlzw.Model.JobEnterpriseJobPositionModel> DataTableToList(DataTable dt)
        {
            List<zlzw.Model.JobEnterpriseJobPositionModel> modelList = new List<zlzw.Model.JobEnterpriseJobPositionModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                zlzw.Model.JobEnterpriseJobPositionModel model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

