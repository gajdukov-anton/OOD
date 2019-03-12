using Paint.Shapes;
using System;
using System.Text.RegularExpressions;

namespace Paint.Factory
{
    public class ShapeFactory : IShapeFactory
    {
        public ShapeFactory()
        {
        }

        public Shape CreateShape( string description )
        {
            string [] shapeParams = description.Split( new char [] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
            switch ( shapeParams [ 0 ].ToLower() )
            {
                case "rectangle":
                    return CreateRectangle( shapeParams );
                case "triangle":
                    return CreateTriangle( shapeParams );
                case "ellipse":
                    return CreateEllipse( shapeParams );
                case "regularpolygon":
                    return CreateRegularPolygon( shapeParams );
                default:
                    throw new ArgumentException( "Incorrect name of shape", "shapeParams" );
            }
        }

        private Shape CreateTriangle( string [] triangleParams )
        {
            if ( triangleParams.Length == 8 )
            {
                Color color = StringToColor( triangleParams [ 1 ] );
                Point vertex1 = new Point( Convert.ToDouble( triangleParams [ 2 ] ), Convert.ToDouble( triangleParams [ 3 ] ) );
                Point vertex2 = new Point( Convert.ToDouble( triangleParams [ 4 ] ), Convert.ToDouble( triangleParams [ 5 ] ) );
                Point vertex3 = new Point( Convert.ToDouble( triangleParams [ 6 ] ), Convert.ToDouble( triangleParams [ 7 ] ) );
                return new Triangle( vertex1, vertex2, vertex3, color );
            }
            else
            {
                throw new ArgumentException( "Incorrect amount parametrs for create triangle", "triangleParams" );
            }
        }

        private Shape CreateRectangle( string [] rectangleParams )
        {
            if ( rectangleParams.Length == 6 )
            {
                Color color = StringToColor( rectangleParams [ 1 ] );
                Point leftTopVertex = new Point( Convert.ToDouble( rectangleParams [ 2 ] ), Convert.ToDouble( rectangleParams [ 3 ] ) );
                Point rightBottomVertex = new Point( Convert.ToDouble( rectangleParams [ 4 ] ), Convert.ToDouble( rectangleParams [ 5 ] ) );
                return new Rectangle( leftTopVertex, rightBottomVertex, color );
            }
            else
            {
                throw new ArgumentException( "Incorrect amount parametrs for create rectangle", "rectangleParams" );
            }
        }

        private Shape CreateEllipse( string [] ellipseParams )
        {
            if ( ellipseParams.Length == 6 )
            {
                Color color = StringToColor( ellipseParams [ 1 ] );
                Point center = new Point( Convert.ToDouble( ellipseParams [ 2 ] ), Convert.ToDouble( ellipseParams [ 3 ] ) );
                double horizontalRadius = Convert.ToDouble( ellipseParams [ 4 ] );
                double verticalRadius = Convert.ToDouble( ellipseParams [ 5 ] );
                return new Ellipse( center, horizontalRadius, verticalRadius, color );
            }
            else
            {
                throw new ArgumentException( "Incorrect amount parametrs for create ellipse", "ellipseParams" );
            }
        }

        private Shape CreateRegularPolygon( string [] polygonParams )
        {
            if ( polygonParams.Length == 6 )
            {
                Color color = StringToColor( polygonParams [ 1 ] );
                Point center = new Point( Convert.ToDouble( polygonParams [ 2 ] ), Convert.ToDouble( polygonParams [ 3 ] ) );
                int vertexCount = Convert.ToInt32( polygonParams [ 4 ] );
                double radius = Convert.ToDouble( polygonParams [ 5 ] );
                return new RegularPolygon( center, vertexCount, radius, color );
            }
            else
            {
                throw new ArgumentException( "Incorrect amount parametrs for create regular polygon", "polygonParams" );
            }
        }

        private Color StringToColor( string colorStr )
        {
            switch ( colorStr.ToLower() )
            {
                case "black":
                    return Color.Black;
                case "red":
                    return Color.Red;
                case "blue":
                    return Color.Blue;
                case "yellow":
                    return Color.Yellow;
                case "pink":
                    return Color.Pink;
                case "green":
                    return Color.Green;
                default:
                    throw new ArgumentException( "Incorrect color value", "colorStr" );
            }
        }
    }
}
