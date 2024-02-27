# .NET 8 Console - Entity Framework Core 8 - SQL Server

## EF Core 8
https://learn.microsoft.com/zh-tw/ef/core/what-is-new/ef-core-8.0/whatsnew

安裝 dotnet-ef 工具，使用 Migrations 來追蹤 Model 的變化，並且更新 DB Schema。

```powershell
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 從既有的 DB 產生 model cs code

* Scaffolding (Reverse Engineering)

```powershell
dotnet ef dbcontext scaffold "Server=DB_addr;Database=DB_name;User ID=username;
password=; Trusted_Connection=True;Integrated Security=False;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -d -o Model/Entities
```

參考 https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?WT.mc_id=DOP-MVP-37580&tabs=dotnet-core-cli

## 保護 DB 連接字串的密碼

* 在本機開發環境使用 User Secrets

```powershell
dotnet user-secrets init
dotnet user-secrets set "DbPassword" "pass123"
```

參考 https://learn.microsoft.com/zh-tw/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows

* 在生產環境要從 appsettings.json 讀取

```json
{
  "DbPassword": "pass123"
}
```

* MyContext.cs
>override void OnConfiguring 方法，從 Configuration 取得 ConnectionStrings 和 DbPassword
>並使用 SqlConnectionStringBuilder 
