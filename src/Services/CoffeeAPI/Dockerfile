#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/CoffeeAPI/CoffeeAPI.csproj", "src/Services/CoffeeAPI/"]
RUN dotnet restore "src/Services/CoffeeAPI/CoffeeAPI.csproj"
COPY . .
WORKDIR "/src/src/Services/CoffeeAPI"
RUN dotnet build "CoffeeAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoffeeAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoffeeAPI.dll"]