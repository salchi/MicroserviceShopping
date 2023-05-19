#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["1 - ProductService/MicroserviceShopping.ProductService/MicroserviceShopping.ProductService.csproj", "1 - ProductService/MicroserviceShopping.ProductService/"]
COPY ["1 - ProductService/MicroserviceShopping.ProductService.Domain/MicroserviceShopping.ProductService.Domain.csproj", "1 - ProductService/MicroserviceShopping.ProductService.Domain/"]
COPY ["1 - ProductService/MicroserviceShopping.ProductService.Infrastructure/MicroserviceShopping.ProductService.Infrastructure.csproj", "1 - ProductService/MicroserviceShopping.ProductService.Infrastructure/"]
RUN dotnet restore "1 - ProductService/MicroserviceShopping.ProductService/MicroserviceShopping.ProductService.csproj"
COPY . .
WORKDIR "/src/1 - ProductService/MicroserviceShopping.ProductService"
RUN dotnet build "MicroserviceShopping.ProductService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroserviceShopping.ProductService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroserviceShopping.ProductService.dll"]