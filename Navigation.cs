namespace to_do_list_cs 
{
    enum MainOptions 
    {
        GetTask,
        Tasks, 
        References,
        Exit
    }

    enum TaskOptions 
    {
        GetTask,
        AddTask,
        AllTasks,
        Exit
    }
    class Navigation 
    {
        private static string[] _mainOptions = [" < Next Task > ", " < Work With Tasks > ", " < References > ", " < Exit > "];
        private static string[] _tasksOptions = [" < Next Task > ", " < Add New Task > ", " < Show All Tasks > ", " < Exit > "]; // length: [0]:15, [1]:18, [2]:20
        public static string[] GetMainOptions() => _mainOptions;
        public static string[] GetTasksOptions() => _tasksOptions;
        public static MainOptions MainOptionsController(int Index) 
        {
            switch (Index) 
            {
                case (int)MainOptions.GetTask: return MainOptions.GetTask;
                case (int)MainOptions.Tasks: return MainOptions.Tasks;
                case (int)MainOptions.References: return MainOptions.References;
                default: return MainOptions.Exit;
            }
        }
        public static TaskOptions TasksOptionsController(int Index)
        {
            switch (Index)
            {
                case (int)TaskOptions.GetTask: return TaskOptions.GetTask;
                case (int)TaskOptions.AddTask: return TaskOptions.AddTask;
                case (int)TaskOptions.AllTasks: return TaskOptions.AllTasks;
                default: return TaskOptions.Exit;
            }
        }
    }
}