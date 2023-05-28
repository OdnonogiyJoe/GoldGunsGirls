using ModelsApi;

namespace GoldGunsGirls.db
{
    public partial class ApartmentType
    {
        public static explicit operator ApartmentTypeApi(ApartmentType apartmentType)
        {
            if (apartmentType == null)
                return null;
            return new ApartmentTypeApi
            {
                Id = apartmentType.Id,
                Title = apartmentType.Title,
            };
        }

        public static explicit operator ApartmentType(ApartmentTypeApi apartmentType)
        {
            if (apartmentType == null)
                return null;
            return new ApartmentType
            {
                Id = apartmentType.Id,
                Title = apartmentType.Title,
            };
        }
    }
}
