FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TransactionServices/TransactionServices.csproj", "TransactionServices/"]
RUN dotnet restore "TransactionServices/TransactionServices.csproj"
COPY . .
WORKDIR "/src/TransactionServices"
RUN dotnet build "TransactionServices.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TransactionServices.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TransactionServices.dll"]