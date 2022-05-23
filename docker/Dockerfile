FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY ./ .
ENV ASPNET_VERSION=5.0.15
ENTRYPOINT ["dotnet", "ApiService.dll"]