using Paint.UI;

namespace Paint.Shapes
{
    public abstract class Shape
    {
        private Color _color;

        public Shape(Color color)
        {
            _color = color;
        }

        public Color GetColor()
        {
            return _color;
        }

        public abstract void Draw( ICanvas canvas );
    }
}
