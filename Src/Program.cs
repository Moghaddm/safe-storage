using UserSecrets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConnectionString = builder.Configuration["ConnectionStrings:MSSQL"];
ConfigurationSettings mapClass = builder.Configuration.GetSection("ConnectionStrings:MSSQL").Get<ConfigurationSettings>()!;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/",()=> {
    return ConnectionString;
});
app.MapGet("/class",() => {
    return mapClass;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
