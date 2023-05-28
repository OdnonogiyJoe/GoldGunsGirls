using ModelsApi;

namespace GoldGunsGirls.db
{
    public partial class BalconyOrLoggium
    {
        public static explicit operator BalconyOrLoggiumApi(BalconyOrLoggium balconyOrLoggium)
        {
            if (balconyOrLoggium == null)
                return null;
            return new BalconyOrLoggiumApi
            {
                Id = balconyOrLoggium.Id,
                Title = balconyOrLoggium.Title,
            };
        }

        public static explicit operator BalconyOrLoggium(BalconyOrLoggiumApi balconyOrLoggium)
        {
            if (balconyOrLoggium == null)
                return null;
            return new BalconyOrLoggium
            {
                Id = balconyOrLoggium.Id,
                Title = balconyOrLoggium.Title,
            };
        }
    }
}
