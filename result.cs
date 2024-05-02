using System.Text.RegularExpressions;

string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
// Длина текста, не считая уже отделённых строк
int length = text.Length;
// Позиция, на которой нужно вставить разрыв строки
int cursor = 0;

// Продолжаем разбивать текст до тех пор, пока он длиннее, чем может поместиться на одной строке
while (length > Console.WindowWidth)
{
    // Получаем новую строку, которая будет влезать в ширину консоли
    string newLine = text.Substring(cursor, Console.WindowWidth - 4);

    // Находим положение последнего курсора в этой строке
    int lineLength = newLine.LastIndexOf(' ');

    // Прибавляем к курсору длину новой строки
    cursor += lineLength;
    // Вставляем разрыв
    text = text.Insert(cursor, "\n");
    // Отнимаем от длины текста длину новой строки
    length -= lineLength;
}

// Разбиваем текст на массив строк
string[] lines = Regex.Split(text, "\r\n|\r|\n");

// Отступ слева будет определяться для каждой строки отдельно
int left = 0;
// Определяем отступ сверху для первой строки
int top = (Console.WindowHeight / 2) - (lines.Length / 2) - 1;

// Находим центр консоли сразу, чтобы не грузить приложение лишними вычислениями
// Делайте это стоит на свой страх и риск - если пользователь растянет консоль, весь текст поедет
int center = Console.WindowWidth / 2;

for (int i = 0; i < lines.Length; i++)
{
    // Определяем отступ для текущей строки
    left = center - (lines[i].Length / 2);

    // Меняем положение курсора
    Console.SetCursorPosition(left, top);
    // Выводим строку
    Console.WriteLine(lines[i]);

    // Для каждой новой строки программа будет автоматически считать отступ сверху
    top = Console.CursorTop;
}

Console.ReadKey();