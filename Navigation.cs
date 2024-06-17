namespace to_do_list_cs 
{
    enum MainOptions 
    {
        GETTASK,
        TASKS, 
        REFERENCES,
        EXIT
    }
    enum TaskOptions 
    {
        GETTASK,
        ADDTASK,
        ALLTASKS,
        EXIT
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
                case (int)MainOptions.GETTASK: return MainOptions.GETTASK;
                case (int)MainOptions.TASKS: return MainOptions.TASKS;
                case (int)MainOptions.REFERENCES: return MainOptions.REFERENCES;
                default: return MainOptions.EXIT;
            }
        }
        public static TaskOptions TasksOptionsController(int Index)
        {
            switch (Index)
            {
                case (int)TaskOptions.GETTASK: return TaskOptions.GETTASK;
                case (int)TaskOptions.ADDTASK: return TaskOptions.ADDTASK;
                case (int)TaskOptions.ALLTASKS: return TaskOptions.ALLTASKS;
                default: return TaskOptions.EXIT;
            }
        }
    }
}