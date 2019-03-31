namespace Redactor
{
    public static class Constants
    {
        public const string INSERT_PARAGRAPH_COMMAND_NAME = "InsertParagraph";
        public const string INSERT_PARAGRAPH_COMMAND_DESCRIPTION = "Вставляет параграф в документ в указанную позицию";
        public const string SET_TITLE_COMMAND_NAME = "SetTitle";
        public const string SET_TITLE_COMMAND_DESCRIPTION = "Изменяет заголовок документа";
        public const string INSERT_IMAGE_COMMAND_NAME = "InsertImage";
        public const string INSERT_IMAGE_COMMAND_DESCRIPTION = "Вставляет изображение в указанную позицию";
        public const string LIST_COMMAND_NAME = "List";
        public const string LIST_COMMAND_DESCRIPTION = "Выдаёт название и список элементов документа";
        public const string REPLACE_TEXT_COMMAND_NAME = "ReplaceText";
        public const string REPLACE_TEXT_COMMAND_DESCRIPTION = "Заменяет текст в параграфе, находящемся в указанной позиции документа";
        public const string RESIZE_IMAGE_COMMAND_NAME = "ResizeImage";
        public const string RESIZE_IMAGE_COMMAND_DESCRIPTION = "Изменяет размер изображения, находящегося в указанной позиции документа";
        public const string DELETE_ITEM_COMMAND_NAME = "DeleteItem";
        public const string DELETE_ITEM_COMMAND_DESCRIPTION = "Удаляет элемент документа, находящийся в указанной позиции";
        public const string HELP_COMMAND_NAME = "Help";
        public const string HELP_COMMAND_DESCRIPTION = "Выводит справку о доступных командах редактирования и их аргументах";
        public const string UNDO_COMMAND_NAME = "Undo";
        public const string UNDO_COMMAND_DESCRIPTION = "Отменяет действие ранее введенной команды редактирования, возвращая документ в предыдущее состояния";
        public const string REDO_COMMAND_NAME = "Redo";
        public const string REDO_COMMAND_DESCRIPTION = "Выполняет ранее отмененную команду редактирования, возвращая документ в состояние, отменяе действие команды Undo";
        public const string SAVE_COMMAND_NAME = "Save";
        public const string SAVE_COMMAND_DESCRIPTION = "Сохраняет текущее состояние документа в файл формата html с изображениями";
        public const string EXIT_COMMAND_NAME = "Exit";
        public const string EXIT_COMMAND_DESCRIPTION = "Выход из программы";

        public const string UNRKNOW_COMMAND = "Команда не распознана";
        public const string INVALID_AMOUNT_PARAMETRS_FOR_INSERT_PARAGRAPH = "Некорректное количество параметров для вставки нового параграфа";
        public const string INVALID_AMOUNT_PARAMETRS_FOR_SET_TITLE = "Некорректное количество  параметров для изменения текста параграфа";
        public const string INVALID_AMOUNT_PARAMETRS_FOR_REPLACE_TEXT = "Некорректное количество  параметров для указания текста";
        public const string INVALID_AMOUNT_PARAMETRS_FOR_RESIZE_IMAGE = "Некорректное количество параметров для изменения размера изображения";
        public const string INVALID_AMOUNT_PARAMETRS_FOR_DELETE_ITEM = "Некорректное количество параметров для удаления элемента";
        public const string INVALID_AMOUNT_PARAMETRS_FOR_SAVE = "Некорректное количество параметров для сохранения документа";
        public const string INVALID_AMOUNT_PARAMETRS_FOR_INSERT_IMAGE = "Некорректное количество параметров для вставки нового изображения";
        public const string INDEX_OUT_OF_RANGE_ERROR = "Индекс больше чем количество элементов в документе";
        public const string IMPOSSIBLE_TO_UNDO = "Невозможно выполнить команду Undo";
        public const string IMPOSSIBLE_TO_REDO = "Невозможно выполнить команду Redo";
        public const string IT_IS_NOT_PARAGRAPH = "Выбранный элемент не является параграфом";
        public const string IT_IS_NOT_IMAGE = "Выбранный элемент не является изображением";
        public const string FILE_IS_NOT_EXIST = "Файл не найден";
    }
}