using DependencyInjectionDemo.Extensions;
using DependencyInjectionDemo.IServices;
using DependencyInjectionDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IPostService, PostService>();

//this service is added to see the d/c b/n Singleton and Scoped by using the DemoService
builder.Services.AddSingleton<IDemoService, DemoService>();


//the 3 lines below are added to demo the the type of DI services, namely scoped, transient and singlethon

// builder.Services.AddScoped<IScopedService, ScopedService>();
// builder.Services.AddTransient<ITransientService, TransientService>();
// builder.Services.AddSingleton<ISingletonService, SingletonService>();


// the above 3 lines commented to use Extension instade 
// to use an extension one i created a file on the extension folder on the project dir and crated a file. then i used it here

builder.Services.AddLifeTimeServices();

// here the below code is used to demo the Keyed Services and the Action Injection

builder.Services.AddKeyedScoped<IDataService, SqlDataService>("SqlDatabaseService");
builder.Services.AddKeyedScoped<IDataService, MongoDataService>("MongoDatabaseService");

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

app.MapControllers();

app.Run();
