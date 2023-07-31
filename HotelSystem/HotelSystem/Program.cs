using HotelSystem.Data;
using HotelSystem.Interfaces;
using HotelSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// build connection to DB
builder.Services
    .AddDbContext<AsyncInnDbContext>
    (opions => opions.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
     );

builder.Services.AddScoped<IHotel, HotelService>();
builder.Services.AddScoped<IRoom, RoomService>();
builder.Services.AddScoped<IAmenity, AmenityService>();
builder.Services.AddScoped<IHotelRoom, HotelRoomService>();

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
