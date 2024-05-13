using Microsoft.EntityFrameworkCore;

namespace MentoringApp
{
    public class TaskToDoDB : DbContext
    {
        public DbSet<TaskToDoModel> TaskToDo  => Set<TaskToDoModel>();

        public TaskToDoDB(DbContextOptions<TaskToDoDB> options)
            : base(options) { }
    }
}
