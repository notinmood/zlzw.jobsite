using System;
namespace zlzw.Model
{
    /// <summary>
    /// GeneralImageModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class GeneralImageModel
    {
        public GeneralImageModel()
        { }
        #region Model
        private int _imageid;
        private Guid _imageguid;
        private string _imagename;
        private Guid _relativeguid;
        private string _imagecategorycode;
        private string _imagekind;
        private Guid _ownerguid;
        private string _imagerelativepath;
        private int? _imagesize;
        private int? _imagewidth;
        private int? _imageheight;
        private int? _imagestatus;
        private int? _imageorder;
        private int? _imageismain;
        private int? _canusable;
        private string _imagetype;
        private DateTime? _createtime;
        private string _imagedescription;
        private int? _imagedowncount;
        private int? _imagedisplaycount;
        private string _propertynames;
        private string _propertyvalues;
        /// <summary>
        /// 
        /// </summary>
        public int ImageID
        {
            set { _imageid = value; }
            get { return _imageid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ImageGuid
        {
            set { _imageguid = value; }
            get { return _imageguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImageName
        {
            set { _imagename = value; }
            get { return _imagename; }
        }
        /// <summary>
        /// 关联模块的Guid，比如新闻，比如产品的Guid 图片所属的GUID
        /// </summary>
        public Guid RelativeGuid
        {
            set { _relativeguid = value; }
            get { return _relativeguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImageCategoryCode
        {
            set { _imagecategorycode = value; }
            get { return _imagecategorycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImageKind
        {
            set { _imagekind = value; }
            get { return _imagekind; }
        }
        /// <summary>
        /// 图片所属人的GUID
        /// </summary>
        public Guid OwnerGuid
        {
            set { _ownerguid = value; }
            get { return _ownerguid; }
        }
        /// <summary>
        /// 图片的相对路径
        /// </summary>
        public string ImageRelativePath
        {
            set { _imagerelativepath = value; }
            get { return _imagerelativepath; }
        }
        /// <summary>
        /// 图片实际大小 kb
        /// </summary>
        public int? ImageSize
        {
            set { _imagesize = value; }
            get { return _imagesize; }
        }
        /// <summary>
        /// 图片宽度
        /// </summary>
        public int? ImageWidth
        {
            set { _imagewidth = value; }
            get { return _imagewidth; }
        }
        /// <summary>
        /// 图片高度
        /// </summary>
        public int? ImageHeight
        {
            set { _imageheight = value; }
            get { return _imageheight; }
        }
        /// <summary>
        /// 非管理员使用 图片是否可用 0：不可用
        /// </summary>
        public int? ImageStatus
        {
            set { _imagestatus = value; }
            get { return _imagestatus; }
        }
        /// <summary>
        /// 图片排序
        /// </summary>
        public int? ImageOrder
        {
            set { _imageorder = value; }
            get { return _imageorder; }
        }
        /// <summary>
        /// 是否为主图片 
        /// </summary>
        public int? ImageIsMain
        {
            set { _imageismain = value; }
            get { return _imageismain; }
        }
        /// <summary>
        /// 管理员使用 是否可用状态
        /// </summary>
        public int? CanUsable
        {
            set { _canusable = value; }
            get { return _canusable; }
        }
        /// <summary>
        /// 图片格式类型 bmp jpg png
        /// </summary>
        public string ImageType
        {
            set { _imagetype = value; }
            get { return _imagetype; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 图片描述
        /// </summary>
        public string ImageDescription
        {
            set { _imagedescription = value; }
            get { return _imagedescription; }
        }
        /// <summary>
        /// 图片下载次数
        /// </summary>
        public int? ImageDownCount
        {
            set { _imagedowncount = value; }
            get { return _imagedowncount; }
        }
        /// <summary>
        /// 图片打开次数
        /// </summary>
        public int? ImageDisplayCount
        {
            set { _imagedisplaycount = value; }
            get { return _imagedisplaycount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PropertyNames
        {
            set { _propertynames = value; }
            get { return _propertynames; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PropertyValues
        {
            set { _propertyvalues = value; }
            get { return _propertyvalues; }
        }
        #endregion Model

    }
}