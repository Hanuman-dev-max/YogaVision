namespace YogaVision.Infrastructure.Data.Identity
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Infrastructure.Data.Common.Models;
    using YogaVision.Infrastructure.Data.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            YogaEvents = new HashSet<YogaEventApplicationUser>();

        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public ICollection<YogaEventApplicationUser> YogaEvents { get; set; }
    }
       
}
