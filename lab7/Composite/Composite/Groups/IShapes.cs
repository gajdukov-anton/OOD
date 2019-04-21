using Composite.Drawable;

namespace Composite.Groups
{
    public interface IShapes
    {
        int GetShapesCount();
        IShape GetShapeAtIndex( int index );
        void InsertShape( IShape shape, int index );
        void RemoveShapeAtIndex( int index );
    }
}
