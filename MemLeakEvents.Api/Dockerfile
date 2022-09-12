FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MemLeakEvents.Api/MemLeakEvents.Api.csproj", "MemLeakEvents.Api/"]
RUN dotnet restore "MemLeakEvents.Api/MemLeakEvents.Api.csproj"
COPY . .
WORKDIR "/src/MemLeakEvents.Api"
RUN dotnet build "MemLeakEvents.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MemLeakEvents.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MemLeakEvents.Api.dll"]
