namespace to_do_list_cs 
{
    class Display 
    {
        private static string[] _exitOption = [" < Exit > "];
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
        private static void MoveCursorInDefPos() 
        {
            int top = Console.WindowHeight - 1;
            int left = Console.WindowWidth - 1;
            Console.SetCursorPosition(left, top);
        }
        private static void displayOptions(string prompt, string[] options, int selectedIndex = 0) {
            string[] lines = prompt.Split(new[] { '\n' }, StringSplitOptions.None);
            int top = Console.WindowHeight / 2 - options.Length / 2 - (lines.Length + 2) / 2;
            int left;
            foreach (string line in lines)
            {
                left = Console.WindowWidth / 2 - line.Length / 2;
                Console.SetCursorPosition(left, top);
                Console.WriteLine(line);
                top++;
            }
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
            MoveCursorInDefPos();
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
            MoveCursorInDefPos();
        }
        public static void Reference() 
        {
            Console.Clear();
            string prompt = $"""
                To Do List

                In this app you can write all your task in one list and complete this all sequentially.
                Firstly you should add your task in folder {Navigation.GetMainOptions()[1]}.

                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue
                /// /// continue

                This app was created opensource and all your feedback is good result for as.
                You can share your oppinion on our github: https://github.com/kostyabet/to_do_list-cs.
                """;
            getSelectedIndex(prompt, _exitOption);
        }
    }
}