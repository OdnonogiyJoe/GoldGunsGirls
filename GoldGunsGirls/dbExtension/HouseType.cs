using ModelsApi;

namespace GoldGunsGirls.db
{
    public partial class HouseType
    {
        public static explicit operator HouseTypeApi(HouseType houseType)
        {
            if (houseType == null)
                return null;
            return new HouseTypeApi
            {
                Id = houseType.Id,
                Title = houseType.Title,
            };
        }

        public static explicit operator HouseType(HouseTypeApi houseType)
        {
            if (houseType == null)
                return null;
            return new HouseType
            {
                Id = houseType.Id,
                Title = houseType.Title,
            };
        }
    }
}
