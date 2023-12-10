using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportArete.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportArete.Infrastructure.Data.Configuration
{
    internal class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(GiveRoles());
        }

        private List<IdentityUserRole<string>> GiveRoles()
        {
            List<IdentityUserRole<string>> rolesGiven = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    RoleId = "d9de7285-b674-454c-9889-5210abb8d347",
                    UserId="dea12856-c198-4129-b3f3-b893d8395082"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "07358494-247c-421c-8f7f-82c12be55276",
                    UserId="6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                }
            };
            return rolesGiven;
        }
    }
}
