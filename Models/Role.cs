using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CRUD_ENTITY.NET_CORE.Models
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        [InverseProperty(nameof(Account.RoleldNavigation))]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
