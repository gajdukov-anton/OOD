using Composite.Drawable;
using System.Collections.Generic;

namespace Composite.Groups
{
    public class Shapes : IShapes
    {
        private List<IShape> _shapes;

        public IShape GetShapeAtIndex( int index )
        {
            return _shapes [ index ];
        }

        public int GetShapesCount()
        {
            return _shapes.Count;
        }

        public void InsertShape( IShape shape, int index )
        {
            _shapes.Insert( index, shape );
        }

        public void RemoveShapeAtIndex( int index )
        {
            _shapes.RemoveAt( index );
        }
    }
}
