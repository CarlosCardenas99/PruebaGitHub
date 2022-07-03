#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Paltarumi.Acopio.Balanza.Apis/Paltarumi.Acopio.Balanza.Apis.csproj", "Paltarumi.Acopio.Balanza.Apis/"]
RUN dotnet restore "Paltarumi.Acopio.Balanza.Apis/Paltarumi.Acopio.Balanza.Apis.csproj"
COPY . .
WORKDIR "/src/Paltarumi.Acopio.Balanza.Apis"
RUN dotnet build "Paltarumi.Acopio.Balanza.Apis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Paltarumi.Acopio.Balanza.Apis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paltarumi.Acopio.Balanza.Apis.dll"]