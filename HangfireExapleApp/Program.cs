using Hangfire;
using HangfireExapleApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//����������� Hangfire
builder.Services.AddHangfire(h =>
    h.UseSqlServerStorage("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HermesForecastHangfire;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
builder.Services.AddHangfireServer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//������������ ��� ������ ������
builder.Services.AddSingleton<IMyJob, MyJob>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//����������� Hangfire Dashboard, ������ �� ���� /dashboard ����� �������� �������
app.UseHangfireDashboard("/dashboard");

RecurringJob.AddOrUpdate((IMyJob myjob)=> myjob.Print() ,Cron.Daily);

app.MapControllers();

app.Run();
