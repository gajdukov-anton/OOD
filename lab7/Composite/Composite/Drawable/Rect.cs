namespace Composite.Drawable
{
    public class Rect<T>
    {
        public T Left { private set; get; }
        public T Width { private set; get; }
        public T Top { private set; get; }
        public T Height { private set; get; }

        public Rect(T left, T width, T top, T height)
        {
            Left = left;
            Width = width;
            Top = top;
            Height = height;
        }
    }
}
