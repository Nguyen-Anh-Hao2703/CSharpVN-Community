# Chạy trên môi trường .NET 9 (hoặc version bạn đang dùng)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
# Copy file dự án vào đúng chỗ
COPY ["CSharpVN Community.csproj", "."]
RUN dotnet restore "./CSharpVN Community.csproj"
# Copy toàn bộ code còn lại
COPY . .
RUN dotnet build "CSharpVN Community.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharpVN Community.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharpVN Community.dll"]