using Microsoft.Extensions.DependencyInjection.Extensions;
using Renderino.Middleware;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LoggingMidlleware>();


builder.Services
	.AddScoped<IUsersService, UsersService>()
	.AddScoped<IUsersReository, UsersRepository>()
	.AddScoped<IProfileRepository, ProfileRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
	options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
	options.RoutePrefix = "swagger";
});
app.UseStaticFiles();

app.UseMiddleware<LoggingMidlleware>();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	 name: "default",
	 pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
