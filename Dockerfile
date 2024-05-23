FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /main
COPY ["PassIn.Api/CarGlass.Api.csproj", "PassIn.Api.Api/"]
RUN dotnet restore "PassIn.Api/CarGlass.Api.csproj"
COPY . .

RUN dotnet build "PassIn.Api/CarGlass.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PassIn.Api/CarGlass.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarGlass.Api.dll"]
