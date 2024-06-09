using System.Net.Http.Headers;

namespace ToDoList 
{
    class Display 
    {
        public Display() {}
        public static int getSelectedIndex(string prompt, string[] options, int selectedIndex = 0) {
            ConsoleKey keyPressed;
            do {
                Console.Clear();
                displayOptions(prompt, options, selectedIndex);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                    if (--selectedIndex == -1) selectedIndex = options.Length - 1;
                if (keyPressed == ConsoleKey.DownArrow)
                    if (++selectedIndex == options.Length) selectedIndex = 0;
            } while (keyPressed != ConsoleKey.Enter);
            return selectedIndex;
        }
        private static void displayOptions(string prompt, string[] options, int selectedIndex = 0) {
            int top = Console.WindowHeight / 2 - options.Length / 2 - 1;
            int left = Console.WindowWidth / 2 - prompt.Length / 2;
            Console.SetCursorPosition(left, top);
            Console.WriteLine(prompt);
            top++;
            for (int i = 0; i < options.Length; ++i) {
                string curentOption = options[i];
                if (i == selectedIndex) {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                left = Console.WindowWidth / 2 - curentOption.Length / 2;
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{curentOption}");
                top++;
            }
            Console.ResetColor();
        }
        public static void DisplayStatus(string[] prompt) 
        {
            Console.Clear();
            int top = Console.WindowHeight / 2 - prompt.Length / 2;
            int left = 0;
            foreach (string info in prompt) 
            {
                left  = Console.WindowWidth / 2 - info.Length / 2;
                Console.SetCursorPosition (left, top);
                Console.WriteLine(info);
                top++;
            }
        }
    }
}