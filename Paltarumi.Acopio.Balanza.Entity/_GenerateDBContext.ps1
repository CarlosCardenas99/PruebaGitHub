﻿dotnet ef dbcontext scaffold "Server=192.168.8.24;Initial Catalog=AcopioQA;User ID=sa;Password=@SistemaAcopio1;" Microsoft.EntityFrameworkCore.SqlServer --namespace "Paltarumi.Acopio.Balanza.Entity" --context "AcopioDbContext" --context-namespace "Paltarumi.Acopio.Balanza.Repository.Data" --force