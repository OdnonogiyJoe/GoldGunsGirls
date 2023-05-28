using ModelsApi;

namespace GoldGunsGirls.db
{
    public partial class Repair
    {
        public static explicit operator RepairApi(Repair repair)
        {
            if (repair == null)
                return null;
            return new RepairApi
            {
                Id = repair.Id,
                Title = repair.Title,
            };
        }

        public static explicit operator Repair(RepairApi repair)
        {
            if (repair == null)
                return null;
            return new Repair
            {
                Id = repair.Id,
                Title = repair.Title,
            };
        }
    }
}
