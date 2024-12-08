using Microsoft.EntityFrameworkCore;
using qlydiem.Data;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ DbContext và chỉ định chuỗi kết nối
builder.Services.AddDbContext<qlydiemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("qlydiemContext")));

// Thêm các dịch vụ khác
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
