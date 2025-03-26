# Bind mount
cd exo04
docker run -d -p 80:80 -v .:/usr/share/nginx/html --name webBind2 nginx