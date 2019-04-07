namespace Adapter.ModernGraphicsLib
{
    public class RGBAColor
    {
        public float R { set; get; }
        public float G { set; get; }
        public float B { set; get; }
        public float A { set; get; }

        public RGBAColor()
        {

        }

        public RGBAColor(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
