FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MGonzaga.IoC.NETCore.WebAPI/MGonzaga.IoC.NETCore.WebAPI.csproj", "MGonzaga.IoC.NETCore.WebAPI/"]
COPY ["MGonzaga.IoC.NETCore.BussinessLayer/MGonzaga.IoC.NETCore.BussinessLayer.csproj", "MGonzaga.IoC.NETCore.BussinessLayer/"]
COPY ["MGonzaga.IoC.NETCore.Common/MGonzaga.IoC.NETCore.Common.csproj", "MGonzaga.IoC.NETCore.Common/"]
COPY ["MGonzaga.IoC.NETCore.Domain/MGonzaga.IoC.NETCore.Domain.csproj", "MGonzaga.IoC.NETCore.Domain/"]
COPY ["MGonzaga.IoC.NETCore.Proxys/MGonzaga.IoC.NETCore.Proxys.csproj", "MGonzaga.IoC.NETCore.Proxys/"]
COPY ["MGonzaga.IoC.NETCore.Data/MGonzaga.IoC.NETCore.Data.csproj", "MGonzaga.IoC.NETCore.Data/"]
RUN dotnet restore "MGonzaga.IoC.NETCore.WebAPI/MGonzaga.IoC.NETCore.WebAPI.csproj"
COPY . .
WORKDIR "/src/MGonzaga.IoC.NETCore.WebAPI"
RUN dotnet build "MGonzaga.IoC.NETCore.WebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MGonzaga.IoC.NETCore.WebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MGonzaga.IoC.NETCore.WebAPI.dll"]