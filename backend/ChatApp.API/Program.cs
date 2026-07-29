using System.Diagnostics;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);

// -------------------- Services --------------------

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// -------------------- Start React Automatically --------------------

if (app.Environment.IsDevelopment())
{
    bool IsPortOpen(int port)
    {
        try
        {
            using TcpClient client = new();
            client.Connect("127.0.0.1", port);
            return true;
        }
        catch
        {
            return false;
        }
    }

    if (!IsPortOpen(5173))
    {
        var frontendPath = Path.GetFullPath(
            Path.Combine(builder.Environment.ContentRootPath, "../../frontend"));

        Process.Start(new ProcessStartInfo
        {
            FileName = "npm",
            Arguments = "run dev",
            WorkingDirectory = frontendPath,
            UseShellExecute = true,
            CreateNoWindow = false
        });

        // Wait for Vite to start
        for (int i = 0; i < 20; i++)
        {
            Thread.Sleep(500);

            if (IsPortOpen(5173))
                break;
        }
    }

    Process.Start(new ProcessStartInfo
    {
        FileName = "http://localhost:5173",
        UseShellExecute = true
    });
}

// -------------------- Middleware --------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();