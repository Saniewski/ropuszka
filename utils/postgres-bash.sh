#!/bin/bash

CONTAINER_ID=$(docker container list --filter NAME=postgres --format '{{.ID}}')

docker exec -it $CONTAINER_ID /bin/bash

exit 0

