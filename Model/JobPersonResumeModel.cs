using System;
namespace zlzw.Model
{
    /// <summary>
    /// JobPersonResumeModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class JobPersonResumeModel
    {
        public JobPersonResumeModel()
        { }
        #region Model
        private int _resumeid;
        private Guid _resumeguid;
        private int? _resumestatus;
        private string _resumename;
        private string _owneruserkey;
        private string _ownerusername;
        private int? _workexperienceyears;
        private DateTime? _createdate;
        private DateTime? _updatedate;
        private DateTime? _refreshdate;
        private int? _canusable;
        private string _selfevaluate;
        private int? _jobworktype;
        private string _jobworkplacekeys;
        private string _jobworkplacenames;
        private string _jobfeildtypes;
        private string _jobfeildkinds;
        private string _jobpositiontypes;
        private string _jobpositionkinds;
        private int? _jobsalary;
        private int? _jobcurrentworkstatus;
        private int? _resumetype;
        private string _resumekind;
        private string _educationexperience;
        private string _workexperience;
        private string _hopejob;
        private int? _hoperoomandboard;
        private string _personalskills;
        private string _skillscertificate;
        private string _currentsalary;
        private string _propertynames;
        private string _propertyvalues;
        /// <summary>
        /// 
        /// </summary>
        public int ResumeID
        {
            set { _resumeid = value; }
            get { return _resumeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ResumeGuid
        {
            set { _resumeguid = value; }
            get { return _resumeguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ResumeStatus
        {
            set { _resumestatus = value; }
            get { return _resumestatus; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string ResumeName
        {
            set { _resumename = value; }
            get { return _resumename; }
        }
        /// <summary>
        /// 求职者GUID CoreUser表UserGUID
        /// </summary>
        public string OwnerUserKey
        {
            set { _owneruserkey = value; }
            get { return _owneruserkey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OwnerUserName
        {
            set { _ownerusername = value; }
            get { return _ownerusername; }
        }
        /// <summary>
        /// 工作经验
        /// </summary>
        public int? WorkExperienceYears
        {
            set { _workexperienceyears = value; }
            get { return _workexperienceyears; }
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
        /// 管理员使用的状态信息
        /// </summary>
        public int? CanUsable
        {
            set { _canusable = value; }
            get { return _canusable; }
        }
        /// <summary>
        /// 自我评价
        /// </summary>
        public string SelfEvaluate
        {
            set { _selfevaluate = value; }
            get { return _selfevaluate; }
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
        /// 期望工作地点Key(多个地点之间用分割符号||) 不用
        /// </summary>
        public string JobWorkPlaceKeys
        {
            set { _jobworkplacekeys = value; }
            get { return _jobworkplacekeys; }
        }
        /// <summary>
        /// 期望工作地点名称(多个地点之间用分割符号||)
        /// </summary>
        public string JobWorkPlaceNames
        {
            set { _jobworkplacenames = value; }
            get { return _jobworkplacenames; }
        }
        /// <summary>
        /// 期望从事的行业类别 不用
        /// </summary>
        public string JobFeildTypes
        {
            set { _jobfeildtypes = value; }
            get { return _jobfeildtypes; }
        }
        /// <summary>
        /// 期望从事的行业类别
        /// </summary>
        public string JobFeildKinds
        {
            set { _jobfeildkinds = value; }
            get { return _jobfeildkinds; }
        }
        /// <summary>
        /// 岗位类别 不用
        /// </summary>
        public string JobPositionTypes
        {
            set { _jobpositiontypes = value; }
            get { return _jobpositiontypes; }
        }
        /// <summary>
        /// 岗位类别
        /// </summary>
        public string JobPositionKinds
        {
            set { _jobpositionkinds = value; }
            get { return _jobpositionkinds; }
        }
        /// <summary>
        /// 期望月薪
        /// </summary>
        public int? JobSalary
        {
            set { _jobsalary = value; }
            get { return _jobsalary; }
        }
        /// <summary>
        /// 当前工作状态
        /// </summary>
        public int? JobCurrentWorkStatus
        {
            set { _jobcurrentworkstatus = value; }
            get { return _jobcurrentworkstatus; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? ResumeType
        {
            set { _resumetype = value; }
            get { return _resumetype; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string ResumeKind
        {
            set { _resumekind = value; }
            get { return _resumekind; }
        }
        /// <summary>
        /// 教育经历
        /// </summary>
        public string EducationExperience
        {
            set { _educationexperience = value; }
            get { return _educationexperience; }
        }
        /// <summary>
        /// 工作经历
        /// </summary>
        public string WorkExperience
        {
            set { _workexperience = value; }
            get { return _workexperience; }
        }
        /// <summary>
        /// 意向职位名称
        /// </summary>
        public string HopeJob
        {
            set { _hopejob = value; }
            get { return _hopejob; }
        }
        /// <summary>
        /// 期望食宿
        /// </summary>
        public int? HopeRoomAndBoard
        {
            set { _hoperoomandboard = value; }
            get { return _hoperoomandboard; }
        }
        /// <summary>
        /// 个人技能
        /// </summary>
        public string PersonalSkills
        {
            set { _personalskills = value; }
            get { return _personalskills; }
        }
        /// <summary>
        /// 技能证书
        /// </summary>
        public string SkillsCertificate
        {
            set { _skillscertificate = value; }
            get { return _skillscertificate; }
        }
        /// <summary>
        /// 当前薪资
        /// </summary>
        public string CurrentSalary
        {
            set { _currentsalary = value; }
            get { return _currentsalary; }
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