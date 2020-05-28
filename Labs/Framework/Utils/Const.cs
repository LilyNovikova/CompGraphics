using Framework.Models;

namespace Framework.Utils
{
    public static class Const
    {
        public static Point3 ViewPoint => new Point3(10000, 10000, 10000);
        public static Point3 LightPoint { get; set; } = new Point3(-10000, 10000, 10000);
    }
}
