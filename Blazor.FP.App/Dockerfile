FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Blazor.FP.App/Blazor.FP.App.csproj", "Blazor.FP.App/"]
COPY ["Blazor.FP.BL/Blazor.FP.BL.csproj", "Blazor.FP.BL/"]
COPY ["Blazor.FP.Datacontext/Blazor.FP.Datacontext.csproj", "Blazor.FP.Datacontext/"]
COPY ["Blazor.FP.Datamodels.models/Blazor.FP.Datamodels.models.csproj", "Blazor.FP.Datamodels.models/"]
RUN dotnet restore "Blazor.FP.App/Blazor.FP.App.csproj"
COPY . .
WORKDIR "/src/Blazor.FP.App"
RUN dotnet build "./Blazor.FP.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Blazor.FP.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blazor.FP.App.dll"]
