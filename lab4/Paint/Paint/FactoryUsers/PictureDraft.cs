using Paint.Shapes;
using System;
using System.Collections.Generic;

namespace Paint.FactoryUsers
{
    public class PictureDraft
    {
        private List<Shape> _shapes;

        public PictureDraft()
        {
            _shapes = new List<Shape>();
        }

        public void AddShape( Shape shape )
        {
            _shapes.Add( shape );
        }

        public int GetShapeCount()
        {
            return _shapes.Count;
        }

        public Shape GetShape( int id )
        {
            return id >= _shapes.Count || id < 0 ? throw new IndexOutOfRangeException( "Кeferring to a nonexistent shape" ) : _shapes [ id ];
        }

        public List<Shape> GetShapes()
        {
            return _shapes;
        }
    }
}
