using System;

namespace Xyl.Test.Domain
{
    /// <summary>
    /// 实体基类。
    /// </summary>
    public abstract class EntityBase
    {
        private Guid _id = Guid.Empty;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastUpdatedOn { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string LastUpdatedBy { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }



        public static Guid NewId()
        {
            return Guid.NewGuid();
        }

        #region 重新操作符

        public override bool Equals(object entity)
        {
            if (entity == null || !(entity is EntityBase))
            {
                return false;
            }
            return (this == (EntityBase)entity);
        }

        public static bool operator ==(EntityBase entity1, EntityBase entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            return entity1.Id == entity2.Id;
        }

        public static bool operator !=(EntityBase entity1, EntityBase entity2)
        {
            return (!(entity1 == entity2));
        }

        #endregion

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public virtual void Init(string userName)
        {
            this.Id = NewId();
            this.CreatedOn = DateTime.Now;
            this.CreatedBy = userName;
        }

        public virtual void InitUpdate(string userName)
        {
            this.LastUpdatedOn = DateTime.Now;
            this.LastUpdatedBy = userName;
        }

    }
}