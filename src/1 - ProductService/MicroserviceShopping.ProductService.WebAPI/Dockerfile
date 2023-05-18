#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["1 - ProductService/MicroserviceShopping.ProductService.WebAPI/MicroserviceShopping.ProductService.WebAPI.csproj", "1 - ProductService/MicroserviceShopping.ProductService.WebAPI/"]
COPY ["1 - ProductService/MicroserviceShopping.ProductService.Application/MicroserviceShopping.ProductService.Application.csproj", "1 - ProductService/MicroserviceShopping.ProductService.Application/"]
COPY ["1 - ProductService/MicroserviceShopping.ProductService.Domain/MicroserviceShopping.ProductService.Domain.csproj", "1 - ProductService/MicroserviceShopping.ProductService.Domain/"]
COPY ["1 - ProductService/MicroserviceShopping.ProductService.Infrastructure/MicroserviceShopping.ProductService.Infrastructure.csproj", "1 - ProductService/MicroserviceShopping.ProductService.Infrastructure/"]
RUN dotnet restore "1 - ProductService/MicroserviceShopping.ProductService.WebAPI/MicroserviceShopping.ProductService.WebAPI.csproj"
COPY . .
WORKDIR "/src/1 - ProductService/MicroserviceShopping.ProductService.WebAPI"
RUN dotnet build "MicroserviceShopping.ProductService.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroserviceShopping.ProductService.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroserviceShopping.ProductService.WebAPI.dll"]