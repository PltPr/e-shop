
var builder = WebApplication.CreateBuilder(args);

var assembley = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
	config.RegisterServicesFromAssembly(assembley);
	config.AddOpenBehavior(typeof(ValidationBehavior<,>));
	config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddCarter();

var app = builder.Build();

app.MapCarter();

app.Run();
