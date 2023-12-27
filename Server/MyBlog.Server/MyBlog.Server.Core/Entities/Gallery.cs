
using Furion.DatabaseAccessor;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace MyBlog.Server.Core.Entities
{
    public partial class Gallery : EntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Comment("名称")]
        public string name { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        [DataMember, Column, Comment("标签")]
        public string tags { get; set; }

        /// <summary>
        /// 预览图
        /// </summary>
        [DataMember, Column, Comment("预览图")]
        public string preview_url { get; set; }

        /// <summary>
        /// 大图
        /// </summary>
        [DataMember, Column, Comment("大图")]
        public string image_url { get; set; }

        /// <summary>
        /// 预览图片id
        /// </summary>
        [DataMember, Column, Comment("预览图片id")]
        public string previewid { get; set; }

        /// <summary>
        /// 大图id
        /// </summary>
        [DataMember, Column, Comment("大图id")]
        public string imageid { get; set; }
    }
}

