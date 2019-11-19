FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Permission.Rest/Permission.Rest.csproj", "Permission.Rest/"]
RUN dotnet restore "Permission.Rest/Permission.Rest.csproj"
COPY . .
WORKDIR "/src/Permission.Rest"
RUN dotnet build "Permission.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Permission.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Permission.Rest.dll"]