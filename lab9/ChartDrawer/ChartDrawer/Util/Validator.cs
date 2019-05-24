using System.Windows.Forms;

namespace ChartDrawer.Util
{
    public static class Validator
    {
        public static double? ProcessTextBoxStringValue( string value )
        {
            double result = 0;
            return double.TryParse( value, out result ) ? ( double? ) result : null;
        }
    }
}
