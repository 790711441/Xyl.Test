using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xyl.Test.Domain;

namespace Xyl.Test.Models.Data
{
    /// <summary>
    /// 机构
    /// </summary>
    public class Organization : EntityBase
    {
        /// <summary>
        /// 父ID
        /// </summary>
        public Nullable<Guid> ParentId { get; set; }

        /// <summary>
        /// 上面的父节点
        /// </summary>
        public virtual Organization Parent { get; set; }

        /// <summary>
        /// 下面的子节点
        /// </summary>
        [ForeignKey("ParentId")]
        [Display(Name = "上级")]
        public virtual ICollection<Organization> Children { get; set; }

        /// <summary>
        /// 类别名字
        /// </summary>
        [Required]
        [StringLength(20, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 2)]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public OrgState State { get; set; }
    }

    /// <summary>
    /// 机构状态
    /// </summary>
    public enum OrgState
    {
        Normal = 0,
        Disable = 1,
    }
}