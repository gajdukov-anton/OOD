using ChartDrawer.Model;

namespace ChartDrawer.Util
{
    public static class Convertor
    {
        public static string ConvertHarmonicToStr(IHarmonicPresentation harmonic)
        {
            return $"{harmonic.GetAmplitude()}*{harmonic.GetHarmonicKind().ToString()}({harmonic.GetFrequency()}*x+{harmonic.GetPhase()})";
        }
    }
}
