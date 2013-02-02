using System;
namespace zlzw.Model
{
    /// <summary>
    /// NavigateInfoListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class NavigateInfoListModel
    {
        public NavigateInfoListModel()
        { }
        #region Model
        private int _navigateinfoid;
        private Guid _navigateguid;
        private string _navigateinfotitle;
        private string _navigateinfocontent;
        private int? _isenable;
        private DateTime? _publishdate;
        private Guid _publishid;
        private string _other01;
        private string _other02;
        /// <summary>
        /// 
        /// </summary>
        public int NavigateInfoID
        {
            set { _navigateinfoid = value; }
            get { return _navigateinfoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid NavigateGUID
        {
            set { _navigateguid = value; }
            get { return _navigateguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NavigateInfoTitle
        {
            set { _navigateinfotitle = value; }
            get { return _navigateinfotitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NavigateInfoContent
        {
            set { _navigateinfocontent = value; }
            get { return _navigateinfocontent; }
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