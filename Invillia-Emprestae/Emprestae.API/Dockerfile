#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Emprestae.API/Emprestae.API.csproj", "Emprestae.API/"]
RUN dotnet restore "Emprestae.API/Emprestae.API.csproj"
COPY . .
WORKDIR "/src/Emprestae.API"
RUN dotnet build "Emprestae.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Emprestae.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Emprestae.API.dll"]