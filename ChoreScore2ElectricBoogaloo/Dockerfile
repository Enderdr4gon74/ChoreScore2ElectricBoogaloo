FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 80/tcp

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ChoreScore2ElectricBoogaloo.csproj", "./"]
RUN dotnet restore "ChoreScore2ElectricBoogaloo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ChoreScore2ElectricBoogaloo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChoreScore2ElectricBoogaloo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChoreScore2ElectricBoogaloo.dll"]
