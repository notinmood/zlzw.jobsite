using System;
namespace zlzw.Model
{
    /// <summary>
    /// GeneralEnterpriseModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class GeneralEnterpriseModel
    {
        public GeneralEnterpriseModel()
        { }
        #region Model
        private int _enterpriseid;
        private Guid _enterpriseguid;
        private string _companyname;
        private string _companynameshort;
        private int? _businesstype;
        private string _tradingname;
        private string _industrykey;
        private int? _industrytype;
        private string _enterprisecode;
        private string _taxcode;
        private string _principleaddress;
        private string _postcode;
        private string _telephone;
        private string _telephoneother;
        private string _fax;
        private string _email;
        private int? _establishedyears;
        private DateTime? _establishedtime;
        private decimal? _grossincome;
        private decimal? _profit;
        private Guid _associatedenterpriseguid;
        private string _contactperson;
        private string _areacode;
        private string _areaother;
        private int? _canusable;
        private decimal? _longitude;
        private decimal? _lantitude;
        private string _brokerkey;
        private string _enterprisedescription;
        private string _enterprisememo;
        private string _enterpriseaddon;
        private string _enterprisewww;
        private int? _staffscope;
        private int? _enterpriselevel;
        private int? _enterpriselevel1;
        private int? _enterpriselevel2;
        private int? _enterpriselevel3;
        private int? _enterpriselevel4;
        private int? _enterpriselevel5;
        private int? _enterpriselevel6;
        private int? _enterpriselevel7;
        private string _enterpriserank;
        private int? _enterprisekind;
        private string _manageuserkey;
        private string _manageusername;
        private string _createuserkey;
        private string _createusername;
        private DateTime? _createdate;
        private string _lastupdateuserkey;
        private string _lastupdateusername;
        private DateTime? _lastupdatedate;
        private int? _isprotectedbyowner;
        private int? _cooperatestatus;
        private string _businesslicense;
        private string _shengname;
        private string _shengcode;
        private string _shiname;
        private string _shicode;
        private string _quname;
        private string _qucode;
        private string _busroute;
        private string _propertynames;
        private string _propertyvalues;
        /// <summary>
        /// 
        /// </summary>
        public int EnterpriseID
        {
            set { _enterpriseid = value; }
            get { return _enterpriseid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid EnterpriseGuid
        {
            set { _enterpriseguid = value; }
            get { return _enterpriseguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 企业简称
        /// </summary>
        public string CompanyNameShort
        {
            set { _companynameshort = value; }
            get { return _companynameshort; }
        }
        /// <summary>
        /// 企业性质 （个体、私营） EnterpriseTypes
        /// </summary>
        public int? BusinessType
        {
            set { _businesstype = value; }
            get { return _businesstype; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string TradingName
        {
            set { _tradingname = value; }
            get { return _tradingname; }
        }
        /// <summary>
        /// 所属行业
        /// </summary>
        public string IndustryKey
        {
            set { _industrykey = value; }
            get { return _industrykey; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? IndustryType
        {
            set { _industrytype = value; }
            get { return _industrytype; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string EnterpriseCode
        {
            set { _enterprisecode = value; }
            get { return _enterprisecode; }
        }
        /// <summary>
        /// 企业纳税号
        /// </summary>
        public string TaxCode
        {
            set { _taxcode = value; }
            get { return _taxcode; }
        }
        /// <summary>
        /// 企业公司地址
        /// </summary>
        public string PrincipleAddress
        {
            set { _principleaddress = value; }
            get { return _principleaddress; }
        }
        /// <summary>
        /// 企业邮编
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        /// <summary>
        /// 其他电话
        /// </summary>
        public string TelephoneOther
        {
            set { _telephoneother = value; }
            get { return _telephoneother; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 企业创建多少年
        /// </summary>
        public int? EstablishedYears
        {
            set { _establishedyears = value; }
            get { return _establishedyears; }
        }
        /// <summary>
        /// 企业创建日期
        /// </summary>
        public DateTime? EstablishedTime
        {
            set { _establishedtime = value; }
            get { return _establishedtime; }
        }
        /// <summary>
        /// 企业营收(毛利)
        /// </summary>
        public decimal? GrossIncome
        {
            set { _grossincome = value; }
            get { return _grossincome; }
        }
        /// <summary>
        /// 企业营收(纯利)
        /// </summary>
        public decimal? Profit
        {
            set { _profit = value; }
            get { return _profit; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public Guid AssociatedEnterpriseGuid
        {
            set { _associatedenterpriseguid = value; }
            get { return _associatedenterpriseguid; }
        }
        /// <summary>
        /// 企业联系人信息
        /// </summary>
        public string ContactPerson
        {
            set { _contactperson = value; }
            get { return _contactperson; }
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
        /// 企业所在地区 (保存地区名字)
        /// </summary>
        public string AreaOther
        {
            set { _areaother = value; }
            get { return _areaother; }
        }
        /// <summary>
        /// 企业是否可用
        /// </summary>
        public int? CanUsable
        {
            set { _canusable = value; }
            get { return _canusable; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public decimal? Longitude
        {
            set { _longitude = value; }
            get { return _longitude; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public decimal? Lantitude
        {
            set { _lantitude = value; }
            get { return _lantitude; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string BrokerKey
        {
            set { _brokerkey = value; }
            get { return _brokerkey; }
        }
        /// <summary>
        /// 企业简介
        /// </summary>
        public string EnterpriseDescription
        {
            set { _enterprisedescription = value; }
            get { return _enterprisedescription; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string EnterpriseMemo
        {
            set { _enterprisememo = value; }
            get { return _enterprisememo; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string EnterpriseAddon
        {
            set { _enterpriseaddon = value; }
            get { return _enterpriseaddon; }
        }
        /// <summary>
        /// 企业网址
        /// </summary>
        public string EnterpriseWWW
        {
            set { _enterprisewww = value; }
            get { return _enterprisewww; }
        }
        /// <summary>
        /// 企业人员规模 StaffScopes
        /// </summary>
        public int? StaffScope
        {
            set { _staffscope = value; }
            get { return _staffscope; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? EnterpriseLevel
        {
            set { _enterpriselevel = value; }
            get { return _enterpriselevel; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? EnterpriseLevel1
        {
            set { _enterpriselevel1 = value; }
            get { return _enterpriselevel1; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? EnterpriseLevel2
        {
            set { _enterpriselevel2 = value; }
            get { return _enterpriselevel2; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? EnterpriseLevel3
        {
            set { _enterpriselevel3 = value; }
            get { return _enterpriselevel3; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? EnterpriseLevel4
        {
            set { _enterpriselevel4 = value; }
            get { return _enterpriselevel4; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? EnterpriseLevel5
        {
            set { _enterpriselevel5 = value; }
            get { return _enterpriselevel5; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? EnterpriseLevel6
        {
            set { _enterpriselevel6 = value; }
            get { return _enterpriselevel6; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? EnterpriseLevel7
        {
            set { _enterpriselevel7 = value; }
            get { return _enterpriselevel7; }
        }
        /// <summary>
        /// 企业等级
        /// </summary>
        public string EnterpriseRank
        {
            set { _enterpriserank = value; }
            get { return _enterpriserank; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? EnterpriseKind
        {
            set { _enterprisekind = value; }
            get { return _enterprisekind; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string ManageUserKey
        {
            set { _manageuserkey = value; }
            get { return _manageuserkey; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public string ManageUserName
        {
            set { _manageusername = value; }
            get { return _manageusername; }
        }
        /// <summary>
        /// 企业创始人GUID
        /// </summary>
        public string CreateUserKey
        {
            set { _createuserkey = value; }
            get { return _createuserkey; }
        }
        /// <summary>
        /// 企业创始人名字
        /// </summary>
        public string CreateUserName
        {
            set { _createusername = value; }
            get { return _createusername; }
        }
        /// <summary>
        /// 系统中企业生成日期
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 最后一次修改人GUID
        /// </summary>
        public string LastUpdateUserKey
        {
            set { _lastupdateuserkey = value; }
            get { return _lastupdateuserkey; }
        }
        /// <summary>
        /// 最后一次修改人名字
        /// </summary>
        public string LastUpdateUserName
        {
            set { _lastupdateusername = value; }
            get { return _lastupdateusername; }
        }
        /// <summary>
        /// 最后一次修改日期
        /// </summary>
        public DateTime? LastUpdateDate
        {
            set { _lastupdatedate = value; }
            get { return _lastupdatedate; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? IsProtectedByOwner
        {
            set { _isprotectedbyowner = value; }
            get { return _isprotectedbyowner; }
        }
        /// <summary>
        /// 不用
        /// </summary>
        public int? CooperateStatus
        {
            set { _cooperatestatus = value; }
            get { return _cooperatestatus; }
        }
        /// <summary>
        /// 营业执照
        /// </summary>
        public string BusinessLicense
        {
            set { _businesslicense = value; }
            get { return _businesslicense; }
        }
        /// <summary>
        /// 企业所在省名称（中文）
        /// </summary>
        public string ShengName
        {
            set { _shengname = value; }
            get { return _shengname; }
        }
        /// <summary>
        /// 企业所在省（代码）
        /// </summary>
        public string ShengCode
        {
            set { _shengcode = value; }
            get { return _shengcode; }
        }
        /// <summary>
        /// 企业所在市名称（中文）
        /// </summary>
        public string ShiName
        {
            set { _shiname = value; }
            get { return _shiname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShiCode
        {
            set { _shicode = value; }
            get { return _shicode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuName
        {
            set { _quname = value; }
            get { return _quname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuCode
        {
            set { _qucode = value; }
            get { return _qucode; }
        }
        /// <summary>
        /// 乘车路线
        /// </summary>
        public string BusRoute
        {
            set { _busroute = value; }
            get { return _busroute; }
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