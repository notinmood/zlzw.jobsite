using System;
namespace zlzw.Model
{
    /// <summary>
    /// GeneralADModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class GeneralADModel
    {
        public GeneralADModel()
        { }
        #region Model
        private int _adid;
        private Guid _adguid;
        private string _adname;
        private string _adimagekey;
        private string _adimagepath;
        private string _adscript;
        private string _adtargeturl;
        private int? _adtype;
        private Guid _adkind;
        private string _adcategory;
        private int? _adstatus;
        private DateTime? _displaystartdate;
        private DateTime? _displayenddate;
        private string _addesc;
        private string _admemo;
        private int? _adordernumber;
        private int? _adwidth;
        private int? _adheight;
        private string _createuserkey;
        private string _createusername;
        private DateTime? _createdate;
        private DateTime? _updatedate;
        private DateTime? _refreshdate;
        private string _adownerkey;
        private string _adownername;
        private int? _canusable;
        private string _propertynames;
        private string _propertyvalues;
        /// <summary>
        /// 
        /// </summary>
        public int ADID
        {
            set { _adid = value; }
            get { return _adid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ADGuid
        {
            set { _adguid = value; }
            get { return _adguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ADName
        {
            set { _adname = value; }
            get { return _adname; }
        }
        /// <summary>
        /// GeneralImage表GUID关联
        /// </summary>
        public string ADImageKey
        {
            set { _adimagekey = value; }
            get { return _adimagekey; }
        }
        /// <summary>
        /// 广告图片的实际路径
        /// </summary>
        public string ADImagePath
        {
            set { _adimagepath = value; }
            get { return _adimagepath; }
        }
        /// <summary>
        /// 广告代码
        /// </summary>
        public string ADScript
        {
            set { _adscript = value; }
            get { return _adscript; }
        }
        /// <summary>
        /// 跳转地址
        /// </summary>
        public string ADTargetUrl
        {
            set { _adtargeturl = value; }
            get { return _adtargeturl; }
        }
        /// <summary>
        /// 广告类别
        /// </summary>
        public int? ADType
        {
            set { _adtype = value; }
            get { return _adtype; }
        }
        /// <summary>
        /// 广告的种类（图片广告还是脚本广告）
        /// </summary>
        public Guid ADKind
        {
            set { _adkind = value; }
            get { return _adkind; }
        }
        /// <summary>
        /// 图片类别 存放到字典表中
        /// </summary>
        public string ADCategory
        {
            set { _adcategory = value; }
            get { return _adcategory; }
        }
        /// <summary>
        /// 图片状态
        /// </summary>
        public int? ADStatus
        {
            set { _adstatus = value; }
            get { return _adstatus; }
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
        /// 广告描述
        /// </summary>
        public string ADDesc
        {
            set { _addesc = value; }
            get { return _addesc; }
        }
        /// <summary>
        /// 广告的描述（不用）
        /// </summary>
        public string ADMemo
        {
            set { _admemo = value; }
            get { return _admemo; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? ADOrderNumber
        {
            set { _adordernumber = value; }
            get { return _adordernumber; }
        }
        /// <summary>
        /// 广告宽度
        /// </summary>
        public int? ADWidth
        {
            set { _adwidth = value; }
            get { return _adwidth; }
        }
        /// <summary>
        /// 高度
        /// </summary>
        public int? ADHeight
        {
            set { _adheight = value; }
            get { return _adheight; }
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
        /// 创建人的姓名
        /// </summary>
        public string CreateUserName
        {
            set { _createusername = value; }
            get { return _createusername; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 更新日期
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
        /// 广告所属人的GUID
        /// </summary>
        public string ADOwnerKey
        {
            set { _adownerkey = value; }
            get { return _adownerkey; }
        }
        /// <summary>
        /// 广告所属人的名字
        /// </summary>
        public string ADOwnerName
        {
            set { _adownername = value; }
            get { return _adownername; }
        }
        /// <summary>
        /// 管理员专用状态
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