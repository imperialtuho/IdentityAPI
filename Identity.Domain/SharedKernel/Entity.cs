using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.SharedKernel
{
    public abstract class Entity<TId>
    {
        [Key]
        public TId Id { get; set; }
    }
}