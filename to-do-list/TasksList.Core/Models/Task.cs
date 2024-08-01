namespace TasksList.Core.Models
{
    public class Task
    {
        public const int MAX_LENGTH = 30;

        private Task(Guid id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }

        public static (Task Task, string Error) Create(Guid id, string title, string description)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_LENGTH)
            {
                error = $"You should write task title and size should be no more than {MAX_LENGTH}!";
            }

            var task = new Task(id, title, description);

            return (task, error);
        }
    }
}