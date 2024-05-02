using System.Text.RegularExpressions;

restart:
        
Console.Write("Write text: ");
string text = Console.ReadLine();
Console.Clear();
        
int length = text.Length;
int cursor = 0;
        
while (length > Console.WindowWidth)
{
    string newLine = text.Substring(cursor, Console.WindowWidth - 4);
    int lineLength = newLine.LastIndexOf(' ');
    cursor += lineLength;
    text = text.Insert(cursor, "\n");
    length -= lineLength;
}

string[] lines = Regex.Split(text, "\r\n|\r|\n");
int left = 0;
int top = (Console.WindowHeight / 2) - (lines.Length / 2) - 1;
int center = Console.WindowWidth / 2;
for (int i = 0; i < lines.Length; i++)
{
    left = center - (lines[i].Length / 2);
    Console.SetCursorPosition(left, top);
    Console.WriteLine(lines[i]);
    top = Console.CursorTop;
}

Console.SetCursorPosition(0, Console.WindowHeight);
Console.WriteLine("Press any key for restart");
        
Console.ReadKey();
goto restart;