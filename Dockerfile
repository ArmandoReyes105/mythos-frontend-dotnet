FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY mythos-frontend-dotnet.sln ./
COPY ./mythos-frontend-dotnet/mythos-frontend-dotnet.csproj ./mythos-frontend-dotnet/

RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

FROM nginx:1.29.0-alpine
WORKDIR /app
EXPOSE 8080
ARG Environment
COPY nginx.conf /etc/nginx/nginx.conf
RUN sed -i "s/replaceme/${Environment}/" /etc/nginx/nginx.conf
COPY --from=build /app/out/wwwroot /usr/share/nginx/html