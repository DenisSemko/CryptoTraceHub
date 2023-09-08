var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAgentServices(builder.Configuration);

builder.Services.AddMassTransit(configuration => {
    configuration.AddConsumer<CheckCredentialsConsumer>();
    
    configuration.UsingRabbitMq((context, configurator) => {
        configurator.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        
        configurator.ReceiveEndpoint(Constants.CredentialsTransferQueue, c => {
            c.ConfigureConsumer<CheckCredentialsConsumer>(context);
        });
    });
});

builder.Services.AddScoped<CheckCredentialsConsumer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();