using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Project.ApplicationLayer.AutoMapperExtension;
using Project.ApplicationLayer.Contracts;
using Project.ApplicationLayer.EmailExtension;
using Project.ApplicationLayer.Services;
using Project.Data.EF;
using Project.Data.Entities;
using Project.RepositoryLayer.Contracts;
using Project.RepositoryLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<AppRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddTransient<IEmailSender>(s => new EmailSender("localhost", 25, "no-reply@leavemanagement.com"));
//builder.Services.AddTransient(typeof(IGenericRepository<LeaveType, Guid>), typeof(GenericRepository<LeaveType, Guid>));
//builder.Services.AddTransient(typeof(IGenericRepository<LeaveRequest, Guid>), typeof(GenericRepository<LeaveRequest, Guid>));
//builder.Services.AddTransient(typeof(IGenericRepository<LeaveAllocation, Guid>), typeof(GenericRepository<LeaveAllocation, Guid>));
builder.Services.AddTransient<ILeaveTypeRepository, LeaveTypeRepository>();
builder.Services.AddTransient<ILeaveAllocationRepository, LeaveAllocationRepository>();
builder.Services.AddTransient<ILeaveRequestRepository, LeaveRequestRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
app.MapRazorPages();

app.Run();
