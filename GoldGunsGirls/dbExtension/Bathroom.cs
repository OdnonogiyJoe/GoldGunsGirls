using ModelsApi;

namespace GoldGunsGirls.db
{
    public partial class Bathroom
    {
        public static explicit operator BathroomApi(Bathroom bathroom)
        {
            if (bathroom == null)
                return null;
            return new BathroomApi
            {
                Id = bathroom.Id,
                Title = bathroom.Title,
            };
        }

        public static explicit operator Bathroom(BathroomApi bathroom)
        {
            if (bathroom == null)
                return null;
            return new Bathroom
            {
                Id = bathroom.Id,
                Title = bathroom.Title,
            };
        }
    }
}
