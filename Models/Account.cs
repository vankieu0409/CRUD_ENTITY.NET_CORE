using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CRUD_ENTITY.NET_CORE.Models
{
    public partial class Account
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Acc { get; set; }
        [StringLength(50)]
        public string Pass { get; set; }
        public Guid? Roleld { get; set; }

        [ForeignKey(nameof(Roleld))]
        [InverseProperty(nameof(Role.Accounts))]
        public virtual Role RoleldNavigation { get; set; }
    }
}
