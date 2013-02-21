using System;
namespace zlzw.Model
{
    /// <summary>
    /// PaidServicesListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PaidServicesListModel
    {
        public PaidServicesListModel()
        { }
        #region Model
        private int _paidservicesid;
        private Guid _paidservicesguid;
        private int? _publishjobcount = 80;
        private decimal? _publishjobprice = 0.0M;
        private int? _mainresumecount = 10;
        private decimal? _mainresumeprice = 5M;
        private int? _searchstrangeresumecount = 400;
        private decimal? _searchstrangeresumeprice = 0.0M;
        private int? _downloadstrangeresumecount = 0;
        private decimal? _downloadstrangeresumeprice = 0.0M;
        private DateTime? _publishdate;
        private Guid _publishid;
        private decimal? _jobadlargeprice = 300M;
        private decimal? _jobadsmallprice = 200M;
        private decimal? _emergencyrecruitmentprice = 100M;
        private string _other01;
        private string _other02;
        private int? _other03;
        /// <summary>
        /// 
        /// </summary>
        public int PaidServicesID
        {
            set { _paidservicesid = value; }
            get { return _paidservicesid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid PaidServicesGUID
        {
            set { _paidservicesguid = value; }
            get { return _paidservicesguid; }
        }
        /// <summary>
        /// 发布职位数
        /// </summary>
        public int? PublishJobCount
        {
            set { _publishjobcount = value; }
            get { return _publishjobcount; }
        }
        /// <summary>
        /// 职位发布价格
        /// </summary>
        public decimal? PublishJobPrice
        {
            set { _publishjobprice = value; }
            get { return _publishjobprice; }
        }
        /// <summary>
        /// 主投简历数
        /// </summary>
        public int? MainResumeCount
        {
            set { _mainresumecount = value; }
            get { return _mainresumecount; }
        }
        /// <summary>
        /// 查看主投简历价格
        /// </summary>
        public decimal? MainResumePrice
        {
            set { _mainresumeprice = value; }
            get { return _mainresumeprice; }
        }
        /// <summary>
        /// 搜索陌生简历数
        /// </summary>
        public int? SearchStrangeResumeCount
        {
            set { _searchstrangeresumecount = value; }
            get { return _searchstrangeresumecount; }
        }
        /// <summary>
        /// 搜索陌生简历价格
        /// </summary>
        public decimal? SearchStrangeResumePrice
        {
            set { _searchstrangeresumeprice = value; }
            get { return _searchstrangeresumeprice; }
        }
        /// <summary>
        /// 下载陌生简历数
        /// </summary>
        public int? DownloadStrangeResumeCount
        {
            set { _downloadstrangeresumecount = value; }
            get { return _downloadstrangeresumecount; }
        }
        /// <summary>
        /// 下载陌生简历价格
        /// </summary>
        public decimal? DownloadStrangeResumePrice
        {
            set { _downloadstrangeresumeprice = value; }
            get { return _downloadstrangeresumeprice; }
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
        public Guid PublishID
        {
            set { _publishid = value; }
            get { return _publishid; }
        }
        /// <summary>
        /// 名企招聘大方块
        /// </summary>
        public decimal? JobAdLargePrice
        {
            set { _jobadlargeprice = value; }
            get { return _jobadlargeprice; }
        }
        /// <summary>
        /// 名企招聘小方块
        /// </summary>
        public decimal? JobAdSmallPrice
        {
            set { _jobadsmallprice = value; }
            get { return _jobadsmallprice; }
        }
        /// <summary>
        /// 紧急招聘价格
        /// </summary>
        public decimal? EmergencyRecruitmentPrice
        {
            set { _emergencyrecruitmentprice = value; }
            get { return _emergencyrecruitmentprice; }
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
        /// <summary>
        /// 
        /// </summary>
        public int? Other03
        {
            set { _other03 = value; }
            get { return _other03; }
        }
        #endregion Model

    }
}