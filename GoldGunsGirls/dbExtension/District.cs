using ModelsApi;

namespace GoldGunsGirls.db
{ 
    public partial class District
    {
        public static explicit operator DistrictApi(District district)
        {
            if (district == null)
                return null;
            return new DistrictApi
            {
                Id = district.Id,
                Title = district.Title,
            };
        }

        public static explicit operator District(DistrictApi district)
        {
            if (district == null)
                return null;
            return new District
            {
                Id = district.Id,
                Title = district.Title,
            };
        }
    }
}
