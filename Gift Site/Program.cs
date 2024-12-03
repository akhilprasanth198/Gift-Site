using Gift_Site;
using Gift_Site.GiftStoreDbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();  // For session storage
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;  // Security enhancement
    options.Cookie.IsEssential = true;  // Marks as essential for GDPR compliance
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();  // Session middleware should be before Authorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Login}/{id?}");

app.Run();
