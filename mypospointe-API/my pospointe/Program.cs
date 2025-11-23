using my_pospointe.Services;
using my_pospointe.Services.DynamicColumn;
using my_pospointe.Services.DynamicColumn.CRUD;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ShiftCloseNotification>();
builder.Services.AddScoped<ISchema, DynamicSchema>();
builder.Services.AddScoped<ICrudTbl_Items, CrudTbl_Items>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
