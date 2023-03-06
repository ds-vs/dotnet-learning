#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebAppTwo/WebAppTwo.csproj", "WebAppTwo/"]
RUN dotnet restore "WebAppTwo/WebAppTwo.csproj"
COPY . .
WORKDIR "/src/WebAppTwo"
RUN dotnet build "WebAppTwo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppTwo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppTwo.dll"]