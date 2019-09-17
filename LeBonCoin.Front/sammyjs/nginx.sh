docker run --rm --volume="$PWD/nginx.conf:/etc/nginx/nginx.conf:" --name chezbassou-nginx --network="host" nginx:1.16.0-alpine

# https://stackoverflow.com/questions/24319662/from-inside-of-a-docker-container-how-do-i-connect-to-the-localhost-of-the-mach