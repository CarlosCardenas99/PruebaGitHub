﻿dotnet ef dbcontext scaffold "Server=.;Initial Catalog=AcopioQA;User ID=sa;Password=Pass@word1;" Microsoft.EntityFrameworkCore.SqlServer --namespace "Paltarumi.Acopio.Entity" --context "AcopioDbContext" --context-namespace "Paltarumi.Acopio.Repository.Data" --force