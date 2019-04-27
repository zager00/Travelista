FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["FlightServices/FlightServices.csproj", "FlightServices/"]
RUN dotnet restore "FlightServices/FlightServices.csproj"
COPY . .
WORKDIR "/src/FlightServices"
RUN dotnet build "FlightServices.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FlightServices.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FlightServices.dll"]