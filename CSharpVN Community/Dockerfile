FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
# Vì đã đặt Root Directory nên chỉ cần copy trực tiếp
COPY ["CSharpVN Community.csproj", "./"]
RUN dotnet restore "CSharpVN Community.csproj"
COPY . .
RUN dotnet build "CSharpVN Community.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharpVN Community.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharpVN Community.dll"]