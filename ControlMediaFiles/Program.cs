using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ControlMediaFiles.Data;
using ControlMediaFiles.Services;
using ControlMediaFiles.Controllers;
using ControlMediaFiles.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration["AzureStorage:BlobConnectionString"]));
builder.Services.AddSingleton(x => new QueueServiceClient(builder.Configuration["AzureStorage:QueueConnectionString"]));

builder.Services.AddHostedService<QueueProcessorService>();
builder.Services.AddHostedService<FileProcessingService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
