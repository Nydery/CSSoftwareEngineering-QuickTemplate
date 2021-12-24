//@BaseCode
//MdStart
using System.ComponentModel.DataAnnotations;

namespace QuickTemplate.Model
{
    public abstract partial class VersionObject : IdentityObject
    {
        /// <summary>
        /// Row version of the entity.
        /// </summary>
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
//MdEnd