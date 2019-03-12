using Paint.Shapes;

namespace Paint.Factory
{
    public interface IShapeFactory
    {
        Shape CreateShape( string deacription );
    }
}
