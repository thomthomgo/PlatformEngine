#!/bin/bash
SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
mkdir $SCRIPTPATH/../packages
ln -s ${unityPath}/Editor/Data/Managed/UnityEngine.dll $SCRIPTPATH/../packages
ls -la $SCRIPTPATH/../packages
nuget restore $SCRIPTPATH/../
