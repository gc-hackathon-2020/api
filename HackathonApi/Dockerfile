FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["HackathonApi/HackathonApi.csproj", "HackathonApi/"]
RUN dotnet restore "HackathonApi/HackathonApi.csproj"
COPY . .
WORKDIR "/src/HackathonApi"
RUN dotnet build "HackathonApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HackathonApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HackathonApi.dll"]