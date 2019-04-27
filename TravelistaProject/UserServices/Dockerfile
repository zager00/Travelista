FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["UserServices/UserServices.csproj", "UserServices/"]
RUN dotnet restore "UserServices/UserServices.csproj"
COPY . .
WORKDIR "/src/UserServices"
RUN dotnet build "UserServices.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UserServices.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserServices.dll"]