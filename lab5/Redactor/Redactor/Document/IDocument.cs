using System.IO;

namespace Redactor.Document
{
    public interface IDocument
    {
        IParagraph InsertParagraph( string text, int? position = null );
        IImage InsertImage( string path, int width, int height, int? position = null );
        int GetItemsCount();
        DocumentItem GetItem( int index );
        void DeleteItem( int index );
        Title GetTitle();
        void SetTitle( string title );
        bool CanUndo();
        void Undo();
        bool CanRedo();
        void Redo();
        void Save( string path );
        void ReplaceText( int index, string text );
    }
}
