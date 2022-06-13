FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app

# install System.Drawing native dependencies
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
     && rm -rf /var/lib/apt/lists/*


COPY ./ .

ENV ASPNET_VERSION=6.0

ENTRYPOINT ["dotnet", "Paltarumi.Acopio.Apis.dll"]