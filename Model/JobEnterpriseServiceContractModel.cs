using System;
namespace zlzw.Model
{
    /// <summary>
    /// JobEnterpriseServiceContractModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class JobEnterpriseServiceContractModel
    {
        public JobEnterpriseServiceContractModel()
        { }
        #region Model
        private int _servicecontractid;
        private Guid _servicecontractguid;
        private string _enterpriseservicekey;
        private int? _servicecontractstatus;
        private string _enterprisekey;
        private string _enterprisename;
        private DateTime? _servicecontractstartdate;
        private DateTime? _servicecontractenddate;
        private string _servicecontractmemo;
        private decimal? _servicefee;
        private int? _servicefeeispaid;
        private string _servicefeemanageusername;
        private string _servicefeemanageuserkey;
        private string _createuserkey;
        private string _createusername;
        private DateTime? _createdate;
        private int? _canusable;
        private string _propertynames;
        private string _propertyvalues;
        /// <summary>
        /// 
        /// </summary>
        public int ServiceContractID
        {
            set { _servicecontractid = value; }
            get { return _servicecontractid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ServiceContractGuid
        {
            set { _servicecontractguid = value; }
            get { return _servicecontractguid; }
        }
        /// <summary>
        /// JobEnterpriseService表GUID
        /// </summary>
        public string EnterpriseServiceKey
        {
            set { _enterpriseservicekey = value; }
            get { return _enterpriseservicekey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ServiceContractStatus
        {
            set { _servicecontractstatus = value; }
            get { return _servicecontractstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EnterpriseKey
        {
            set { _enterprisekey = value; }
            get { return _enterprisekey; }
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
        /// 
        /// </summary>
        public DateTime? ServiceContractStartDate
        {
            set { _servicecontractstartdate = value; }
            get { return _servicecontractstartdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ServiceContractEndDate
        {
            set { _servicecontractenddate = value; }
            get { return _servicecontractenddate; }
        }
        /// <summary>
        /// 备注信息 (不用)
        /// </summary>
        public string ServiceContractMemo
        {
            set { _servicecontractmemo = value; }
            get { return _servicecontractmemo; }
        }
        /// <summary>
        /// 企业缴费具体数额
        /// </summary>
        public decimal? ServiceFee
        {
            set { _servicefee = value; }
            get { return _servicefee; }
        }
        /// <summary>
        /// 企业缴费是否成功
        /// </summary>
        public int? ServiceFeeIsPaid
        {
            set { _servicefeeispaid = value; }
            get { return _servicefeeispaid; }
        }
        /// <summary>
        /// 收款人名字
        /// </summary>
        public string ServiceFeeManageUserName
        {
            set { _servicefeemanageusername = value; }
            get { return _servicefeemanageusername; }
        }
        /// <summary>
        /// 收款人GUID
        /// </summary>
        public string ServiceFeeManageUserKey
        {
            set { _servicefeemanageuserkey = value; }
            get { return _servicefeemanageuserkey; }
        }
        /// <summary>
        /// 合同创建人的GUID
        /// </summary>
        public string CreateUserKey
        {
            set { _createuserkey = value; }
            get { return _createuserkey; }
        }
        /// <summary>
        /// 合同创建人的名字
        /// </summary>
        public string CreateUserName
        {
            set { _createusername = value; }
            get { return _createusername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CanUsable
        {
            set { _canusable = value; }
            get { return _canusable; }
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