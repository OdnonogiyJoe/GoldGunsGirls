using ModelsApi;

namespace GoldGunsGirls.db
{
    public partial class Announcement
    {
        public static explicit operator AnnouncementApi(Announcement announcement)
        {
            if (announcement == null)
                return null;
            return new AnnouncementApi
            {
                Id = announcement.Id,
                UserId = announcement.UserId,
                Description = announcement.Description,
                CityId = announcement.CityId,
                DistrictId = announcement.DistrictId,
                Street = announcement.Street,
                Price = announcement.Price,
                ApartmentTypeId = announcement.ApartmentTypeId,
                HouseTypeId = announcement.HouseTypeId,
                BathroomId = announcement.BathroomId,
                ParkingId = announcement.ParkingId,
                FloorsInTheApartment = announcement.FloorsInTheApartment,
                StatusId = announcement.StatusId,
                RepairId = announcement.RepairId,
                WindowId = announcement.WindowId,
                BalconyOrLoggiaId = announcement.BalconyOrLoggiaId,
                ElevatorId = announcement.ElevatorId,
                TotalArea = announcement.TotalArea,
            };
        }

        public static explicit operator Announcement(AnnouncementApi announcement)
        {
            if (announcement == null)
                return null;
            return new Announcement
            {
                Id = announcement.Id,
                UserId = announcement.UserId,
                Description = announcement.Description,
                CityId = announcement.CityId,
                DistrictId = announcement.DistrictId,
                Street = announcement.Street,
                Price = announcement.Price,
                ApartmentTypeId = announcement.ApartmentTypeId,
                HouseTypeId = announcement.HouseTypeId,
                BathroomId = announcement.BathroomId,
                ParkingId = announcement.ParkingId,
                FloorsInTheApartment = announcement.FloorsInTheApartment,
                StatusId = announcement.StatusId,
                RepairId = announcement.RepairId,
                WindowId = announcement.WindowId,
                BalconyOrLoggiaId = announcement.BalconyOrLoggiaId,
                ElevatorId = announcement.ElevatorId,
                TotalArea = announcement.TotalArea,
            };
        }
    }
}
