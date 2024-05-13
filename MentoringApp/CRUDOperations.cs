using Microsoft.EntityFrameworkCore;

namespace MentoringApp
{
    public class CRUDOperations
    {
        public void MapEndpoints(WebApplication app)
        {
            app.MapGet("/", (TaskToDoDB db) =>
                db.TaskToDo.ToList());

            app.MapGet("/{id}", (int id, TaskToDoDB db) =>
                Results.Ok(db.TaskToDo.FirstOrDefault(x => x.Id == id)) ?? Results.NotFound());

            app.MapPost("/", (TaskToDoModel taskToDo, TaskToDoDB db) =>
            {
                db.Add(taskToDo);
                db.SaveChanges();
                return Results.Created();
            });

            app.MapPut("/{id}", (int id, TaskToDoModel taskToUpdate, TaskToDoDB db) =>
            {
                var taskToDo = db.TaskToDo.FirstOrDefault(x => x.Id == id);
                if (taskToDo == null) return Results.NotFound();
                
                taskToDo.Name = taskToUpdate.Name;
                taskToDo.Description = taskToUpdate.Description;
                taskToDo.YouTrackId = taskToUpdate.YouTrackId;
                
                db.SaveChanges();

                return Results.NoContent();
            });

            app.MapDelete("/{id}", (int id, TaskToDoDB db) =>
            {
                var todo = db.TaskToDo.Find(id);
                if (todo != null)
                {
                    db.TaskToDo.Remove(todo);
                    db.SaveChanges();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });
        }
    }
}
