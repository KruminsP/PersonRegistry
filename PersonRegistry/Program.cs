using PersonRegistry.Data;
using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;
using PersonRegistry.Core.Validations;
using PersonRegistry.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:7062", "http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<PersonRegistryDbContext>();

builder.Services.AddScoped<IPersonRegistryDbContext, PersonRegistryDbContext>();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IEntityService<Person>, EntityService<Person>>();
builder.Services.AddScoped<IEntityService<PersonAddress>, EntityService<PersonAddress>>();
builder.Services.AddScoped<IEntityService<PhoneNumber>, EntityService<PhoneNumber>>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<IAddressService, AddressService>();

builder.Services.AddScoped<PersonValidator>();
builder.Services.AddScoped<NumberValidator>();
builder.Services.AddScoped<AddressValidator>();

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

app.UseCors();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
