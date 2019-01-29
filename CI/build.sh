#!/bin/bash
SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
msbuild $SCRIPTPATH/../PlatformEngine.sln
