FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["PaymentServices/PaymentServices.csproj", "PaymentServices/"]
RUN dotnet restore "PaymentServices/PaymentServices.csproj"
COPY . .
WORKDIR "/src/PaymentServices"
RUN dotnet build "PaymentServices.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PaymentServices.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaymentServices.dll"]