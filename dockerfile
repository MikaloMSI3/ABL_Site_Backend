FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build


WORKDIR /src


COPY ["ABL.sln", "./"]


COPY ["PublicSite.Domain/", "PublicSite.Domain/"]
COPY ["PublicSite.Application/", "PublicSite.Application/"]
COPY ["PublicSite.Infrastructure/", "PublicSite.Infrastructure/"]
COPY ["PublicSite.Api/", "PublicSite.Api/"]
COPY ["Shared.Domain/", "Shared.Domain/"]


RUN dotnet restore "/src/ABL.sln"


WORKDIR "/src/PublicSite.Api"
RUN dotnet build "PublicSite.Api.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "PublicSite.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

RUN mkdir uploads

COPY --from=publish /app/publish .


EXPOSE 3000

ENTRYPOINT ["dotnet", "PublicSite.Api.dll", "--urls=http://0.0.0.0:3000/"]