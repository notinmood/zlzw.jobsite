using System;
namespace zlzw.Model
{
    /// <summary>
    /// MerchantsJoinListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class MerchantsJoinListModel
    {
        public MerchantsJoinListModel()
        { }
        #region Model
        private int _merchantsjoinid;
        private Guid _merchantsjoinguid;
        private string _merchantsjoinconetnt;
        private int? _isenable;
        private DateTime? _publisdate;
        private string _publishname;
        private string _other01;
        private string _other02;
        /// <summary>
        /// 
        /// </summary>
        public int MerchantsJoinID
        {
            set { _merchantsjoinid = value; }
            get { return _merchantsjoinid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid MerchantsJoinGUID
        {
            set { _merchantsjoinguid = value; }
            get { return _merchantsjoinguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MerchantsJoinConetnt
        {
            set { _merchantsjoinconetnt = value; }
            get { return _merchantsjoinconetnt; }
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
        public DateTime? PublisDate
        {
            set { _publisdate = value; }
            get { return _publisdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PublishName
        {
            set { _publishname = value; }
            get { return _publishname; }
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