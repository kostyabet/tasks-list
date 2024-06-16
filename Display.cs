namespace to_do_list_cs;

internal abstract class Display
{
    private static readonly int[] DayInMonths = [31, 0, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    private static readonly string[] ExitOption = [" < Exit > "];
    public static int GetSelectedIndex(string prompt, string[] options, int selectedIndex = 0) {
        ConsoleKey keyPressed;
        do {
            Console.Clear();
            DisplayOptions(prompt, options, selectedIndex);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;
            switch (keyPressed)
            {
                case ConsoleKey.UpArrow:
                {
                    if (--selectedIndex == -1)
                    {
                        selectedIndex = options.Length - 1;
                    }
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    if (++selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                    break;
                }
            }
        } while (keyPressed != ConsoleKey.Enter);
        return selectedIndex;
    }
    private static void MoveCursorInDefPos() 
    {
        int top = Console.WindowHeight - 1;
        int left = Console.WindowWidth - 1;
        Console.SetCursorPosition(left, top);
    }
    private static void DisplayOptions(string prompt, string[] options, int selectedIndex = 0) {
        string[] lines = prompt.Split(new[] { '\n' }, StringSplitOptions.None);
        if (lines.Length > Console.WindowHeight - 4)
        {
            int left = 0;
            int top = 0;
            Console.SetCursorPosition(left, top);
            foreach (string line in lines)
            {
                left = Console.WindowWidth / 2 - line.Length / 2;
                if (left > 0)
                {
                    Console.SetCursorPosition(left, Console.CursorTop);
                }
                Console.WriteLine(line);
            }
            Console.WriteLine();
            for (int i = 0; i < options.Length; ++i) {
                string currentOption = options[i];
                if (i == selectedIndex) {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                left = Console.WindowWidth / 2 - currentOption.Length / 2;
                Console.SetCursorPosition(left, Console.CursorTop);
                Console.WriteLine($"{currentOption}");
            }
            Console.ResetColor();
            MoveCursorInDefPos();
        }
        else
        {
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
                string currentOption = options[i];
                if (i == selectedIndex) {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                left = Console.WindowWidth / 2 - currentOption.Length / 2;
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{currentOption}");
                top++;
            }
            Console.ResetColor();
            MoveCursorInDefPos();
        }
    }
    public static void DisplayStatus(string[] prompt)
    {   
        Console.Clear();
        int top = Console.WindowHeight / 2 - prompt.Length / 2;
        foreach (string info in prompt) 
        {
            int left = Console.WindowWidth / 2 - info.Length / 2;
            Console.SetCursorPosition (left, top);
            Console.WriteLine(info);
            top++;
        }
        MoveCursorInDefPos();
    }
    public static string InputString(string prompt, int min, int max)
    {
        string res = string.Empty;
        bool isIncorrect;
        Console.Write(prompt);
        do
        {
            try
            {
                res = Convert.ToString(Console.ReadLine()) ?? String.Empty;
                isIncorrect = false;
            }
            catch (Exception e)
            {
                isIncorrect = true;
                Console.WriteLine(e + "Try again: ");
            }
            if (res.Length > max || res.Length < min)
            {
                Console.Write("Error. Try again: ");
                isIncorrect = true;
            }
        } while (isIncorrect);
        return res;
    }

    public static Clock InputDate(string prompt)
    {
        Clock res = new Clock(0, 0, 0);
        int year = 0, month = 0, day = 0;
        bool isIncorrect;
        Console.Write(prompt);
        do
        {
            string date = String.Empty;
            try
            {
                date = Console.ReadLine() ?? String.Empty;
                isIncorrect = false;
            }
            catch (Exception e)
            {
                isIncorrect = true;
                Console.WriteLine(e);
            }
            if (!isIncorrect && (date.Length < 1 || date.Length > 10))
            {
                Console.Write("Error date format (day.month.year). Try again: ");
                isIncorrect = true;
            }
            else if (!isIncorrect)
            {
                string[] args = date.Split(new[] { '.' }, StringSplitOptions.None);
                if (args.Length != 3)
                {
                    Console.Write("Error date format (day.month.year). Try again: ");
                    isIncorrect = true;
                }
                    
                if (!isIncorrect && !IsGoodNumber(args[2], min: 0, max: int.MaxValue))
                {
                    Console.Write("Error year. Try again: ");
                    isIncorrect = true;
                }
                else if (!isIncorrect) {
                    year = Convert.ToInt32(args[2]);
                    DayInMonths[1] = 28 + IsWeightBearingYear(year);
                }
                    
                if (!isIncorrect && !IsGoodNumber(args[1], 1, 12))
                {
                    Console.Write("Error month. Try again: ");
                    isIncorrect = true;
                }
                else if (!isIncorrect)
                {
                    month = Convert.ToInt32(args[1]);
                }

                if (!isIncorrect && !IsGoodNumber(args[0], 0, DayInMonths[month - 1]))
                {
                    Console.Write("Error day. Try again: ");
                    isIncorrect = true;
                }
                else if (isIncorrect)
                {
                    day = Convert.ToInt32(args[0]);
                }
            }
        } while (isIncorrect);
        res.Year = year;
        res.Month = month;
        res.Day = day;
        return res;
    }

    private static int IsWeightBearingYear(int year)
    {
        if (year % 4 == 0 && year % 100 != 0)
        {
            return 1;
        }
        if (year % 400 == 0)
        {
            return 1;
        }
        return 0;
    }
    private static bool IsGoodNumber(string num, int min, int max)
    {
        bool isCorrect = true;
        int cur = 0;
        try
        {
            cur = Convert.ToInt32(num);
        }
        catch (Exception e)
        {
            isCorrect = false;
            Console.WriteLine(e);
        }
        if (cur > max || cur < min)
        {
            isCorrect = false;
        }
        return isCorrect;
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
                         You can share your opinion on our github: https://github.com/kostyabet/to_do_list-cs.
                         """;
        GetSelectedIndex(prompt, ExitOption);
    }
}