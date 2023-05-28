using ModelsApi;

namespace GoldGunsGirls.db
{
    public partial class Window
    { 
        public static explicit operator WindowApi(Window window)
    {
        if (window == null)
            return null;
        return new WindowApi
        {
            Id = window.Id,
            Title = window.Title,
        };
    }

    public static explicit operator Window(WindowApi window)
    {
        if (window == null)
            return null;
        return new Window
        {
            Id = window.Id,
            Title = window.Title,
        };
    }
    }
}
