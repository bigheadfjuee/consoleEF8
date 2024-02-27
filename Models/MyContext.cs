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
            .AddUserSecrets<Program>() // 在本機開發使用 secret，不會上傳到 git
            .Build();

        var conStrBuilder = new SqlConnectionStringBuilder(
            configuration.GetConnectionString("DefaultConnection"));

        // 生產環境上的密碼要設定在 appsetting.json 中
        if (configuration["DbPassword"] != null)
            conStrBuilder.Password = configuration["DbPassword"];

        Console.WriteLine(conStrBuilder.ConnectionString);

        optionsBuilder.UseSqlServer(conStrBuilder.ConnectionString);
    }

    // 透過 EF 存取的 table ，要加在這下面
    public DbSet<Student> Students { get; set; }
}