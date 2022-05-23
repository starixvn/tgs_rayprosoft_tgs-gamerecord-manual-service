#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BuildConfiguration=Release
RUN --mount=type=secret,id=nuget,dst=/pat cp /pat ~/.nuget/NuGet/NuGet.Config
RUN dotnet nuget remove source 'Microsoft Visual Studio Offline Packages' || true
WORKDIR /src
COPY ["NuGet.config", "."]
COPY ["Tgs.GameRecord.ManualService/Tgs.GameRecord.ManualService.csproj", "Tgs.GameRecord.ManualService/"]
COPY ["Tgs.GameRecord.ManualService.Core/Tgs.GameRecord.ManualService.Core.csproj", "Tgs.GameRecord.ManualService.Core/"]
RUN dotnet restore "Tgs.GameRecord.ManualService/Tgs.GameRecord.ManualService.csproj"
COPY . .
WORKDIR "/src/Tgs.GameRecord.ManualService"
RUN dotnet build "Tgs.GameRecord.ManualService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tgs.GameRecord.ManualService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tgs.GameRecord.ManualService.dll"]