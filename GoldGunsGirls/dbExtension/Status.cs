using ModelsApi;

namespace GoldGunsGirls.db
{
    public partial class Status
    {
        public static explicit operator StatusApi(Status status)
        {
            if (status == null)
                return null;
            return new StatusApi
            {
                Id = status.Id,
                Title = status.Title,
            };
        }

        public static explicit operator Status(StatusApi status)
        {
            if (status == null)
                return null;
            return new Status
            {
                Id = status.Id,
                Title = status.Title,
            };
        }
    }
}
