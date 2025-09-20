using TaskManagement.SIgnalR;

namespace TaskManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .SetIsOriginAllowed(_ => true) // allow all origins
                          .AllowCredentials();            // important for SignalR
                });
            });

            // Add SignalR
            builder.Services.AddSignalR();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();            // ✅ Required before CORS & endpoints
            app.UseCors("CorsPolicy");   // ✅ Apply CORS
            app.UseAuthorization();

            app.MapControllers();
            app.MapHub<SignalrHub>("/chatHub");

            app.Run();
        }
    }
}
