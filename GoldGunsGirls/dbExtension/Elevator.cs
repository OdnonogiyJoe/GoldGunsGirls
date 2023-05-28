using ModelsApi;

namespace GoldGunsGirls.db
{
    public partial class Elevator
    {
        public static explicit operator ElevatorApi(Elevator elevator)
        {
            if (elevator == null)
                return null;
            return new ElevatorApi
            {
                Id = elevator.Id,
                Title = elevator.Title,
            };
        }

        public static explicit operator Elevator(ElevatorApi elevator)
        {
            if (elevator == null)
                return null;
            return new Elevator
            {
                Id = elevator.Id,
                Title = elevator.Title,
            };
        }
    }
}
