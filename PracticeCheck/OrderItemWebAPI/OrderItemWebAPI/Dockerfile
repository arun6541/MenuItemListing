##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
#WORKDIR /src
#COPY ["OrderItemWebAPI/OrderItemWebAPI.csproj", "OrderItemWebAPI/"]
#RUN dotnet restore "OrderItemWebAPI/OrderItemWebAPI.csproj"
#COPY . .
#WORKDIR "/src/OrderItemWebAPI"
#RUN dotnet build "OrderItemWebAPI.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "OrderItemWebAPI.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "OrderItemWebAPI.dll"]

# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore
# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "OrderItemWebAPI.dll"]