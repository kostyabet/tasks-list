using System.Collections;

namespace ToDoList 
{
    class MainToDo () 
    {
        static ArrayList words = new ArrayList();
        static string filePath = "data1.txt";
        static void LoadWordsFromFile() 
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
        static void ShowLoadingScreen(string[] prompt) 
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
        static void PrepearProgram () 
        {
            ShowLoadingScreen(["To Do List!", "Loading..."]);
            LoadWordsFromFile();
            Thread.Sleep(3000);
            ShowLoadingScreen(["To Do List!", "Success"]);
        }
        public static void Main(String[] args) 
        {
            PrepearProgram();
        }
    }
}