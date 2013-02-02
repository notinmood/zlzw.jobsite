using System;
namespace zlzw.Model
{
    /// <summary>
    /// NavigateListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class NavigateListModel
    {
        public NavigateListModel()
        { }
        #region Model
        private int _navigateid;
        private Guid _navigateguid;
        private string _navigatename;
        private int? _isshow;
        private int? _isenable;
        private int? _ordernumber;
        private DateTime? _publishdate;
        private string _other01;
        private string _other02;
        /// <summary>
        /// 
        /// </summary>
        public int NavigateID
        {
            set { _navigateid = value; }
            get { return _navigateid; }
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
        public string NavigateName
        {
            set { _navigatename = value; }
            get { return _navigatename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsShow
        {
            set { _isshow = value; }
            get { return _isshow; }
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
        public int? OrderNumber
        {
            set { _ordernumber = value; }
            get { return _ordernumber; }
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