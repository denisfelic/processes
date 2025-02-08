using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                        //   policy.WithOrigins("http://localhost:5173", "http://localhost:5000")
                         policy.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                      });
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();


}
else
{
    app.UseHttpsRedirection();


}

// app.UseStaticFiles(new StaticFileOptions
// {
//     FileProvider = new PhysicalFileProvider(
//    Path.Combine(
//        app.Environment.ContentRootPath, "wwwroot", "ClientApp", "dist")),
// });

// app.MapFallbackToFile("/clientapp/{*path:nonfile}", Path.Combine("ClientApp", "dist", "index.html"));

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
   Path.Combine(
       app.Environment.ContentRootPath, "wwwroot", "ClientApp", "dist")),
});

app.MapFallbackToFile("/clientapp/{*path:nonfile}", Path.Combine("ClientApp", "dist", "index.html"));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.UseCors(MyAllowSpecificOrigins);


app.Run();
