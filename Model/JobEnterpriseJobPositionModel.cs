using System;
namespace zlzw.Model
{
    /// <summary>
    /// JobEnterpriseJobPositionModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class JobEnterpriseJobPositionModel
    {
        public JobEnterpriseJobPositionModel()
        { }
        #region Model
        private int _jobpositionid;
        private Guid _jobpositionguid;
        private int? _jobpositionstatus;
        private string _jobpositionname;
        private int? _specialtype;
        private string _enterprisekey;
        private string _enterprisename;
        private string _departmentname;
        private int? _jobpositiontype;
        private string _jobpositionkind;
        private int? _jobworktype;
        private string _jobworkplacekeys;
        private string _jobworkplacenames;
        private string _jobfeildtypes;
        private string _jobfeildkinds;
        private string _jobpositiontypes;
        private string _jobpositionkinds;
        private int? _jobsalary;
        private string _jobsalarydetails;
        private int? _needpersoncount;
        private int? _neededucation;
        private string _needage;
        private int? _needsex;
        private int? _needworkexperience;
        private int? _needmangeexperience;
        private string _jobpositiondesc;
        private string _contactinformation;
        private string _contactperson;
        private string _contacttelephone;
        private string _contactmail;
        private DateTime? _jobpositionstartdate;
        private DateTime? _jobpositionenddate;
        private int? _browsecount;
        private int? _resumecount;
        private string _createuserkey;
        private string _createusername;
        private DateTime? _createdate;
        private DateTime? _updatedate;
        private DateTime? _refreshdate;
        private int? _canusable;
        private string _interviewtime;
        private string _interviewaddress;
        private int? _hoperoomandboard;
        private string _comprehensivepayroll;
        private int? _isenableemergencyrecruitment = 0;
        private DateTime? _displaystartdate;
        private DateTime? _displayenddate;
        private string _propertynames;
        private string _propertyvalues;
        /// <summary>
        /// 
        /// </summary>
        public int JobPositionID
        {
            set { _jobpositionid = value; }
            get { return _jobpositionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid JobPositionGuid
        {
            set { _jobpositionguid = value; }
            get { return _jobpositionguid; }
        }
        /// <summary>
        /// 企业发布的岗位状态 允许企业选择
        /// </summary>
        public int? JobPositionStatus
        {
            set { _jobpositionstatus = value; }
            get { return _jobpositionstatus; }
        }
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string JobPositionName
        {
            set { _jobpositionname = value; }
            get { return _jobpositionname; }
        }
        /// <summary>
        /// 是否为紧急招聘
        /// </summary>
        public int? SpecialType
        {
            set { _specialtype = value; }
            get { return _specialtype; }
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
        /// 招聘企业岗位的所属部门 (哪个部门招聘)
        /// </summary>
        public string DepartmentName
        {
            set { _departmentname = value; }
            get { return _departmentname; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? JobPositionType
        {
            set { _jobpositiontype = value; }
            get { return _jobpositiontype; }
        }
        /// <summary>
        /// 记录岗位的中文名称
        /// </summary>
        public string JobPositionKind
        {
            set { _jobpositionkind = value; }
            get { return _jobpositionkind; }
        }
        /// <summary>
        /// 全职兼职工作性质
        /// </summary>
        public int? JobWorkType
        {
            set { _jobworktype = value; }
            get { return _jobworktype; }
        }
        /// <summary>
        /// 工作地点Key(多个地点之间用分割符号||)(不用)
        /// </summary>
        public string JobWorkPlaceKeys
        {
            set { _jobworkplacekeys = value; }
            get { return _jobworkplacekeys; }
        }
        /// <summary>
        /// 工作地点名称(多个地点之间用分割符号||)
        /// </summary>
        public string JobWorkPlaceNames
        {
            set { _jobworkplacenames = value; }
            get { return _jobworkplacenames; }
        }
        /// <summary>
        /// 行业类别（不用）
        /// </summary>
        public string JobFeildTypes
        {
            set { _jobfeildtypes = value; }
            get { return _jobfeildtypes; }
        }
        /// <summary>
        /// 行业类别 记录中文名称
        /// </summary>
        public string JobFeildKinds
        {
            set { _jobfeildkinds = value; }
            get { return _jobfeildkinds; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string JobPositionTypes
        {
            set { _jobpositiontypes = value; }
            get { return _jobpositiontypes; }
        }
        /// <summary>
        /// 从事职业类别 中文名称
        /// </summary>
        public string JobPositionKinds
        {
            set { _jobpositionkinds = value; }
            get { return _jobpositionkinds; }
        }
        /// <summary>
        /// 月薪(关联一个枚举实现) (1000 ~ 3000 面议)
        /// </summary>
        public int? JobSalary
        {
            set { _jobsalary = value; }
            get { return _jobsalary; }
        }
        /// <summary>
        /// 月薪的具体数额(不用)
        /// </summary>
        public string JobSalaryDetails
        {
            set { _jobsalarydetails = value; }
            get { return _jobsalarydetails; }
        }
        /// <summary>
        /// 招聘人数
        /// </summary>
        public int? NeedPersonCount
        {
            set { _needpersoncount = value; }
            get { return _needpersoncount; }
        }
        /// <summary>
        /// 需要的最低学历
        /// </summary>
        public int? NeedEducation
        {
            set { _neededucation = value; }
            get { return _neededucation; }
        }
        /// <summary>
        /// 年龄要求
        /// </summary>
        public string NeedAge
        {
            set { _needage = value; }
            get { return _needage; }
        }
        /// <summary>
        /// 性别要求
        /// </summary>
        public int? NeedSex
        {
            set { _needsex = value; }
            get { return _needsex; }
        }
        /// <summary>
        /// 工作经验要求
        /// </summary>
        public int? NeedWorkExperience
        {
            set { _needworkexperience = value; }
            get { return _needworkexperience; }
        }
        /// <summary>
        /// 是否有管理岗位的经验
        /// </summary>
        public int? NeedMangeExperience
        {
            set { _needmangeexperience = value; }
            get { return _needmangeexperience; }
        }
        /// <summary>
        /// 职位的描述
        /// </summary>
        public string JobPositionDesc
        {
            set { _jobpositiondesc = value; }
            get { return _jobpositiondesc; }
        }
        /// <summary>
        /// 联系信息(不用)
        /// </summary>
        public string ContactInformation
        {
            set { _contactinformation = value; }
            get { return _contactinformation; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactPerson
        {
            set { _contactperson = value; }
            get { return _contactperson; }
        }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ContactTelephone
        {
            set { _contacttelephone = value; }
            get { return _contacttelephone; }
        }
        /// <summary>
        /// 联系人邮件
        /// </summary>
        public string ContactMail
        {
            set { _contactmail = value; }
            get { return _contactmail; }
        }
        /// <summary>
        /// 招聘的开始日期
        /// </summary>
        public DateTime? JobPositionStartDate
        {
            set { _jobpositionstartdate = value; }
            get { return _jobpositionstartdate; }
        }
        /// <summary>
        /// 招聘的结束日期
        /// </summary>
        public DateTime? JobPositionEndDate
        {
            set { _jobpositionenddate = value; }
            get { return _jobpositionenddate; }
        }
        /// <summary>
        /// 浏览数
        /// </summary>
        public int? BrowseCount
        {
            set { _browsecount = value; }
            get { return _browsecount; }
        }
        /// <summary>
        /// 简历投递数
        /// </summary>
        public int? ResumeCount
        {
            set { _resumecount = value; }
            get { return _resumecount; }
        }
        /// <summary>
        /// 登陆人的GUID
        /// </summary>
        public string CreateUserKey
        {
            set { _createuserkey = value; }
            get { return _createuserkey; }
        }
        /// <summary>
        /// 登陆人的名字
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
        /// 简历修改时间
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RefreshDate
        {
            set { _refreshdate = value; }
            get { return _refreshdate; }
        }
        /// <summary>
        /// 管理员使用的状态
        /// </summary>
        public int? CanUsable
        {
            set { _canusable = value; }
            get { return _canusable; }
        }
        /// <summary>
        /// 面试时间
        /// </summary>
        public string InterviewTime
        {
            set { _interviewtime = value; }
            get { return _interviewtime; }
        }
        /// <summary>
        /// 面试地点
        /// </summary>
        public string InterviewAddress
        {
            set { _interviewaddress = value; }
            get { return _interviewaddress; }
        }
        /// <summary>
        /// 是否提供食宿
        /// </summary>
        public int? HopeRoomAndBoard
        {
            set { _hoperoomandboard = value; }
            get { return _hoperoomandboard; }
        }
        /// <summary>
        /// 综合薪资
        /// </summary>
        public string ComprehensivePayroll
        {
            set { _comprehensivepayroll = value; }
            get { return _comprehensivepayroll; }
        }
        /// <summary>
        /// 是否允许将紧急招聘显示在首页（由管理员控制）
        /// </summary>
        public int? IsEnableEmergencyRecruitment
        {
            set { _isenableemergencyrecruitment = value; }
            get { return _isenableemergencyrecruitment; }
        }
        /// <summary>
        /// 显示开始时间
        /// </summary>
        public DateTime? DisplayStartDate
        {
            set { _displaystartdate = value; }
            get { return _displaystartdate; }
        }
        /// <summary>
        /// 显示的结束时间
        /// </summary>
        public DateTime? DisplayEndDate
        {
            set { _displayenddate = value; }
            get { return _displayenddate; }
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