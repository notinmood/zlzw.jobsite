using System;
namespace zlzw.Model
{
    /// <summary>
    /// CareerGuidanceListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CareerGuidanceListModel
    {
        public CareerGuidanceListModel()
        { }
        #region Model
        private int _careerguidanceid;
        private Guid _careerguidanceguid;
        private string _careerguidancetitle;
        private string _careerguidancecontent;
        private DateTime? _publishdate;
        private int? _isenable;
        private int? _ishot;
        private Guid _publishid;
        private string _other01;
        private string _other02;
        /// <summary>
        /// 就业指导表ID
        /// </summary>
        public int CareerGuidanceID
        {
            set { _careerguidanceid = value; }
            get { return _careerguidanceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid CareerGuidanceGUID
        {
            set { _careerguidanceguid = value; }
            get { return _careerguidanceguid; }
        }
        /// <summary>
        /// 就业指导标题
        /// </summary>
        public string CareerGuidanceTitle
        {
            set { _careerguidancetitle = value; }
            get { return _careerguidancetitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CareerGuidanceContent
        {
            set { _careerguidancecontent = value; }
            get { return _careerguidancecontent; }
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
        /// 发布人GUID
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