using ModelsApi;

namespace GoldGunsGirls.db
{
    public partial class City
    {
        public static explicit operator CityApi(City city)
        {
            if (city == null)
                return null;
            return new CityApi
            {
                Id = city.Id,
                Title = city.Title,
            };
        }

        public static explicit operator City(CityApi city)
        {
            if (city == null)
                return null;
            return new City
            {
                Id = city.Id,
                Title = city.Title,
            };
        }
    }
}
