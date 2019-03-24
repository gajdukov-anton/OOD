namespace Redactor.Document
{
    public class DocumentItem
    {
        public  IImage Image { get; }
        public IParagraph Paragraph { get; }

        public DocumentItem(IImage image)
        {
            Image = image;
        }

        public DocumentItem( IParagraph paragraph )
        {
            Paragraph = paragraph;
        }
    }
}