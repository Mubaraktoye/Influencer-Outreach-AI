using Influencer_Outreach_AI.Data;
using Influencer_Outreach_AI.Repositories;
using Influencer_Outreach_AI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IInfluencerRepository, InfluencerRepository>();

// Register services
builder.Services.AddScoped<IInfluencerService, InfluencerService>();

// Configure Semantic Kernel
builder.Services.AddSingleton(sp =>
{
    var builder = Kernel.CreateBuilder()
        .AddAzureOpenAIChatCompletion(
            deploymentName: "",  // Add your deployment name
            endpoint: "",        // Add your endpoint
            apiKey: "");        // Add your API key
    
    return builder.Build();
});

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
