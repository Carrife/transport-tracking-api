#!/bin/bash

sudo dotnet publish --configuration Release -p:ASPNETCORE_ENVIRONMENT=Production -o:/var/www/transport-tracking-api

sudo cp ./DeployFiles/default /etc/nginx/sites-available/

sudo cp ./DeployFiles/transport-tracking-api.service /etc/systemd/system/

sudo systemctl enable transport-tracking-api.service
sudo systemctl start transport-tracking-api.service
sudo systemctl status transport-tracking-api.service

