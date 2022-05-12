using MarcaTexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// conectando com banco usando string 

var StringConnection = File.ReadAllText("./stringconnection.txt");
 builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(StringConnection));



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
    name: "",
    pattern: "{controller=Textoes}/{action=Create}/{id?}");

app.Run();
