using System.Collections;

namespace to_do_list_cs 
{
    class Tasks
    {
        private static ArrayList words = new ArrayList();
        private const string FilePath = "data.txt";

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
        private static string InputString(string prompt, int length)
        {
            string res;
            bool isIncorrect;
            do
            {
                isIncorrect = false;
                try
                {
                    res = Convert.ToString(Console.ReadLine()) ?? String.Empty;
                    if (res.Length > length)
                    {
                        isIncorrect = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                if (isIncorrect)
                {
                       
                }
            } while (isIncorrect);
            return res;
        }
        private static void Add(Task task)
        {
            
        }
        private static void AddTask()
        {
            string? headline = InputString("Input task headline: ", 30);
            string info = "";
            int hours = 0;
            int minuts = 0;
            Clock time = new Clock(0, 0, 0, 0, 0);
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
                int index = Display.getSelectedIndex(prompt, Navigation.GetTasksOptions());
                control = Navigation.TasksOptionsController(index);
                WorkWithControl(control);
            } while (control != TaskOptions.EXIT);
        }
    }
}