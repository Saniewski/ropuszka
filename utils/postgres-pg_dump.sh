#!/bin/bash

CONTAINER_ID=$(docker container list --filter NAME=postgres --format '{{.ID}}')

docker exec -it $CONTAINER_ID /usr/local/bin/pg_dump --username=postgres --role=postgres -W --table='ropuszka.$1' --data-only --column-inserts ropuszka > /var/lib/postgresql/data/insert_$1.sql

exit 0

