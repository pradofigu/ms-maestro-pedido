FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ["OrderService/src/OrderService/OrderService.csproj", "./OrderService/src/OrderService/"]
COPY ["SharedKernel/SharedKernel.csproj", "./SharedKernel/"]
RUN dotnet restore "./OrderService/src/OrderService/OrderService.csproj"

# Copy everything else and build
COPY . ./
RUN dotnet build "OrderService/src/OrderService/OrderService.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "OrderService/src/OrderService/OrderService.csproj" -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/out .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/OrderService.dll"]
