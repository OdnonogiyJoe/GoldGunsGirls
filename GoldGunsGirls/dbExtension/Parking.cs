using ModelsApi;

namespace GoldGunsGirls.db
{
    public partial class Parking
    {
        public static explicit operator ParkingApi(Parking parking)
        {
            if (parking == null)
                return null;
            return new ParkingApi
            {
                Id = parking.Id,
                Title = parking.Title,
            };
        }

        public static explicit operator Parking(ParkingApi parking)
        {
            if (parking == null)
                return null;
            return new Parking
            {
                Id = parking.Id,
                Title = parking.Title,
            };
        }
    }
}
