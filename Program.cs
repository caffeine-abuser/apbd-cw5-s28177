using apbd_cw5_s28177;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connString = builder.Configuration.GetConnectionString("DevDB")
    // cannot recover from not having a db, panic and exit
    ?? throw new InvalidOperationException("Required MSSQL connection string 'DevDB' not found. Add one in appsettings.json and try again.");

builder.Services.AddDbContext<HospitalContext>(options => {
    options.UseSqlServer(connString, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
});

var app = builder.Build();

// we are not using migrations here. db-first docs apparently say you either repeatedly scaffold, or scaffold once,
// then switch to migrations as the source of truth for your schema. there are no changes to be expected here, so
// i just went for the lower effort approach since migrations are seemingly not required for this exercise. oh well
//
// await using (var scope = app.Services.CreateAsyncScope())
// {
//     var ctx = scope.ServiceProvider.GetRequiredService<HospitalContext>();
//     await ctx.Database.MigrateAsync();
// }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
