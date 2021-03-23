using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Applications.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class PropertyType : DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        [MaxLength(32)] public string PropertyTypeValue { get; set; } = default!;
        
        public ICollection<Property>? Properties { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}