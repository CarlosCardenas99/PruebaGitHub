dotnet ef migrations add AcopioMigration_00 --context AcopioDbContext
dotnet ef database update --context AcopioDbContext

dotnet ef migrations add SecurityMigration_00 --context SecurityDbContext
dotnet ef database update --context SecurityDbContext
