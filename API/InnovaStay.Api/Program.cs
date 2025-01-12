using InnovaStay.Api.Extension;
using InnovaStay.Business.Abstract;
using InnovaStay.Business.Concrete;
using InnovaStay.Data;
using InnovaStay.Data.Abstract;
using InnovaStay.Data.Concrete;
using InnovaStay.Data.Repositories;
using InnovaStay.Entity.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register Layer
builder.Services.AddDataService(builder.Configuration);



builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<ISubscribeService, SubscribeService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();






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

// Use Global Exception
app.ExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
