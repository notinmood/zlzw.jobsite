using System;
namespace zlzw.Model
{
    /// <summary>
    /// JobEnterpriseResumeFavoriteModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class JobEnterpriseResumeFavoriteModel
    {
        public JobEnterpriseResumeFavoriteModel()
        { }
        #region Model
        private int _favoriteid;
        private Guid _favoriteguid;
        private int? _favoritestatus;
        private int? _favoritetype;
        private string _favoritecategory;
        private string _favoritecustomcategory;
        private string _enterprisekey;
        private string _enterprisename;
        private string _personresumekey;
        private string _personresumename;
        private string _personuserkey;
        private string _personusername;
        private string _favoritememo;
        private DateTime? _favoritedate;
        private string _propertynames;
        private string _propertyvalues;
        /// <summary>
        /// 
        /// </summary>
        public int FavoriteID
        {
            set { _favoriteid = value; }
            get { return _favoriteid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid FavoriteGuid
        {
            set { _favoriteguid = value; }
            get { return _favoriteguid; }
        }
        /// <summary>
        /// 企业操作的状态值 0 ，1
        /// </summary>
        public int? FavoriteStatus
        {
            set { _favoritestatus = value; }
            get { return _favoritestatus; }
        }
        /// <summary>
        /// 收藏类型（普通收藏还是下载收藏）(不用)
        /// </summary>
        public int? FavoriteType
        {
            set { _favoritetype = value; }
            get { return _favoritetype; }
        }
        /// <summary>
        /// 代码赋值默认值 download
        /// </summary>
        public string FavoriteCategory
        {
            set { _favoritecategory = value; }
            get { return _favoritecategory; }
        }
        /// <summary>
        /// 企业自定义类型 不用
        /// </summary>
        public string FavoriteCustomCategory
        {
            set { _favoritecustomcategory = value; }
            get { return _favoritecustomcategory; }
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
        /// 个人简历的GUID JobPersonResume的GUID
        /// </summary>
        public string PersonResumeKey
        {
            set { _personresumekey = value; }
            get { return _personresumekey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PersonResumeName
        {
            set { _personresumename = value; }
            get { return _personresumename; }
        }
        /// <summary>
        /// 求职者GUID CoreUser的UserGUID
        /// </summary>
        public string PersonUserKey
        {
            set { _personuserkey = value; }
            get { return _personuserkey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PersonUserName
        {
            set { _personusername = value; }
            get { return _personusername; }
        }
        /// <summary>
        /// 收藏备注信息
        /// </summary>
        public string FavoriteMemo
        {
            set { _favoritememo = value; }
            get { return _favoritememo; }
        }
        /// <summary>
        /// 收藏日期
        /// </summary>
        public DateTime? FavoriteDate
        {
            set { _favoritedate = value; }
            get { return _favoritedate; }
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