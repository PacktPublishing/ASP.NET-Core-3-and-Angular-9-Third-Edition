using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCities.Tests
{
    public static class IdentityHelper
    {
        public static RoleManager<TIdentityRole> GetRoleManager<TIdentityRole>(
            IRoleStore<TIdentityRole> roleStore) where TIdentityRole : IdentityRole
        {
            return new RoleManager<TIdentityRole>(
                    roleStore,
                    new IRoleValidator<TIdentityRole>[0],
                    new UpperInvariantLookupNormalizer(),
                    new Mock<IdentityErrorDescriber>().Object,
                    new Mock<ILogger<RoleManager<TIdentityRole>>>().Object);
        }

        public static UserManager<TIDentityUser> GetUserManager<TIDentityUser>(
            IUserStore<TIDentityUser> userStore) where TIDentityUser : IdentityUser
        {
            return new UserManager<TIDentityUser>(
                    userStore,
                    new Mock<IOptions<IdentityOptions>>().Object,
                    new Mock<IPasswordHasher<TIDentityUser>>().Object,
                    new IUserValidator<TIDentityUser>[0],
                    new IPasswordValidator<TIDentityUser>[0],
                    new UpperInvariantLookupNormalizer(),
                    new Mock<IdentityErrorDescriber>().Object,
                    new Mock<IServiceProvider>().Object,
                    new Mock<ILogger<UserManager<TIDentityUser>>>().Object);
        }
    }
}