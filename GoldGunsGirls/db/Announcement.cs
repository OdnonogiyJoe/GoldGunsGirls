using System;
using System.Collections.Generic;

namespace GoldGunsGirls.db
{
    public partial class Announcement
    {
        public int Id { get; set; }
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

        public virtual ApartmentType? ApartmentType { get; set; }
        public virtual BalconyOrLoggium? BalconyOrLoggia { get; set; }
        public virtual Bathroom? Bathroom { get; set; }
        public virtual City? City { get; set; }
        public virtual District? District { get; set; }
        public virtual Elevator? Elevator { get; set; }
        public virtual HouseType? HouseType { get; set; }
        public virtual Parking? Parking { get; set; }
        public virtual Repair? Repair { get; set; }
        public virtual Status? Status { get; set; }
        public virtual User? User { get; set; }
        public virtual Window? Window { get; set; }
    }
}
