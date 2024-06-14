using System.Collections;

namespace ToDoList 
{
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
        private static void WorkWithControl(TaskOptions control)
        {
            switch (control)
            {
                //case TaskOptions.GETTASK: GetTask();  break;
                //case TaskOptions.ADDTASK: AddTask(); break;
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