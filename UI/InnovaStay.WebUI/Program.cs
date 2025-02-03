var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// HttpClient
builder.Services.AddHttpClient();


//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//        policy =>
//        {
//            policy
//            .AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//        });
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseCors();

app.UseAuthorization();

// Add Admin Area route
app.MapControllerRoute(
    name:"admin",
    pattern: "Admin/{controller=Staffs}/{action=Index}/{id?}",
    defaults: new {area = "Admin"}
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
