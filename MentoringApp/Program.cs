using MentoringApp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaskToDoDB>();
var app = builder.Build();
var cruds = new CRUDOperations();

cruds.MapEndpoints(app);
app.Run();
