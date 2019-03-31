using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Redactor;
using Redactor.Utils;

namespace RedactorUnitTest
{
    [TestClass]
    public class CommandsTest
    {
        Client _client;
        StringWriter _stringWriter;

        [TestMethod]
        public void InsertParagraphTest()
        { 
            _stringWriter = new StringWriter();
            _client = new Client( _stringWriter, Console.In );
            Menu menu = _client.GetMenu();
            menu.ExecuteCommand( "insertParagraph" ); 
            menu.ExecuteCommand( "insertParagraph 12" );
            menu.ExecuteCommand( "insertParagraph 12 qwerty" );
            menu.ExecuteCommand( "insertParagraph   end     qwerty" );
            Assert.AreEqual( 1, _client.GetDocument().GetItemsCount() );
            Assert.AreEqual( "    qwerty", _client.GetDocument().GetItem( 0 ).Paragraph.GetText() );
            menu.ExecuteCommand( "insertParagraph 0 koshka" );
            Assert.AreEqual( 2, _client.GetDocument().GetItemsCount() );
            Assert.AreEqual( "koshka", _client.GetDocument().GetItem( 0 ).Paragraph.GetText() );
            Assert.AreEqual( Constants.INVALID_AMOUNT_PARAMETRS_FOR_INSERT_PARAGRAPH + "\r\n" 
                            + Constants.INVALID_AMOUNT_PARAMETRS_FOR_INSERT_PARAGRAPH + "\r\n"
                            + Constants.INDEX_OUT_OF_RANGE_ERROR + "\r\n", _stringWriter.ToString() );
        }

        [TestMethod]
        public void SetTitleTest()
        {
            _stringWriter = new StringWriter();
            _client = new Client( _stringWriter, Console.In );
            Menu menu = _client.GetMenu();
            menu.ExecuteCommand( "setTitle" );
            menu.ExecuteCommand( "setttitle" );
            menu.ExecuteCommand( "setTitle big   title" );
            Assert.AreEqual( " big   title", _client.GetDocument().GetTitle().Value );
            Assert.AreEqual( Constants.INVALID_AMOUNT_PARAMETRS_FOR_SET_TITLE + "\r\n"
                           + Constants.UNRKNOW_COMMAND + "\r\n", _stringWriter.ToString() );
        }

        [TestMethod]
        public void HelpTest()
        {
            _stringWriter = new StringWriter();
            _client = new Client( _stringWriter, Console.In );
            Menu menu = _client.GetMenu();
            menu.ExecuteCommand( "help" );
            StringWriter stringWriter = new StringWriter();
            stringWriter.WriteLine( "Commands list:" );
            stringWriter.WriteLine( $" {Constants.INSERT_PARAGRAPH_COMMAND_NAME}: {Constants.INSERT_PARAGRAPH_COMMAND_DESCRIPTION}" );
            stringWriter.WriteLine( $" {Constants.SET_TITLE_COMMAND_NAME}: {Constants.SET_TITLE_COMMAND_DESCRIPTION}" );
            stringWriter.WriteLine( $" {Constants.LIST_COMMAND_NAME}: {Constants.LIST_COMMAND_DESCRIPTION}" );
            stringWriter.WriteLine( $" {Constants.HELP_COMMAND_NAME}: {Constants.HELP_COMMAND_DESCRIPTION}" );
            stringWriter.WriteLine( $" {Constants.EXIT_COMMAND_NAME}: {Constants.EXIT_COMMAND_DESCRIPTION}" );
            stringWriter.WriteLine( $" {Constants.REPLACE_TEXT_COMMAND_NAME}: {Constants.REPLACE_TEXT_COMMAND_DESCRIPTION}" );
            stringWriter.WriteLine( $" {Constants.UNDO_COMMAND_NAME}: {Constants.UNDO_COMMAND_DESCRIPTION}" );
            stringWriter.WriteLine( $" {Constants.REDO_COMMAND_NAME}: {Constants.REDO_COMMAND_DESCRIPTION}" );
            stringWriter.WriteLine( $" {Constants.DELETE_ITEM_COMMAND_NAME}: {Constants.DELETE_ITEM_COMMAND_DESCRIPTION}" );
            stringWriter.WriteLine( $" {Constants.SAVE_COMMAND_NAME}: {Constants.SAVE_COMMAND_DESCRIPTION}" );
            stringWriter.WriteLine( $" {Constants.INSERT_IMAGE_COMMAND_NAME}: {Constants.INSERT_IMAGE_COMMAND_DESCRIPTION}" );
            stringWriter.WriteLine( $" {Constants.RESIZE_IMAGE_COMMAND_NAME}: {Constants.RESIZE_IMAGE_COMMAND_DESCRIPTION}" );
            Assert.AreEqual( stringWriter.ToString(), _stringWriter.ToString() );
        }

        [TestMethod]
        public void ListTest()
        {
            _stringWriter = new StringWriter();
            StringWriter stringWriter = new StringWriter();
            _client = new Client( _stringWriter, Console.In );
            Menu menu = _client.GetMenu();
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            Assert.AreEqual( stringWriter.ToString(), _stringWriter.ToString() );
            menu.ExecuteCommand( "setTitle big   title" );
            menu.ExecuteCommand( "insertParagraph end  end     qwerty" );
            menu.ExecuteCommand( "insertParagraph end  end     qwerty" );
            stringWriter.WriteLine( "Title:  big   title" );
            stringWriter.WriteLine( "0. Paragraph:  end     qwerty" );
            stringWriter.WriteLine( "1. Paragraph:  end     qwerty" );
            menu.ExecuteCommand( "list" );
            Assert.AreEqual( stringWriter.ToString(), _stringWriter.ToString() );
        }

        [TestMethod]
        public void UndoTest()
        {
            _stringWriter = new StringWriter();
            StringWriter stringWriter = new StringWriter();
            _client = new Client( _stringWriter, Console.In );
            Menu menu = _client.GetMenu();
            menu.ExecuteCommand( "insertParagraph end 1" );
            menu.ExecuteCommand( "insertParagraph end 2" );
            menu.ExecuteCommand( "insertParagraph end 3" );
            menu.ExecuteCommand( "insertParagraph end 4" );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            stringWriter.WriteLine( "0. Paragraph: 1" );
            stringWriter.WriteLine( "1. Paragraph: 2" );
            stringWriter.WriteLine( "2. Paragraph: 3" );
            stringWriter.WriteLine( "3. Paragraph: 4" );
            menu.ExecuteCommand( "Undo" );
            menu.ExecuteCommand( "Undo" );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            stringWriter.WriteLine( "0. Paragraph: 1" );
            stringWriter.WriteLine( "1. Paragraph: 2" );
            menu.ExecuteCommand( "insertParagraph end 5" );
            menu.ExecuteCommand( "insertParagraph end 6" );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            stringWriter.WriteLine( "0. Paragraph: 1" );
            stringWriter.WriteLine( "1. Paragraph: 2" );
            stringWriter.WriteLine( "2. Paragraph: 5" );
            stringWriter.WriteLine( "3. Paragraph: 6" );
            menu.ExecuteCommand( "Undo" );
            menu.ExecuteCommand( "Undo" );
            menu.ExecuteCommand( "Undo" );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            stringWriter.WriteLine( "0. Paragraph: 1" );
            menu.ExecuteCommand( "Undo" );
            menu.ExecuteCommand( "Undo" );
            stringWriter.WriteLine( Constants.IMPOSSIBLE_TO_UNDO );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            Assert.AreEqual( stringWriter.ToString(), _stringWriter.ToString() );
        }

        [TestMethod]
        public void RedoTest()
        {
            _stringWriter = new StringWriter();
            StringWriter stringWriter = new StringWriter();
            _client = new Client( _stringWriter, Console.In );
            Menu menu = _client.GetMenu();
            menu.ExecuteCommand( "insertParagraph end 1" );
            menu.ExecuteCommand( "insertParagraph end 2" );
            menu.ExecuteCommand( "insertParagraph end 3" );
            menu.ExecuteCommand( "insertParagraph end 4" );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            stringWriter.WriteLine( "0. Paragraph: 1" );
            stringWriter.WriteLine( "1. Paragraph: 2" );
            stringWriter.WriteLine( "2. Paragraph: 3" );
            stringWriter.WriteLine( "3. Paragraph: 4" );
            menu.ExecuteCommand( "Undo" );
            menu.ExecuteCommand( "Undo" );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            stringWriter.WriteLine( "0. Paragraph: 1" );
            stringWriter.WriteLine( "1. Paragraph: 2" );
            menu.ExecuteCommand( "Redo" );
            menu.ExecuteCommand( "Redo" );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            stringWriter.WriteLine( "0. Paragraph: 1" );
            stringWriter.WriteLine( "1. Paragraph: 2" );
            stringWriter.WriteLine( "2. Paragraph: 3" );
            stringWriter.WriteLine( "3. Paragraph: 4" );
            menu.ExecuteCommand( "Undo" );
            menu.ExecuteCommand( "Undo" );
            menu.ExecuteCommand( "insertParagraph end 5" );
            menu.ExecuteCommand( "insertParagraph end 6" );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            stringWriter.WriteLine( "0. Paragraph: 1" );
            stringWriter.WriteLine( "1. Paragraph: 2" );
            stringWriter.WriteLine( "2. Paragraph: 5" );
            stringWriter.WriteLine( "3. Paragraph: 6" );
            menu.ExecuteCommand( "Redo" );
            stringWriter.WriteLine( Constants.IMPOSSIBLE_TO_REDO );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            stringWriter.WriteLine( "0. Paragraph: 1" );
            stringWriter.WriteLine( "1. Paragraph: 2" );
            stringWriter.WriteLine( "2. Paragraph: 5" );
            stringWriter.WriteLine( "3. Paragraph: 6" );
            Assert.AreEqual( stringWriter.ToString(), _stringWriter.ToString() );
        }

        [TestMethod]
        public void DeleteItemTest()
        {
            _stringWriter = new StringWriter();
            StringWriter stringWriter = new StringWriter();
            _client = new Client( _stringWriter, Console.In );
            Menu menu = _client.GetMenu();
            menu.ExecuteCommand( "insertParagraph end 1" );
            menu.ExecuteCommand( "insertParagraph end 2" );
            menu.ExecuteCommand( "insertParagraph end 3" );
            menu.ExecuteCommand( "insertParagraph end 4" );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            stringWriter.WriteLine( "0. Paragraph: 1" );
            stringWriter.WriteLine( "1. Paragraph: 2" );
            stringWriter.WriteLine( "2. Paragraph: 3" );
            stringWriter.WriteLine( "3. Paragraph: 4" );
            menu.ExecuteCommand( "deleteItem" );
            stringWriter.WriteLine( Constants.INVALID_AMOUNT_PARAMETRS_FOR_DELETE_ITEM );
            menu.ExecuteCommand( "deleteItem 5" );
            stringWriter.WriteLine( Constants.INDEX_OUT_OF_RANGE_ERROR );
            menu.ExecuteCommand( "deleteItem 2" );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            stringWriter.WriteLine( "0. Paragraph: 1" );
            stringWriter.WriteLine( "1. Paragraph: 2" );
            stringWriter.WriteLine( "2. Paragraph: 4" );
            menu.ExecuteCommand( "insertImage end 1000 1000 E:\\обои\\test.png" );
            string path = _client.GetDocument().GetItem( 3 ).Image.GetPath();
            FileInfo fileInf = new FileInfo( path );
            Assert.IsTrue( fileInf.Exists );
            menu.ExecuteCommand( "deleteItem 3" );
            menu.ExecuteCommand( "deleteItem 2" );
            menu.ExecuteCommand( "deleteItem 1" );
            menu.ExecuteCommand( "deleteItem 0" );
            menu.ExecuteCommand( "list" );
            stringWriter.WriteLine( "Title: _" );
            menu.ExecuteCommand( "deleteItem 0" );
            stringWriter.WriteLine( Constants.INDEX_OUT_OF_RANGE_ERROR );
            menu.ExecuteCommand( "insertParagraph end 1" );
            menu.ExecuteCommand( "insertParagraph end 2" );
            menu.ExecuteCommand( "insertParagraph end 3" );
            menu.ExecuteCommand( "insertParagraph end 4" );
            menu.ExecuteCommand( "insertParagraph end 1" );
            menu.ExecuteCommand( "insertParagraph end 2" );
            menu.ExecuteCommand( "insertParagraph end 3" );
            menu.ExecuteCommand( "insertParagraph end 4" );
            menu.ExecuteCommand( "insertParagraph end 1" );
            menu.ExecuteCommand( "insertParagraph end 2" );
            menu.ExecuteCommand( "insertParagraph end 3" );
            menu.ExecuteCommand( "insertParagraph end 4" );
            fileInf = new FileInfo( path );
            Assert.IsFalse( fileInf.Exists );
            Assert.AreEqual( stringWriter.ToString(), _stringWriter.ToString() );
        }

        [TestMethod]
        public void InsertImageTest()
        {
            _stringWriter = new StringWriter();
            StringWriter stringWriter = new StringWriter();
            _client = new Client( _stringWriter, Console.In );
            Menu menu = _client.GetMenu();
            menu.ExecuteCommand( "insertImage end 1000 1000 E:\\обои\\test.png" );
            string path = _client.GetDocument().GetItem( 0 ).Image.GetPath();
            FileInfo fileInf = new FileInfo( path );
            Assert.IsTrue( fileInf.Exists );
            menu.ExecuteCommand( "Undo" );
            menu.ExecuteCommand( "insertParagraph end 1" );
            menu.ExecuteCommand( "insertParagraph end 2" );
            menu.ExecuteCommand( "insertParagraph end 3" );
            menu.ExecuteCommand( "insertParagraph end 4" );
            menu.ExecuteCommand( "insertParagraph end 1" );
            menu.ExecuteCommand( "insertParagraph end 2" );
            menu.ExecuteCommand( "insertParagraph end 3" );
            menu.ExecuteCommand( "insertParagraph end 4" );
            menu.ExecuteCommand( "insertParagraph end 1" );
            menu.ExecuteCommand( "insertParagraph end 2" );
            menu.ExecuteCommand( "insertParagraph end 3" );
            menu.ExecuteCommand( "insertParagraph end 4" );
            fileInf = new FileInfo( path );
            Assert.IsFalse( fileInf.Exists );
        }

        [TestMethod]
        public void ResizeImageTest()
        {
            _stringWriter = new StringWriter();
            StringWriter stringWriter = new StringWriter();
            _client = new Client( _stringWriter, Console.In );
            Menu menu = _client.GetMenu();
            menu.ExecuteCommand( "insertImage end 1000 1000 E:\\обои\\test.png" );
            menu.ExecuteCommand( "resizeImage end 100 100" );
            Assert.AreEqual( 100, _client.GetDocument().GetItem( 0 ).Image.GetHeight() );
            Assert.AreEqual( 100, _client.GetDocument().GetItem( 0 ).Image.GetWidth() );
            menu.ExecuteCommand( "Undo" );
            Assert.AreEqual( 1000, _client.GetDocument().GetItem( 0 ).Image.GetHeight() );
            Assert.AreEqual( 1000, _client.GetDocument().GetItem( 0 ).Image.GetWidth() );
            menu.ExecuteCommand( "Redo" );

        }
    }
}