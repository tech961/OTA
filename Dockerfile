# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Rs.Api/Rs.Api.csproj", "Rs.Api/"]
COPY ["Rs.Application/Rs.Application.csproj", "Rs.Application/"]
COPY ["Rs.Domain/Rs.Domain.csproj", "Rs.Domain/"]
COPY ["Rs.Infrastructure/Rs.Infrastructure.csproj", "Rs.Infrastructure/"]
COPY ["Rs.Persistence/Rs.Persistence.csproj", "Rs.Persistence/"]
COPY ["Rs.Utility/Rs.Utility.csproj", "Rs.Utility/"]

RUN dotnet restore "Rs.Api/Rs.Api.csproj"

COPY . .
WORKDIR /src/Rs.Api
RUN dotnet publish "Rs.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Rs.Api.dll"]
