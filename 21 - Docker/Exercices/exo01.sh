# générer container à partir d'une image
docker run -it --name container1 ubuntu

#remplir image
mkdir app
echo 'Hello from container1' > app/config.txt
exit

#lancer container
docker start -i container1

##commandes docker
#Liste d'images
docker images
#Liste des conteneurs
docker ps -a