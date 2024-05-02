using System.Text.RegularExpressions;

string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
// The length of the text, not counting the already separated lines
int length = text.Length;
// The position where you want to insert a line break
int cursor = 0;

// Continue to split the text until it is longer than it can fit on one line
while (length > Console.WindowWidth)
{
    // Get a new line that will fit into the width of the console
    string newLine = text.Substring(cursor, Console.WindowWidth - 4);

    // Find the position of the last cursor in this line
    int lineLength = newLine.LastIndexOf(' ');

    // Adding the length of the new line to the cursor
    cursor += lineLength;
    // Inserting a gap
    text = text.Insert(cursor, "\n");
    // Subtract the length of the new line from the length of the text
    length -= lineLength;
}

// Splitting the text into an array of lines
string[] lines = Regex.Split(text, "\r\n|\r|\n");

// The indentation on the left will be determined for each line separately
int left = 0;
// Defining the top indentation for the first line
int top = (Console.WindowHeight / 2) - (lines.Length / 2) - 1;

// Find the center of the console immediately, so as not to load the application with unnecessary calculations
// Do it at your own risk - if the user stretches the console, all the text will go
int center = Console.WindowWidth / 2;

for (int i = 0; i < lines.Length; i++)
{
    // Defining the indentation for the current line
    left = center - (lines[i].Length / 2);

    // Changing the cursor position
    Console.SetCursorPosition(left, top);
    // Output the line
    Console.WriteLine(lines[i]);

    // For each new line, the program will automatically count the indentation from the top
    top = Console.CursorTop;
}

Console.ReadKey();