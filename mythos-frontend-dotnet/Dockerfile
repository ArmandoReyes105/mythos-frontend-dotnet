# Etapa 1: build de la app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar el contenido del proyecto
COPY . . 

# Publicar la app (esto genera archivos estáticos en /app/dist/wwwroot)
RUN dotnet publish -c Release -o /app/dist

# Etapa 2: imagen final basada en NGINX
FROM nginx:alpine

# Elimina archivos por defecto de nginx
RUN rm -rf /usr/share/nginx/html/*

# Copia los archivos publicados desde la etapa anterior
COPY --from=build /app/dist/wwwroot /usr/share/nginx/html

# Expone el puerto por el que servirá la app
EXPOSE 80

# Comando por defecto: arrancar nginx
CMD ["nginx", "-g", "daemon off;"]
