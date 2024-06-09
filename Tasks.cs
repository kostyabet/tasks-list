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
        public static void WorkWithTasks() 
        {
            // create main work with tasks
        }
    }
}