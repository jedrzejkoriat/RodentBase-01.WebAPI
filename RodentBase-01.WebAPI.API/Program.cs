using RodentBase_01.WebAPI.API.Configuration;
using RodentBase_01.WebAPI.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRateLimiterConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddLoggerConfiguration();
builder.Services.AddB2NetConfiguration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();