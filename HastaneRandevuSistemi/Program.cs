
var builder = WebApplication.CreateBuilder(args);

// Session'ı ekleyin
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(50);  // Oturum süresi
    options.Cookie.HttpOnly = true;                  // Cookie'yi sadece HTTP isteklerinde kullanabilmek için
    options.Cookie.IsEssential = true;               // Cookie zorunlu olsun
});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}



// Session'ı kullanmaya başlamadan önce aşağıdaki satırı ekleyin:
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
