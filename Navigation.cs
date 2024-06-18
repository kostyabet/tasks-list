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
        Complete,
        Next,
        Exit
    }
    enum TasksOptions 
    {
        GetTask,
        AddTask,
        AllTasks,
        Exit
    }

    internal abstract class Navigation
    {
        private static readonly string[] ExitOptions = [" < Exit > "];
        private static readonly string[] TaskOptions = [" < Complete > ", " < Next > ", " < Exit > "];
        private static readonly string[] MainOptions = [" < Next Task > ", " < Work With Tasks > ", " < References > ", " < Exit > "];
        private static readonly string[] TasksOptions = [" < Next Task > ", " < Add New Task > ", " < Show All Tasks > ", " < Exit > "]; // length: [0]:15, [1]:18, [2]:20
        public static string[] GetExitOptions() => ExitOptions;
        public static string[] GetTaskOptions() => TaskOptions;
        public static string[] GetMainOptions() => MainOptions;
        public static string[] GetTasksOptions() => TasksOptions;
        public static MainOptions MainOptionsController(int index)
        {
            return index switch
            {
                (int)to_do_list_cs.MainOptions.GetTask => to_do_list_cs.MainOptions.GetTask,
                (int)to_do_list_cs.MainOptions.Tasks => to_do_list_cs.MainOptions.Tasks,
                (int)to_do_list_cs.MainOptions.References => to_do_list_cs.MainOptions.References,
                _ => to_do_list_cs.MainOptions.Exit
            };
        }
        public static TasksOptions TasksOptionsController(int index)
        {
            return index switch
            {
                (int)to_do_list_cs.TasksOptions.GetTask => to_do_list_cs.TasksOptions.GetTask,
                (int)to_do_list_cs.TasksOptions.AddTask => to_do_list_cs.TasksOptions.AddTask,
                (int)to_do_list_cs.TasksOptions.AllTasks => to_do_list_cs.TasksOptions.AllTasks,
                _ => to_do_list_cs.TasksOptions.Exit
            };
        }

        public static TaskOptions TaskOptionsController(int index)
        {
            return index switch
            {
                (int)to_do_list_cs.TaskOptions.Complete => to_do_list_cs.TaskOptions.Complete,
                (int)to_do_list_cs.TaskOptions.Next => to_do_list_cs.TaskOptions.Next,
                _ => to_do_list_cs.TaskOptions.Exit
            };
        }
    }
}