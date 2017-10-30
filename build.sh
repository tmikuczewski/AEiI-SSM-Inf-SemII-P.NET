#!/bin/bash
printf "\ndotnet restore ${1}\n"
dotnet restore $1
printf "\ndotnet build ${1}\n"
dotnet build -c Release --no-restore $1
echo