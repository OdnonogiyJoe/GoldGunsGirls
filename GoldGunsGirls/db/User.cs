using System;
using System.Collections.Generic;

namespace GoldGunsGirls.db
{
    public partial class User
    {
        public User()
        {
            Announcements = new HashSet<Announcement>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? RoleId { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
