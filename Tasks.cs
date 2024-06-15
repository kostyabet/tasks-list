using System.Collections;

namespace to_do_list_cs 
{
    internal struct Clock(int hours, int minuts)
    {
        public int Hours = hours;
        public int Minuts = minuts;
    }

    internal struct Task(string headLine, string info, Clock time)
    {
        public string HeadLine = headLine;
        public string Info = info;
        public Clock Time = time;
    }
    class Tasks 
    {
        private static ArrayList words = new ArrayList();
        private static string filePath = "data.txt";
        public static void LoadTasksFromFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] lineWords = line.Split(new char[] { ' ', '\0' }, StringSplitOptions.RemoveEmptyEntries);
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
        private static void AddTask()
        {
            string headline = "";
            string info = "";
            int hours = 0;
            int minuts = 0;
            Clock time = new Clock(hours, minuts);
            Task task = new Task(headline, info, time);
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
                int Index = Display.getSelectedIndex(prompt, Navigation.GetTasksOptions());
                control = Navigation.TasksOptionsController(Index);
                WorkWithControl(control);
            } while (control != TaskOptions.EXIT);
        }
    }
}