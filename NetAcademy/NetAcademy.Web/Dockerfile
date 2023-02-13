FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NetAcademy/NetAcademy.csproj", "NetAcademy/"]
RUN dotnet restore "NetAcademy/NetAcademy.csproj"
COPY . .
WORKDIR "/src/NetAcademy"
RUN dotnet build "NetAcademy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetAcademy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetAcademy.dll"]
