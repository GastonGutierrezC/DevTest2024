

using BackEnd.DBContex.Interfaces;
using BackEnd.DBContex.PollDB;
using BackEnd.DBContex.VoteDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IPollRepository, ListMemory>();
builder.Services.AddSingleton<IVoteRepository, ListVoteMemory>();


builder.Services.AddCors(option =>

    {
        option.AddPolicy("AllowSpecificOrigin",
            
            policy =>
            {
                policy.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });
    


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();




app.Run();

