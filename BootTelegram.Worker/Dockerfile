﻿FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["BootTelegram/BootTelegram.csproj", "BootTelegram/"]
RUN dotnet restore "BootTelegram/BootTelegram.csproj"
COPY . .
WORKDIR "/src/BootTelegram"
RUN dotnet build "BootTelegram.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BootTelegram.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BootTelegram.dll"]
