FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50181
EXPOSE 44378

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["PCACalcula/PCACalcula.csproj", "PCACalcula/"]
RUN dotnet restore "PCACalcula/PCACalcula.csproj"
COPY . .
WORKDIR "/src/PCACalcula"
RUN dotnet build "PCACalcula.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PCACalcula.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PCACalcula.dll"]