using System;
namespace zlzw.Model
{
    /// <summary>
    /// GeneralBasicSettingModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class GeneralBasicSettingModel
    {
        public GeneralBasicSettingModel()
        { }
        #region Model
        private int _settingid;
        private string _settingkey;
        private string _settingvalue;
        private string _settingdesc;
        private string _settingcategory;
        private string _displayname;
        private int? _ordernumber = 0;
        private int? _canusable;
        private int? _isinnersetting;
        /// <summary>
        /// 
        /// </summary>
        public int SettingID
        {
            set { _settingid = value; }
            get { return _settingid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SettingKey
        {
            set { _settingkey = value; }
            get { return _settingkey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SettingValue
        {
            set { _settingvalue = value; }
            get { return _settingvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SettingDesc
        {
            set { _settingdesc = value; }
            get { return _settingdesc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SettingCategory
        {
            set { _settingcategory = value; }
            get { return _settingcategory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DisplayName
        {
            set { _displayname = value; }
            get { return _displayname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderNumber
        {
            set { _ordernumber = value; }
            get { return _ordernumber; }
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
        /// 0: 非内部设置1:内部设置
        /// </summary>
        public int? IsInnerSetting
        {
            set { _isinnersetting = value; }
            get { return _isinnersetting; }
        }
        #endregion Model

    }
}