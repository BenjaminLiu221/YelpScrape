using YelpScrapeWeb.Data;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.EntityFrameworkCore;
using YelpScrapeWeb.Models.YelpGraphQLBusinesses;
using YelpScrapeWeb.Models.YelpGraphQLReviews;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddHttpClient();

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

void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<ISearchBusinessesConsumer, SearchBusinessesConsumer>();
    services.AddTransient<ISearchBusinessesResultsConsumer, SearchBusinessesResultsConsumer>();
    services.AddTransient<ISearchReviewsConsumer, SearchReviewsConsumer>();
    services.AddTransient<ISearchReviewsResultsConsumer, SearchReviewsResultsConsumer>();
}