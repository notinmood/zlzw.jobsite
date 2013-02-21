using System;
namespace zlzw.Model
{
    /// <summary>
    /// RechargeListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RechargeListModel
    {
        public RechargeListModel()
        { }
        #region Model
        private int _rechargeid;
        private Guid _rechargeguid;
        private Guid _enterpriseguid;
        private Guid _userguid;
        private Guid _expand_rechargeguid;
        private decimal? _rechargesum;
        private DateTime? _publishdate;
        private int? _isenable;
        private string _other01;
        private string _other02;
        private string _other03;
        /// <summary>
        /// 
        /// </summary>
        public int RechargeID
        {
            set { _rechargeid = value; }
            get { return _rechargeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid RechargeGUID
        {
            set { _rechargeguid = value; }
            get { return _rechargeguid; }
        }
        /// <summary>
        /// 所属企业GUID
        /// </summary>
        public Guid EnterpriseGuid
        {
            set { _enterpriseguid = value; }
            get { return _enterpriseguid; }
        }
        /// <summary>
        /// 充值人的GUID
        /// </summary>
        public Guid UserGuid
        {
            set { _userguid = value; }
            get { return _userguid; }
        }
        /// <summary>
        /// 与企业表Expand_RechargeGUID对应 由系统生成
        /// </summary>
        public Guid Expand_RechargeGUID
        {
            set { _expand_rechargeguid = value; }
            get { return _expand_rechargeguid; }
        }
        /// <summary>
        /// 当前充值余额
        /// </summary>
        public decimal? RechargeSum
        {
            set { _rechargesum = value; }
            get { return _rechargesum; }
        }
        /// <summary>
        /// 充值日期
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
        /// <summary>
        /// 
        /// </summary>
        public string Other03
        {
            set { _other03 = value; }
            get { return _other03; }
        }
        #endregion Model

    }
}