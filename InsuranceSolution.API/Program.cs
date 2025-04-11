Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Information("myInterlife API starting...");

var builder = WebApplication.CreateBuilder(args);
//ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

builder.Host.UseSerilog(
      (context, services, configuration) => configuration
          .ReadFrom.Configuration(context.Configuration)
          .ReadFrom.Services(services)
          .Enrich.FromLogContext()
          .WriteTo.Console(),
      true
  );
var app = builder
       .ConfigureServices()
       .ConfigurePipeline();
await app.MigrateDBAsync();
//await app.ResetDatabaseAsync();
app.Run();
