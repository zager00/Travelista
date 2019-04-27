FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["NotificationServices/NotificationServices.csproj", "NotificationServices/"]
RUN dotnet restore "NotificationServices/NotificationServices.csproj"
COPY . .
WORKDIR "/src/NotificationServices"
RUN dotnet build "NotificationServices.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NotificationServices.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NotificationServices.dll"]