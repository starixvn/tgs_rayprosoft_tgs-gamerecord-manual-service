using System.Text.Json.Serialization;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("/config/appsettings.json", true)
    .AddEnvironmentVariables();

builder.Logging
    .AddOpenTelemetry(options =>
    {
        options.IncludeFormattedMessage = true;
        options.ParseStateValues = true;
        _ = options.AddFluentdForwardExporter(fluentOptions =>
        {
            var nodeIp = builder.Configuration.GetValue<string>("NODE_IP")!;
            fluentOptions.Host = nodeIp;
            fluentOptions.Tag = builder.Configuration.GetValue<string>("OTEL_SERVICE_NAME")!;
            fluentOptions.UseMessagePack();
        });
    });

// Add services to the container.

builder.Services
    .AddRouting(options => options.LowercaseUrls = true)
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFileNames = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xml");
    foreach (var xmlFileName in xmlFileNames)
    {
        c.IncludeXmlComments(xmlFileName);
    }
});

builder.Services.AddManualServiceCore(
  (options, sp) =>
  {
      var configuration = sp.GetRequiredService<IConfiguration>();
      options.BaseUrl = configuration.GetValue<Uri>("GameRecord:GameRoundsScheduleClientBaseUrl")!;
  });

builder.Services
    .AddMessageQueue()
     .AddNatsMessageQueue(natsConfig =>
     {
         _ = natsConfig
         .ConfigQueueOptions((options, sp) =>
         {
             var configuration = sp.GetRequiredService<IConfiguration>();
             options.Url = configuration.GetConnectionString("Nats")!;
         });
     })
    .ClearAllExchanges()
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.avia")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.bg.fishing")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.ky")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.ly")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.tcg")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.vr")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.wgvia")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.wgfm")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.dg")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.joker")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.pptf")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.jilitf")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.wmtf")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.swtf")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.jdbtf")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.sbotf")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.bti")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.sabatf")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.sm01")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.tftf")
    .AddNatsGlobPatternExchange("gp.gamerecord.manual.endor");

builder.Services
    .AddOpenTelemetry()
    .WithTracing(builder => builder
        .SetResourceBuilder(ResourceBuilder.CreateDefault()
            .AddEnvironmentVariableDetector())
        .AddSource("Tgs.*")
        .AddSource("TGS.*")
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddGrpcClientInstrumentation()
        .AddGrpcCoreInstrumentation()
        .AddEntityFrameworkCoreInstrumentation(options => options.SetDbStatementForText = true)
        .AddOtlpExporter())
    .WithMetrics(meterBuiler => meterBuiler
    .SetResourceBuilder(ResourceBuilder.CreateDefault()
    .AddEnvironmentVariableDetector())
    .AddRuntimeInstrumentation()
    .AddAspNetCoreInstrumentation()
    .AddOtlpExporter())
    .Services
    .Configure<AspNetCoreInstrumentationOptions>(options => options.Filter =
        httpContext => !httpContext.Request.Path.HasValue
            || !httpContext.Request.Path.StartsWithSegments("/swagger")
            && !httpContext.Request.Path.StartsWithSegments("/health")
            && !httpContext.Request.Path.StartsWithSegments("/profiler/")
            && !httpContext.Request.Path.StartsWithSegments("/metrics")
            && !new[] { "html", "ico", "png", "jpg" }.Any(
                ext => httpContext.Request.Path.Value.EndsWith($".{ext}")))
    .AddInterceptionService()
    .AddServiceUtiltiyInterceptors();

builder.Services
    .AddHealthChecks()
    .ForwardToPrometheus();

var app = builder.Build();

_ = app.UseSwagger();
_ = app.UseSwaggerUI();

_ = app.UseAuthorization();

_ = app.MapControllers();

app.MapHealthChecks("/healthz");

app.Run();
