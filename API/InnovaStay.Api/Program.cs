using InnovaStay.Api.Extension;
using InnovaStay.Api.Filters;
using InnovaStay.Business.Abstract;
using InnovaStay.Business.Concrete;
using InnovaStay.Data;
using InnovaStay.Data.Abstract;
using InnovaStay.Data.Concrete;
using InnovaStay.Data.Repositories;
using InnovaStay.Dto.Dtos;
using InnovaStay.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

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

// Add Cors Policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7165", "http://localhost:5058")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});




builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
{
    //options.Filters.Add(new CustomValidationFilter());


    options.InvalidModelStateResponseFactory = context =>
    {
        // Hatalarý al
        var errors = context.ModelState
            .Where(ms => ms.Value.Errors.Count > 0)
            .SelectMany(ms => ms.Value.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        // Özelleþtirilmiþ ResponseDto oluþtur
        var response = ResponseDto<NoDataDto>.Fail(errors, 400);

        // BadRequest (200) ile birlikte ResponseDto döndür
        return new BadRequestObjectResult(response);
    };

});
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

app.UseCors();
// Use Global Exception
app.ExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
