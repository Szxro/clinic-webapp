using Clinic.Business;
using Clinic.Data;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddDataLayer(builder.Environment);
    builder.Services.AddBusinnessLayer();
    builder.Services.AddControllers();
    builder.Services.AddCors();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Configuration.AddUserSecrets<Program>(optional:false,reloadOnChange:true);
}


var app = builder.Build();
{ 
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();

        app.UseSwaggerUI();

        await app.Services.InitializeDatabaseAsync();
    }

    app.UseHttpsRedirection();

    app.UseCors(options => 
    {
        options.AllowAnyHeader();
        options.AllowAnyMethod();
        options.AllowAnyOrigin();
    });

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

