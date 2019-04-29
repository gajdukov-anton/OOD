﻿using System.Collections.Generic;
using System.Drawing;
using Composite.Drawable;

namespace Composite.Groups
{
    public class GroupStyle : IStyle
    {
        protected readonly IEnumerable<IStyle> _styles;

        public GroupStyle( IEnumerable<IStyle> styles)
        {
            _styles = styles;
        }

        public void Enable( bool enable )
        {
            foreach ( var style in _styles )
            {
                style.Enable( enable );
            }
        }

        public bool IsEnable()
        {
            bool isEnable = GetFirstEnable();
            return IsAllStylesEnableEqual( isEnable ) ? isEnable : false;
        }

        public void SetColor( Color color )
        {
            foreach ( var style in _styles )
            {
                style.SetColor( color );
            }
        }

        public Color GetColor()
        {
            var color = GetFirstColor();
            return IsAllColorsEqual( color ) ? color : Color.Empty;
        }

        protected bool IsStylesEmpty()
        {
            foreach ( var style in _styles )
            {
                return false;
            }
            return true;
        }

        private Color GetFirstColor()
        {
            foreach ( var style in _styles )
            {
                return style.GetColor();
            }
            return Color.Empty;
        }

        private bool GetFirstEnable()
        {
            foreach ( var style in _styles )
            {
                return style.IsEnable();
            }
            return false;
        }

        private bool IsAllColorsEqual( Color color )
        {
            if (_styles == null)
            {
                return false;
            }

            foreach ( var style in _styles )
            {
                if ( style.GetColor() != color )
                {
                    return false;
                }
            }
            return !IsStylesEmpty();
        }

        private bool IsAllStylesEnableEqual(bool isEnable)
        {
            if ( _styles == null )
            {
                return false;
            }

            foreach ( var stytle in _styles )
            {
                if (stytle.IsEnable() != isEnable)
                {
                    return false;
                }
            }

            return !IsStylesEmpty();
        }
    }
}