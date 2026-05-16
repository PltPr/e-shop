using BuildingBlocks.Behaviors;
using Carter;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


var assembley = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
	config.RegisterServicesFromAssemblies(assembley);
	config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});


builder.Services.AddValidatorsFromAssembly(assembley);
builder.Services.AddCarter();
builder.Services.AddMarten(opts =>
{
	opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(exceptionHandlerApp =>
{
	exceptionHandlerApp.Run(async context =>
	{
		var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
		if (exception == null)
		{
			return;
		}

		var problemDetails = new ProblemDetails
		{
			Title = exception.Message,
			Status = StatusCodes.Status500InternalServerError,
			Detail = exception.StackTrace
		};

		var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
		logger.LogError(exception, exception.Message);

		context.Response.StatusCode = StatusCodes.Status500InternalServerError;
		context.Response.ContentType = "application/json";

		await context.Response.WriteAsJsonAsync(problemDetails);

	});
});

app.Run();
