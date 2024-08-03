using OnlineAdmissionSystem2.Data;
using OnlineAdmissionSystem2.Mappings;
using OnlineAdmissionSystem2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(config =>
{
    //config.AddProfile<UserProfile>();
    //map data entity to view model when required
    config.CreateMap<UserDataModel, NewUserViewModel>();
});

builder.Services.AddDbContext<AdmissionDbContext>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
