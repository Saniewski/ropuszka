#!/bin/bash

docker compose down ; rm -r ./mongo/db-data ; rm -r ./postgres/db-data ; docker compose up -d --build

exit 0

