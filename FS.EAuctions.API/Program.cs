using FS.EAuctions.API.BackgroundServices;
using FS.EAuctions.API.Hub;
using FS.EAuctions.API.Infrastructure;
using FS.EAuctions.Application.Infrastructure;
using FS.EAuctions.Application.SupplierAuctions.Consumer;
using FS.EAuctions.Data.DBContexts;
using Microsoft.EntityFrameworkCore;
using FS.EAuctions.Data.DBContexts.Application;
using FS.EAuctions.Data.Repository;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using Fs.EAuctions.Domain.Contracts;

// Log.Logger = new LoggerConfiguration()
// 	.MinimumLevel.Debug()
// 	.WriteTo.Console()
// 	.WriteTo.File("logs/auctionlogs.txt", rollingInterval: RollingInterval.Day)
// 	.CreateLogger();

var builder = WebApplication.CreateBuilder(args);
//builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers(options =>
{
	options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
	.AddXmlDataContractSerializerFormatters();

builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

var configuration = builder.Configuration["ConnectionStrings:AuctionDBConnectionString"];

builder.Services.AddDbContext<AuctionDbContext>(
    dbContextOptions => dbContextOptions.UseNpgsql(configuration)
);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAuctionRepository<BuyerAuction, BuyerBid>, BuyerAuctionRepository>();
builder.Services.AddScoped<IAuctionRepository<SupplierAuction, SupplierBid>, SupplierAuctionRepository>();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		policy.AllowAnyHeader()
			.AllowAnyMethod()
			.AllowCredentials()
			.SetIsOriginAllowed(origin => true); // Allow all origins for development
	});
});
builder.Services.AddHostedService<TimerBackgroundService>();
builder.Services.AddHostedService<CreateSupplierAuctionMessageConsumer>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<RabbitMQConfiguration>(builder.Configuration.GetSection("RabbitMQConfiguration"));
builder.Services.AddSingleton<IMessagePublisher, MessagePublisher>(); 
	
var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.MapHub<AuctionHub>("/auctionHub");

app.Run();
