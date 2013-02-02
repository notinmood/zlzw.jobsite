using System;
namespace zlzw.Model
{
    /// <summary>
    /// ExchangeCornerListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ExchangeCornerListModel
    {
        public ExchangeCornerListModel()
        { }
        #region Model
        private int _exchangecornerid;
        private string _exchangecornertypekey;
        private Guid _exchangecornerguid;
        private string _exchangecornertitle;
        private string _exchangecornerfilepath;
        private string _exchangecornerfilesize;
        private string _exchangecornercontent;
        private DateTime? _publishdate;
        private int? _isenable;
        private string _other01;
        private string _other02;
        /// <summary>
        /// 
        /// </summary>
        public int ExchangeCornerID
        {
            set { _exchangecornerid = value; }
            get { return _exchangecornerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExchangeCornerTypeKey
        {
            set { _exchangecornertypekey = value; }
            get { return _exchangecornertypekey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ExchangeCornerGUID
        {
            set { _exchangecornerguid = value; }
            get { return _exchangecornerguid; }
        }
        /// <summary>
        /// 交流园地标题
        /// </summary>
        public string ExchangeCornerTitle
        {
            set { _exchangecornertitle = value; }
            get { return _exchangecornertitle; }
        }
        /// <summary>
        /// 交流园地文件下载地址
        /// </summary>
        public string ExchangeCornerFilePath
        {
            set { _exchangecornerfilepath = value; }
            get { return _exchangecornerfilepath; }
        }
        /// <summary>
        /// 文件尺寸
        /// </summary>
        public string ExchangeCornerFileSize
        {
            set { _exchangecornerfilesize = value; }
            get { return _exchangecornerfilesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExchangeCornerContent
        {
            set { _exchangecornercontent = value; }
            get { return _exchangecornercontent; }
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