using System;
namespace zlzw.Model
{
    /// <summary>
    /// ParticipatingCompaniesListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ParticipatingCompaniesListModel
    {
        public ParticipatingCompaniesListModel()
        { }
        #region Model
        private int _participatingcompaniesid;
        private Guid _participatingcompaniesguid;
        private Guid _enterpriseguid;
        private string _participatingcompaniescontent;
        private int? _isshow;
        private DateTime? _publishdate;
        private int? _isenable;
        private string _other01;
        private string _other02;
        private string _other03;
        private string _other04;
        /// <summary>
        /// 
        /// </summary>
        public int ParticipatingCompaniesID
        {
            set { _participatingcompaniesid = value; }
            get { return _participatingcompaniesid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ParticipatingCompaniesGUID
        {
            set { _participatingcompaniesguid = value; }
            get { return _participatingcompaniesguid; }
        }
        /// <summary>
        /// 所属企业guid 与企业表关联
        /// </summary>
        public Guid EnterpriseGuid
        {
            set { _enterpriseguid = value; }
            get { return _enterpriseguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParticipatingCompaniesContent
        {
            set { _participatingcompaniescontent = value; }
            get { return _participatingcompaniescontent; }
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
        /// <summary>
        /// 
        /// </summary>
        public string Other04
        {
            set { _other04 = value; }
            get { return _other04; }
        }
        #endregion Model

    }
}