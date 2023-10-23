using Identity.Domain.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Domain.Models
{
    [Table(TableName)]
    public class RolePermission : AuditableEntity<Guid>
    {
        public const string TableName = "RolePermission";

        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }

        public Role Role { get; set; }

        public Permission Permission { get; set; }
    }
}