using System;
namespace zlzw.Model
{
    /// <summary>
    /// CoreUserModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CoreUserModel
    {
        public CoreUserModel()
        { }
        #region Model
        private int _userid;
        private Guid _userguid;
        private string _username;
        private string _usercode;
        private string _password;
        private int? _passwordencryttype;
        private string _passwordencrytsalt;
        private string _usernamecn;
        private string _usernameen;
        private string _usernamefirst;
        private string _usernamelast;
        private string _usernamemiddle;
        private int? _departmentid;
        private Guid _departmentguid;
        private string _departmentcode;
        private int? _departmentusertype;
        private string _userfullpath;
        private string _areacode;
        private string _useremail;
        private int? _usertype;
        private int? _userstatus;
        private string _userremark;
        private string _usercardid;
        private string _usercardidissued;
        private string _driverslicencenumber;
        private string _driverslicencenumberissued;
        private string _passportcode;
        private string _passportcodeissued;
        private int? _usersex;
        private DateTime? _userbirthday;
        private int? _maritalstatus;
        private string _usermobileno;
        private DateTime? _userregisterdate;
        private DateTime? _useragreedate;
        private DateTime? _userworkstartdate;
        private DateTime? _userworkenddate;
        private string _companymail;
        private string _usertitle;
        private string _userposition;
        private string _worktelphone;
        private string _hometelephone;
        private string _userphoto;
        private string _usermacaddress;
        private string _userlastip;
        private DateTime? _userlastdatetime;
        private string _brokerkey;
        private string _enterprisekey;
        private decimal? _userheight;
        private decimal? _userweight;
        private string _usernation;
        private string _usercountry;
        private int? _usereducationalbackground;
        private string _usereducationalschool;
        private string _socialsecuritynumber;
        private string _currentresidence;
        private string _propertynames;
        private string _propertyvalues;
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid UserGuid
        {
            set { _userguid = value; }
            get { return _userguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserCode
        {
            set { _usercode = value; }
            get { return _usercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? PasswordEncrytType
        {
            set { _passwordencryttype = value; }
            get { return _passwordencryttype; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string PasswordEncrytSalt
        {
            set { _passwordencrytsalt = value; }
            get { return _passwordencrytsalt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserNameCN
        {
            set { _usernamecn = value; }
            get { return _usernamecn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserNameEN
        {
            set { _usernameen = value; }
            get { return _usernameen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserNameFirst
        {
            set { _usernamefirst = value; }
            get { return _usernamefirst; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserNameLast
        {
            set { _usernamelast = value; }
            get { return _usernamelast; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string UserNameMiddle
        {
            set { _usernamemiddle = value; }
            get { return _usernamemiddle; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? DepartmentID
        {
            set { _departmentid = value; }
            get { return _departmentid; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public Guid DepartmentGuid
        {
            set { _departmentguid = value; }
            get { return _departmentguid; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string DepartmentCode
        {
            set { _departmentcode = value; }
            get { return _departmentcode; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? DepartmentUserType
        {
            set { _departmentusertype = value; }
            get { return _departmentusertype; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string UserFullPath
        {
            set { _userfullpath = value; }
            get { return _userfullpath; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string AreaCode
        {
            set { _areacode = value; }
            get { return _areacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserEmail
        {
            set { _useremail = value; }
            get { return _useremail; }
        }
        /// <summary>
        /// 用户类型 1:普通用户 2：企业用户 64：管理员
        /// </summary>
        public int? UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 0：不可用 1：可用
        /// </summary>
        public int? UserStatus
        {
            set { _userstatus = value; }
            get { return _userstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserRemark
        {
            set { _userremark = value; }
            get { return _userremark; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string UserCardID
        {
            set { _usercardid = value; }
            get { return _usercardid; }
        }
        /// <summary>
        /// 发证机关
        /// </summary>
        public string UserCardIDIssued
        {
            set { _usercardidissued = value; }
            get { return _usercardidissued; }
        }
        /// <summary>
        /// 驾照号码
        /// </summary>
        public string DriversLicenceNumber
        {
            set { _driverslicencenumber = value; }
            get { return _driverslicencenumber; }
        }
        /// <summary>
        /// 驾照发证机关
        /// </summary>
        public string DriversLicenceNumberIssued
        {
            set { _driverslicencenumberissued = value; }
            get { return _driverslicencenumberissued; }
        }
        /// <summary>
        /// 护照号码
        /// </summary>
        public string PassportCode
        {
            set { _passportcode = value; }
            get { return _passportcode; }
        }
        /// <summary>
        /// 护照发证机关
        /// </summary>
        public string PassportCodeIssued
        {
            set { _passportcodeissued = value; }
            get { return _passportcodeissued; }
        }
        /// <summary>
        /// 0:未设置 1：男 2：女
        /// </summary>
        public int? UserSex
        {
            set { _usersex = value; }
            get { return _usersex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UserBirthDay
        {
            set { _userbirthday = value; }
            get { return _userbirthday; }
        }
        /// <summary>
        /// 婚姻状态 MaritalStatuses
        /// </summary>
        public int? MaritalStatus
        {
            set { _maritalstatus = value; }
            get { return _maritalstatus; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string UserMobileNO
        {
            set { _usermobileno = value; }
            get { return _usermobileno; }
        }
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime? UserRegisterDate
        {
            set { _userregisterdate = value; }
            get { return _userregisterdate; }
        }
        /// <summary>
        /// 批准日期
        /// </summary>
        public DateTime? UserAgreeDate
        {
            set { _useragreedate = value; }
            get { return _useragreedate; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public DateTime? UserWorkStartDate
        {
            set { _userworkstartdate = value; }
            get { return _userworkstartdate; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public DateTime? UserWorkEndDate
        {
            set { _userworkenddate = value; }
            get { return _userworkenddate; }
        }
        /// <summary>
        /// 企业邮箱
        /// </summary>
        public string CompanyMail
        {
            set { _companymail = value; }
            get { return _companymail; }
        }
        /// <summary>
        /// 用户当前职位
        /// </summary>
        public string UserTitle
        {
            set { _usertitle = value; }
            get { return _usertitle; }
        }
        /// <summary>
        /// 当前用户职位
        /// </summary>
        public string UserPosition
        {
            set { _userposition = value; }
            get { return _userposition; }
        }
        /// <summary>
        /// 工作电话
        /// </summary>
        public string WorkTelphone
        {
            set { _worktelphone = value; }
            get { return _worktelphone; }
        }
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string HomeTelephone
        {
            set { _hometelephone = value; }
            get { return _hometelephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserPhoto
        {
            set { _userphoto = value; }
            get { return _userphoto; }
        }
        /// <summary>
        /// 用户MAC地址
        /// </summary>
        public string UserMacAddress
        {
            set { _usermacaddress = value; }
            get { return _usermacaddress; }
        }
        /// <summary>
        /// 用户最后登陆IP地址
        /// </summary>
        public string UserLastIP
        {
            set { _userlastip = value; }
            get { return _userlastip; }
        }
        /// <summary>
        /// 用户最后登陆时间
        /// </summary>
        public DateTime? UserLastDateTime
        {
            set { _userlastdatetime = value; }
            get { return _userlastdatetime; }
        }
        /// <summary>
        /// 介绍人介绍码
        /// </summary>
        public string BrokerKey
        {
            set { _brokerkey = value; }
            get { return _brokerkey; }
        }
        /// <summary>
        /// 所属企业的GUID
        /// </summary>
        public string EnterpriseKey
        {
            set { _enterprisekey = value; }
            get { return _enterprisekey; }
        }
        /// <summary>
        /// 用户身高
        /// </summary>
        public decimal? UserHeight
        {
            set { _userheight = value; }
            get { return _userheight; }
        }
        /// <summary>
        /// 用户体重
        /// </summary>
        public decimal? UserWeight
        {
            set { _userweight = value; }
            get { return _userweight; }
        }
        /// <summary>
        /// 国籍
        /// </summary>
        public string UserNation
        {
            set { _usernation = value; }
            get { return _usernation; }
        }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string UserCountry
        {
            set { _usercountry = value; }
            get { return _usercountry; }
        }
        /// <summary>
        /// 教育背景 枚举UserEducationalBackgrounds
        /// </summary>
        public int? UserEducationalBackground
        {
            set { _usereducationalbackground = value; }
            get { return _usereducationalbackground; }
        }
        /// <summary>
        /// 毕业院校
        /// </summary>
        public string UserEducationalSchool
        {
            set { _usereducationalschool = value; }
            get { return _usereducationalschool; }
        }
        /// <summary>
        /// 社保号
        /// </summary>
        public string SocialSecurityNumber
        {
            set { _socialsecuritynumber = value; }
            get { return _socialsecuritynumber; }
        }
        /// <summary>
        /// 当前居住地
        /// </summary>
        public string CurrentResidence
        {
            set { _currentresidence = value; }
            get { return _currentresidence; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string PropertyNames
        {
            set { _propertynames = value; }
            get { return _propertynames; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string PropertyValues
        {
            set { _propertyvalues = value; }
            get { return _propertyvalues; }
        }
        #endregion Model

    }
}