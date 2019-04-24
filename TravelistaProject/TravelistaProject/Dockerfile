FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TravelistaProject/TravelistaProject.csproj", "TravelistaProject/"]
RUN dotnet restore "TravelistaProject/TravelistaProject.csproj"
COPY . .
WORKDIR "/src/TravelistaProject"
RUN dotnet build "TravelistaProject.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TravelistaProject.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TravelistaProject.dll"]