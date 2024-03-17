using Clinic.Business;
using Clinic.Data;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddDataLayer(builder.Configuration, builder.Environment);
    builder.Services.AddBusinnessLayer();
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Configuration.AddUserSecrets<Program>(optional:true,reloadOnChange:true);
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

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

