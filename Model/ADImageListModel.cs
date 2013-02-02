using System;
namespace zlzw.Model
{
    /// <summary>
    /// ADImageListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ADImageListModel
    {
        public ADImageListModel()
        { }
        #region Model
        private int _adimageid;
        private Guid _adimageguid;
        private string _adimagetitle;
        private string _adcontent;
        private string _adlink;
        private string _adimagepath;
        private DateTime? _publishdate;
        private int? _isenable;
        private int? _ishot;
        private string _other01;
        private string _other02;
        /// <summary>
        /// 
        /// </summary>
        public int ADImageID
        {
            set { _adimageid = value; }
            get { return _adimageid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ADImageGUID
        {
            set { _adimageguid = value; }
            get { return _adimageguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AdImageTitle
        {
            set { _adimagetitle = value; }
            get { return _adimagetitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ADContent
        {
            set { _adcontent = value; }
            get { return _adcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ADLink
        {
            set { _adlink = value; }
            get { return _adlink; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ADImagePath
        {
            set { _adimagepath = value; }
            get { return _adimagepath; }
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
        public int? IsEnable
        {
            set { _isenable = value; }
            get { return _isenable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsHot
        {
            set { _ishot = value; }
            get { return _ishot; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Other01
        {
            set { _other01 = value; }
            get { return _other01; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Other02
        {
            set { _other02 = value; }
            get { return _other02; }
        }
        #endregion Model

    }
}