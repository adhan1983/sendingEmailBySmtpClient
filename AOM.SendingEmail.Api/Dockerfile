#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AOM.SendingEmail.Api/AOM.SendingEmail.Api.csproj", "AOM.SendingEmail.Api/"]
RUN dotnet restore "AOM.SendingEmail.Api/AOM.SendingEmail.Api.csproj"
COPY . .
WORKDIR "/src/AOM.SendingEmail.Api"
RUN dotnet build "AOM.SendingEmail.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AOM.SendingEmail.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AOM.SendingEmail.Api.dll"]