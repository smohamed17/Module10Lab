using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container and added the petadoptioncontext
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PetAdoptionContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("PetAdoptionContext")));

var app = builder.Build();
// this will start up the service in the application container and 
// make sures that the database is created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PetAdoptionContext>();
    // it will use the DB context to create the pets' database.
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
