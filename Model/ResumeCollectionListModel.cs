using System;
namespace zlzw.Model
{
    /// <summary>
    /// ResumeCollectionListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ResumeCollectionListModel
    {
        public ResumeCollectionListModel()
        { }
        #region Model
        private int _resumecollectionid;
        private Guid _resumecollectionguid;
        private int? _resumecollectiontype;
        private Guid _resumeguid;
        private Guid _enterpriseguid;
        private int? _enterpriseisdel;
        private int? _isenable;
        private DateTime? _publishdate;
        private string _other01;
        private string _other02;
        private string _other03;
        private string _other04;
        private int? _other05;
        /// <summary>
        /// 
        /// </summary>
        public int ResumeCollectionID
        {
            set { _resumecollectionid = value; }
            get { return _resumecollectionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ResumeCollectionGUID
        {
            set { _resumecollectionguid = value; }
            get { return _resumecollectionguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ResumeCollectionType
        {
            set { _resumecollectiontype = value; }
            get { return _resumecollectiontype; }
        }
        /// <summary>
        /// 简历表的GUID
        /// </summary>
        public Guid ResumeGuid
        {
            set { _resumeguid = value; }
            get { return _resumeguid; }
        }
        /// <summary>
        /// 企业表GUID
        /// </summary>
        public Guid EnterpriseGuid
        {
            set { _enterpriseguid = value; }
            get { return _enterpriseguid; }
        }
        /// <summary>
        /// 企业是否删除简历
        /// </summary>
        public int? EnterpriseIsDel
        {
            set { _enterpriseisdel = value; }
            get { return _enterpriseisdel; }
        }
        /// <summary>
        /// 是否可用（管理员删除标记）
        /// </summary>
        public int? IsEnable
        {
            set { _isenable = value; }
            get { return _isenable; }
        }
        /// <summary>
        /// 收藏日期
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
        /// <summary>
        /// 
        /// </summary>
        public int? Other05
        {
            set { _other05 = value; }
            get { return _other05; }
        }
        #endregion Model

    }
}