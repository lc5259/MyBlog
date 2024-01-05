using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Core.Entities.Abstract
{
    /// <summary>
    /// 自定义实体基类
    /// </summary>
    public abstract class DEntityBase<TKey> : DEntityBase<TKey, MasterDbContextLocator>
    {

    }

    public abstract class DEntityBase<TKey, TDbContextLocator1> : PrivateDEntityBase<TKey>
        where TDbContextLocator1 : class, IDbContextLocator
    {
    }

    public abstract class PrivateDEntityBase<TKey> : IPrivateEntity
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Id主键")]
        public virtual TKey Id { get; set; }
     
    }
}
