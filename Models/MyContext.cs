using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace console8ef.Models;
public class MyContext : DbContext
{
    public MyContext()
    {
    }
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>() // 本機開發使用 secret
            .Build();

        var conStrBuilder = new SqlConnectionStringBuilder(
            configuration.GetConnectionString("DefaultConnection"));

        // 密碼另外存放
        // conStrBuilder.Password = configuration["DbPassword"];
        Console.WriteLine(conStrBuilder.ConnectionString);

        optionsBuilder.UseSqlServer(conStrBuilder.ConnectionString);
    }

    public DbSet<Student> Students { get; set; }
}