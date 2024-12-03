
namespace simplepro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication("YourScheme") // Replace with your authentication scheme (e.g., JWT or Cookies)
                .AddCookie("YourScheme", options =>
                {
                    options.LoginPath = "/Account/Login"; // Define the login path if needed
                });

            builder.Services.AddAuthorization();

            builder.Services.AddControllers();

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
        }
    }
}
