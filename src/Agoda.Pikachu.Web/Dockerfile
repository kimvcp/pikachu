FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Agoda.Pikachu.Web.csproj", "./"]
COPY ["../Agoda.Pikachu.Api/Agoda.Pikachu.Api.csproj", "../Agoda.Pikachu.Api/"]
RUN dotnet restore "Agoda.Pikachu.Web.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Agoda.Pikachu.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Agoda.Pikachu.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Agoda.Pikachu.Web.dll"]
