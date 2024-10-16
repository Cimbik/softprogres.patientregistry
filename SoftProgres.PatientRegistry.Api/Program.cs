using SoftProgres.PatientRegistry.Api.ServiceInterface;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddServiceStack(typeof(PatientServices).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseServiceStack(new AppHost(), options => {
    options.MapEndpoints();
});

app.Run();