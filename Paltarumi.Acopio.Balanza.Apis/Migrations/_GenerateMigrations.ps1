dotnet new tool-manifest
dotnet tool restore
dotnet tool install dotnet-ef --version 6.0.5

dotnet ef migrations add AcopioMigration_00 --context AcopioDbContext
dotnet ef database update --context AcopioDbContext

dotnet ef migrations add SecurityMigration_00 --context SecurityDbContext
dotnet ef database update --context SecurityDbContext
