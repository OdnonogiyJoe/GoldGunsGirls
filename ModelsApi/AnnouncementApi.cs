using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class AnnouncementApi : ApiBaseType
    {
        public int? UserId { get; set; }
        public string? Description { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public string? Street { get; set; }
        public decimal Price { get; set; }
        public int? ApartmentTypeId { get; set; }
        public int? HouseTypeId { get; set; }
        public int? BathroomId { get; set; }
        public int? ParkingId { get; set; }
        public string? FloorsInTheApartment { get; set; }
        public int? StatusId { get; set; }
        public int? RepairId { get; set; }
        public int? WindowId { get; set; }
        public int? BalconyOrLoggiaId { get; set; }
        public int? ElevatorId { get; set; }
        public string? TotalArea { get; set; }
    }
}
