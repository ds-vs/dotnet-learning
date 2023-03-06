#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebAppOne/WebAppOne.csproj", "WebAppOne/"]
RUN dotnet restore "WebAppOne/WebAppOne.csproj"
COPY . .
WORKDIR "/src/WebAppOne"
RUN dotnet build "WebAppOne.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppOne.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppOne.dll"]