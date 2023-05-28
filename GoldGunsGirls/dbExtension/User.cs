using ModelsApi;

namespace GoldGunsGirls.db
{
    public partial class User
    {
        public static explicit operator UserApi(User user)
        {
            if (user == null)
                return null;
            return new UserApi
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                RoleId = user.RoleId,
            };
        }

        public static explicit operator User(UserApi user)
        {
            if (user == null)
                return null;
            return new User
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                RoleId = user.RoleId,
            };
        }
    }
}
