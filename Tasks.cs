using System.Collections;

namespace to_do_list_cs 
{
    class Tasks
    {
        private static ArrayList words = new ArrayList();
        private const string FilePath = "data.txt";
        public const int MaxCaption = 30;
        public const int MinCaption = 1;
        public const int MaxInfo = 100;
        public const int MinInfo = 0;
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
                            words.Add(word);
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

        private static void Add(Task task)
        {
            
        }
        private static void AddTask()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            string headline = Display.InputString("Input task headline: ", MinCaption, MaxCaption).Trim();
            string info = Display.InputString("Input info about task: ", MinInfo, MaxInfo).Trim();
            Clock time = Display.InputDate("Input date of completion (day.month.year): ");
            Add(new Task(headline, info, time));
        }
        private static void WorkWithControl(TaskOptions control)
        {
            switch (control)
            {
                //case TaskOptions.GETTASK: GetTask();  break;
                case TaskOptions.ADDTASK: AddTask(); break;
                //case TaskOptions.ALLTASKS: ViewAllTasks(); break;
            }
        }
        public static void WorkWithTasks() 
        {
            var control = TaskOptions.EXIT;
            string prompt = "Work with tasks\nChoose the varient:";
            do
            {
                int index = Display.GetSelectedIndex(prompt, Navigation.GetTasksOptions());
                control = Navigation.TasksOptionsController(index);
                WorkWithControl(control);
            } while (control != TaskOptions.EXIT);
        }
    }
}