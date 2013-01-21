using System;
namespace zlzw.Model
{
    /// <summary>
    /// GeneralActivityModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class GeneralActivityModel
    {
        public GeneralActivityModel()
        { }
        #region Model
        private int _activityid;
        private Guid _activityguid;
        private int? _activitytype;
        private Guid _activitykind;
        private string _activitycategory;
        private DateTime? _activitydate;
        private string _activityareacode;
        private string _activityareadetails;
        private string _activityaddress;
        private string _activityaddressdetails;
        private string _activitytitle;
        private string _activitydesc;
        private string _activitysummary;
        private string _activityaddon;
        private DateTime? _publishdate;
        private int? _canusable;
        private string _createuserkey;
        private string _createusername;
        private int? _specialtype;
        private int? _joinusercount;
        private string _activityreviewdetails;
        private string _activityreviewkey;
        private string _activityreviewtarget;
        private string _propertynames;
        private string _propertyvalues;
        /// <summary>
        /// 
        /// </summary>
        public int ActivityID
        {
            set { _activityid = value; }
            get { return _activityid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ActivityGuid
        {
            set { _activityguid = value; }
            get { return _activityguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ActivityType
        {
            set { _activitytype = value; }
            get { return _activitytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ActivityKind
        {
            set { _activitykind = value; }
            get { return _activitykind; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ActivityCategory
        {
            set { _activitycategory = value; }
            get { return _activitycategory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ActivityDate
        {
            set { _activitydate = value; }
            get { return _activitydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ActivityAreaCode
        {
            set { _activityareacode = value; }
            get { return _activityareacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ActivityAreaDetails
        {
            set { _activityareadetails = value; }
            get { return _activityareadetails; }
        }
        /// <summary>
        /// 活动地点（选择输入）
        /// </summary>
        public string ActivityAddress
        {
            set { _activityaddress = value; }
            get { return _activityaddress; }
        }
        /// <summary>
        /// 活动地点（手动输入）
        /// </summary>
        public string ActivityAddressDetails
        {
            set { _activityaddressdetails = value; }
            get { return _activityaddressdetails; }
        }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string ActivityTitle
        {
            set { _activitytitle = value; }
            get { return _activitytitle; }
        }
        /// <summary>
        /// 活动描述
        /// </summary>
        public string ActivityDesc
        {
            set { _activitydesc = value; }
            get { return _activitydesc; }
        }
        /// <summary>
        /// 活动描述
        /// </summary>
        public string ActivitySummary
        {
            set { _activitysummary = value; }
            get { return _activitysummary; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string ActivityAddon
        {
            set { _activityaddon = value; }
            get { return _activityaddon; }
        }
        /// <summary>
        /// 活动发布日期
        /// </summary>
        public DateTime? PublishDate
        {
            set { _publishdate = value; }
            get { return _publishdate; }
        }
        /// <summary>
        /// 是否可用
        /// </summary>
        public int? CanUsable
        {
            set { _canusable = value; }
            get { return _canusable; }
        }
        /// <summary>
        /// 创建人GUID
        /// </summary>
        public string CreateUserKey
        {
            set { _createuserkey = value; }
            get { return _createuserkey; }
        }
        /// <summary>
        /// 创建人的名字
        /// </summary>
        public string CreateUserName
        {
            set { _createusername = value; }
            get { return _createusername; }
        }
        /// <summary>
        /// 状态信息 （热点、首页显示）
        /// </summary>
        public int? SpecialType
        {
            set { _specialtype = value; }
            get { return _specialtype; }
        }
        /// <summary>
        /// 参加人数
        /// </summary>
        public int? JoinUserCount
        {
            set { _joinusercount = value; }
            get { return _joinusercount; }
        }
        /// <summary>
        /// 活动回顾
        /// </summary>
        public string ActivityReviewDetails
        {
            set { _activityreviewdetails = value; }
            get { return _activityreviewdetails; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ActivityReviewKey
        {
            set { _activityreviewkey = value; }
            get { return _activityreviewkey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ActivityReviewTarget
        {
            set { _activityreviewtarget = value; }
            get { return _activityreviewtarget; }
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