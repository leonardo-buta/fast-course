using Abp.Authorization;
using FastCourse.Authorization.Roles;
using FastCourse.Authorization.Users;

namespace FastCourse.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
