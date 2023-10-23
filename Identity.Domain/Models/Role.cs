using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Domain.Models
{
    [Table(TableName)]
    public class Role : IdentityRole<Guid>
    {
        public const string TableName = "Role";

        public Role()
        {
            RolePermissions = new HashSet<RolePermission>();
            UserRoles = new HashSet<Role>();
        }

        public string Code { get; set; }

        public int RoleOrder { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        public virtual ICollection<Role> UserRoles { get; set; }
    }
}