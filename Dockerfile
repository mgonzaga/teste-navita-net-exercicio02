FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/MGonzaga.IoC.NETCore.WebAPI/MGonzaga.IoC.NETCoreWebAPI.csproj", "src/MGonzaga.IoC.NETCore.WebAPI/"]
COPY ["src/MGonzaga.IoC.NETCore.Repositories/MGonzaga.IoC.NETCore.Repositories.csproj", "src/MGonzaga.IoC.NETCore.Repositories/"]
COPY ["src/MGonzaga.IoC.NETCore.Domain/MGonzaga.IoC.NETCore.Domain.csproj", "src/MGonzaga.IoC.NETCore.Domain/"]
COPY ["src/MGonzaga.IoC.NETCore.Common/MGonzaga.IoC.NETCore.Common.csproj", "src/MGonzaga.IoC.NETCore.Common/"]
COPY ["src/MGonzaga.IoC.NETCore.BusinessLayer/MGonzaga.IoC.NETCore.BusinessLayer.csproj", "src/MGonzaga.IoC.NETCore.BusinessLayer/"]
COPY ["src/MGonzaga.IoC.NETCore.Proxys/MGonzaga.IoC.NETCore.Proxys.csproj", "src/MGonzaga.IoC.NETCore.Proxys/"]
COPY ["src/MGonzaga.IoC.NETCore.Data/MGonzaga.IoC.NETCore.Data.csproj", "src/MGonzaga.IoC.NETCore.Data/"]
RUN dotnet restore "src/MGonzaga.IoC.NETCore.WebAPI/MGonzaga.IoC.NETCoreWebAPI.csproj"
COPY . .
WORKDIR "src/src/MGonzaga.IoC.NETCore.WebAPI"
RUN dotnet build "MGonzaga.IoC.NETCoreWebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MGonzaga.IoC.NETCoreWebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MGonzaga.IoC.NETCore.WebAPI.dll"]