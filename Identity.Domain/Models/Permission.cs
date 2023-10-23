using Identity.Domain.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Domain.Models
{
    [Table(TableName)]
    public class Permission : AuditableEntity<Guid>
    {
        public const string TableName = "Permissions";

        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public string? Description { get; set; }

        public string Acl { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}