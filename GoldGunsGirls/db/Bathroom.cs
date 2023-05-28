using System;
using System.Collections.Generic;

namespace GoldGunsGirls.db
{
    public partial class Bathroom
    {
        public Bathroom()
        {
            Announcements = new HashSet<Announcement>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
