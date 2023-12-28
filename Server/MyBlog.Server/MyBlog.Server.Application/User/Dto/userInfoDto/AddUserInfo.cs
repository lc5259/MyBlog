using MyBlog.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Application.User.Dto.userInfoDto
{
    public class AddUserInfo 
    {
       
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Comment("名称")]
        public string name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [DataMember, Column, Comment("编码")]
        public string code { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DataMember, Column, Comment("性别")]
        public int? gender { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DataMember, Column, Comment("性别")]
        public string gender_name { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [DataMember, Column, Comment("真实姓名")]
        public string realname { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember, Column, Comment("邮箱")]
        public string mailbox { get; set; }

        /// <summary>
        /// 个人介绍
        /// </summary>
        [DataMember, Column, Comment("个人介绍")]
        public string introduction { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [DataMember, Column, Comment("手机号码")]
        public string cellphone { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [DataMember, Column, Comment("头像")]
        public string avatar { get; set; }

        /// <summary>
        /// 生活照
        /// </summary>
        [DataMember, Column, Comment("生活照")]
        public string life_photo { get; set; }

        /// <summary>
        /// 角色权限id
        /// </summary>
        [DataMember, Column, Comment("角色权限id")]
        public string roleid { get; set; }

        /// <summary>
        /// Github ID
        /// </summary>
        [DataMember, Column, Comment("Github ID")]
        public string github_id { get; set; }

        /// <summary>
        /// Gitee ID
        /// </summary>
        [DataMember, Column, Comment("Gitee ID")]
        public string gitee_id { get; set; }

        /// <summary>
        /// 角色权限名
        /// </summary>
        [DataMember, Column, Comment("角色权限名")]
        public string roleid_name { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [DataMember, Column, Comment("启用")]
        public bool? statecode { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [DataMember, Column, Comment("启用")]
        public string statecode_name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime ? CreatedTime { get; set; }
    }
}
