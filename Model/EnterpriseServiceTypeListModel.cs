using System;
namespace zlzw.Model
{
    /// <summary>
    /// EnterpriseServiceTypeListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class EnterpriseServiceTypeListModel
    {
        public EnterpriseServiceTypeListModel()
        { }
        #region Model
        private int _enterpriseservicetypeid;
        private Guid _enterpriseservicetypeguid;
        private string _enterpriseservicetypename;
        private int? _ishot;
        private int? _isenable;
        private int? _ordernumber;
        private DateTime? _publishdate;
        private string _other01;
        private string _other02;
        /// <summary>
        /// 
        /// </summary>
        public int EnterpriseServiceTypeID
        {
            set { _enterpriseservicetypeid = value; }
            get { return _enterpriseservicetypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid EnterpriseServiceTypeGUID
        {
            set { _enterpriseservicetypeguid = value; }
            get { return _enterpriseservicetypeguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EnterpriseServiceTypeName
        {
            set { _enterpriseservicetypename = value; }
            get { return _enterpriseservicetypename; }
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