using Microsoft.EntityFrameworkCore;
using RoomWithAView.Business.Reservations;
using RoomWithAView.Business.Rooms;
using RoomWithAView.Data;
using Rooms.Data;

var builder = WebApplication.CreateBuilder(args);

var constr = builder.Configuration["ConnectionStrings:Default"];
builder.Services.AddDbContext<DatabaseContext>(opt => {
    opt.UseSqlServer(constr);
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRoomBusiness, RoomBusiness>();
builder.Services.AddScoped<IReservationBusiness, ReservationBusiness>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

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
