using System.Collections;
using System.Data;

namespace to_do_list_cs 
{
    class Tasks
    {
        private static List<Task>? _words; 
        private const string FilePath = "data.txt";
        private const int MaxCaption = 30;
        private const int MinCaption = 1;
        private const int MaxInfo = 100;
        private const int MinInfo = 0;
        public static void LoadTasksFromFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string? line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] lineWords =
                            line.Split(new char[] { ' ', '\0' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string word in lineWords)
                        {
                            //_words.Add(word);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private static int TaskEqual(Task task1, Task task2)
        {
            Clock clock1 = task1.GetTime;
            Clock clock2 = task2.GetTime;
            if (clock1.Year > clock2.Year || clock1.Month > clock2.Month || clock1.Day > clock2.Day) return 1;
            if (clock1.Year < clock2.Year || clock1.Month < clock2.Month || clock1.Day < clock2.Day) return -1;
            if (clock1.Year == clock2.Year || clock1.Month == clock2.Month || clock1.Day == clock2.Day) return 0;
            throw new("Error clocks equality");
        }
        private static void Sort()
        {
            Task[]? tasks = _words?.ToArray();
            /*Task[]? arr = [
                new Task("1", "1", new Clock(2024, 02, 29)), 
                new Task("2", "2", new Clock(2024, 02, 21)), 
                new Task("3", "3", new Clock(2023, 02, 28)), 
                new Task("4", "4", new Clock(2023, 01, 01))
            ];*/
            if (tasks == null) return;
            for (var i = 0; i < tasks.Length; i++)
            {
                var j = i + 1;
                while (j < tasks.Length && TaskEqual(tasks[i], tasks[j]) > 0) // arr[temp] > arr[j]
                {
                    (tasks[i], tasks[j]) = (tasks[j], tasks[i]);
                    j++;
                }
            }
            _words?.Clear();
            foreach (var task in tasks)
            {
                _words?.Add(task);
            }
        }
        private static void Add(Task task)
        {
            _words?.Add(task);
            Sort();
        }
        private static void AddTask()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            var headline = Display.InputString("Input task headline: ", MinCaption, MaxCaption).Trim();
            var info = Display.InputString("Input info about task: ", MinInfo, MaxInfo).Trim();
            var time = Display.InputDate("Input date of completion (day.month.year): ");
            Add(new Task(headline, info, time));
        }
        private static void WorkWithControl(TaskOptions control)
        {
            switch (control)
            {
                //case TaskOptions.GETTASK: GetTask();  break;
                case TaskOptions.AddTask: AddTask(); break;
                //case TaskOptions.ALLTASKS: ViewAllTasks(); break;
            }
        }
        public static void WorkWithTasks() 
        {
            var control = TaskOptions.Exit;
            string prompt = "Work with tasks\nChoose the varient:";
            do
            {
                int index = Display.GetSelectedIndex(prompt, Navigation.GetTasksOptions());
                control = Navigation.TasksOptionsController(index);
                WorkWithControl(control);
            } while (control != TaskOptions.Exit);
        }
    }
}