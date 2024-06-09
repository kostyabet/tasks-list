namespace ToDoList 
{
    class MainToDo () 
    {
        static void PrepearProgram () 
        {
            Display.DisplayStatus(["To Do List!", "Loading..."]);
            Tasks.LoadTasksFromFile();
            Thread.Sleep(1000);
            Display.DisplayStatus(["To Do List!", "Success"]);
        }
        public static void MainProgram() 
        {
            var control = MainOptions.EXIT;
            string prompt = "Choose varient";
            do 
            {
                int Index = Display.getSelectedIndex(prompt, Navigation.GetMainOptions());
                control = Navigation.MainOptionsController(Index);
            } while (control != MainOptions.EXIT);
        }
        private static void ExitProcess() 
        {
            Console.Clear();
            //SaveTasksInFile();
        }
        public static void Main(String[] args) 
        {
            PrepearProgram();
            MainProgram();
            ExitProcess();
        }
    }
}