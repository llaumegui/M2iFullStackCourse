docker run -it -d -p 8080:80 --name webContainerA nginx

docker exec -it web bash
    cd /usr/share/nginx/html
    vi index.html
    exit

