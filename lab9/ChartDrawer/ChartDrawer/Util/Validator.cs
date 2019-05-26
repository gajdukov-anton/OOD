using System.Windows.Forms;

namespace ChartDrawer.Util
{
    public static class Validator
    {
        public static double? ProcessTextBoxStringValue( string value )
        {
            return double.TryParse( value, out double result ) ? ( double? ) result : null;
        }
    }
}
