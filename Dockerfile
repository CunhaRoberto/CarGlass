FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /main
COPY ["PassIn.Api/PassIn.Api.csproj", "PassIn.Api/"]
RUN dotnet restore "PassIn.Api/PassIn.Api.csproj"
COPY . .

RUN dotnet build "PassIn.Api/PassIn.Api.csproj.user" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PassIn.Api/PassIn.Api.csproj.user" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PassIn.Api.dll"]
