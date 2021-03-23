using System;
using System.ComponentModel.DataAnnotations;
using Applications.Domain.Base;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class PropertyPicture : DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        [MaxLength(255)] 
        public string PictureUrl { get; set; } = default!;

        [MaxLength(15)]
        public string Title { get; set; } = default!;
        
        public Guid PropertyId { get; set; }
        public Property? Property { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}