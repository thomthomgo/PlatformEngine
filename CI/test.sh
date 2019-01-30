#!/bin/bash
SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
echo "Run tests on following projects :"
IFS=$'\n'
for i in $(cat < "$1"); do
    echo "$i"
   $projects += "$SCRIPTPATH/$i"
done

mono usr/local/bin/NUnit.ConsoleRunner.3.9.0/tools/nunit3-console.exe $projects
