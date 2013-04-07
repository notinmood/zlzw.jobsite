using System;
namespace zlzw.Model
{
    /// <summary>
    /// jjzpListModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class jjzpListModel
    {
        public jjzpListModel()
        { }
        #region Model
        private int _id;
        private Guid _sysguid;
        private Guid _publishid;
        private string _jjzpcontent;
        private DateTime? _publishdate;
        private int? _isenable = 1;
        private string _other01;
        private string _other02;
        private string _other03;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid SysGUID
        {
            set { _sysguid = value; }
            get { return _sysguid; }
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
        public string jjzpContent
        {
            set { _jjzpcontent = value; }
            get { return _jjzpcontent; }
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
        #endregion Model

    }
}