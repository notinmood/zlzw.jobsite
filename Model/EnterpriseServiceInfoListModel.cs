using System;
namespace zlzw.Model
{
    /// <summary>
    /// EnterpriseServiceInfoListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class EnterpriseServiceInfoListModel
    {
        public EnterpriseServiceInfoListModel()
        { }
        #region Model
        private int _enterpriseserviceinfoid;
        private Guid _enterpriseservicetypeguid;
        private Guid _enterpriseserviceinfoguid;
        private string _enterpriseserviceinfotitle;
        private string _enterpriseserviceinfointroduction;
        private string _enterpriseserviceinfocontent;
        private Guid _publishid;
        private DateTime? _publishdate;
        private int? _isenable;
        private string _other01;
        private string _other02;
        /// <summary>
        /// 
        /// </summary>
        public int EnterpriseServiceInfoID
        {
            set { _enterpriseserviceinfoid = value; }
            get { return _enterpriseserviceinfoid; }
        }
        /// <summary>
        ///  所属类型GUID
        /// </summary>
        public Guid EnterpriseServiceTypeGUID
        {
            set { _enterpriseservicetypeguid = value; }
            get { return _enterpriseservicetypeguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid EnterpriseServiceInfoGUID
        {
            set { _enterpriseserviceinfoguid = value; }
            get { return _enterpriseserviceinfoguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EnterpriseServiceInfoTitle
        {
            set { _enterpriseserviceinfotitle = value; }
            get { return _enterpriseserviceinfotitle; }
        }
        /// <summary>
        /// 简介（无HTML格式）
        /// </summary>
        public string EnterpriseServiceInfointroduction
        {
            set { _enterpriseserviceinfointroduction = value; }
            get { return _enterpriseserviceinfointroduction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EnterpriseServiceInfoContent
        {
            set { _enterpriseserviceinfocontent = value; }
            get { return _enterpriseserviceinfocontent; }
        }
        /// <summary>
        /// 发布人
        /// </summary>
        public Guid PublishID
        {
            set { _publishid = value; }
            get { return _publishid; }
        }
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime? PublishDate
        {
            set { _publishdate = value; }
            get { return _publishdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsEnable
        {
            set { _isenable = value; }
            get { return _isenable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Other01
        {
            set { _other01 = value; }
            get { return _other01; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Other02
        {
            set { _other02 = value; }
            get { return _other02; }
        }
        #endregion Model

    }
}