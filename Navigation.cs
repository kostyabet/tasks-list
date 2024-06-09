using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices;

namespace ToDoList 
{
    enum MainOptions 
    {
        TASKS, 
        REFERENCES,
        EXIT
    }
    class Navigation 
    {
        private static string[] _mainOptions = [" < Tasks > ", " < References > ", " < Exit > "];
        public static string[] GetMainOptions() => _mainOptions;
        public static MainOptions MainOptionsController(int Index) 
        {
            switch (Index) 
            {
                case (int)MainOptions.TASKS: return MainOptions.TASKS;
                case (int)MainOptions.REFERENCES: return MainOptions.REFERENCES;
                default: return MainOptions.EXIT;
            }
        }
    }
}