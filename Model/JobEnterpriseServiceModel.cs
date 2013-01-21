using System;
namespace zlzw.Model
{
    /// <summary>
    /// JobEnterpriseServiceModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class JobEnterpriseServiceModel
    {
        public JobEnterpriseServiceModel()
        { }
        #region Model
        private int _enterpriseserviceid;
        private Guid _enterpriseserviceguid;
        private int? _enterpriseservicestatus;
        private string _enterprisename;
        private string _enterprisekey;
        private int? _jobpositionpublishallowcount;
        private int? _jobpositionpublishusedcount;
        private string _enterpriseservicecurrentcontractkey;
        private DateTime? _enterpriseservicecurrentcontractstartdate;
        private DateTime? _enterpriseservicecurrentcontractenddate;
        private int? _resumedownallowcount;
        private int? _resumedownusedcount;
        private int? _canusable;
        private DateTime? _publishdate;
        private string _propertynames;
        private string _propertyvalues;
        /// <summary>
        /// 
        /// </summary>
        public int EnterpriseServiceID
        {
            set { _enterpriseserviceid = value; }
            get { return _enterpriseserviceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid EnterpriseServiceGuid
        {
            set { _enterpriseserviceguid = value; }
            get { return _enterpriseserviceguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EnterpriseServiceStatus
        {
            set { _enterpriseservicestatus = value; }
            get { return _enterpriseservicestatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EnterpriseName
        {
            set { _enterprisename = value; }
            get { return _enterprisename; }
        }
        /// <summary>
        /// GeneralEnterprise表的GUID
        /// </summary>
        public string EnterpriseKey
        {
            set { _enterprisekey = value; }
            get { return _enterprisekey; }
        }
        /// <summary>
        /// 允许发布的职位数
        /// </summary>
        public int? JobPositionPublishAllowCount
        {
            set { _jobpositionpublishallowcount = value; }
            get { return _jobpositionpublishallowcount; }
        }
        /// <summary>
        /// 已经发布的职位数 与JobEnterpriseJobPosition表关联
        /// </summary>
        public int? JobPositionPublishUsedCount
        {
            set { _jobpositionpublishusedcount = value; }
            get { return _jobpositionpublishusedcount; }
        }
        /// <summary>
        /// JobEnterpriseServiceContract表GUID 续费的合同
        /// </summary>
        public string EnterpriseServiceCurrentContractKey
        {
            set { _enterpriseservicecurrentcontractkey = value; }
            get { return _enterpriseservicecurrentcontractkey; }
        }
        /// <summary>
        /// 合同开始执行日期 JobEnterpriseServiceContract关联
        /// </summary>
        public DateTime? EnterpriseServiceCurrentContractStartDate
        {
            set { _enterpriseservicecurrentcontractstartdate = value; }
            get { return _enterpriseservicecurrentcontractstartdate; }
        }
        /// <summary>
        /// 合同的执行结束日期 JobEnterpriseServiceContract关联
        /// </summary>
        public DateTime? EnterpriseServiceCurrentContractEndDate
        {
            set { _enterpriseservicecurrentcontractenddate = value; }
            get { return _enterpriseservicecurrentcontractenddate; }
        }
        /// <summary>
        /// 允许查看的非投递简历数
        /// </summary>
        public int? ResumeDownAllowCount
        {
            set { _resumedownallowcount = value; }
            get { return _resumedownallowcount; }
        }
        /// <summary>
        /// 已经使用的非投递简历数
        /// </summary>
        public int? ResumeDownUsedCount
        {
            set { _resumedownusedcount = value; }
            get { return _resumedownusedcount; }
        }
        /// <summary>
        /// 管理员使用状态显示
        /// </summary>
        public int? CanUsable
        {
            set { _canusable = value; }
            get { return _canusable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PublishDate
        {
            set { _publishdate = value; }
            get { return _publishdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PropertyNames
        {
            set { _propertynames = value; }
            get { return _propertynames; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PropertyValues
        {
            set { _propertyvalues = value; }
            get { return _propertyvalues; }
        }
        #endregion Model

    }
}