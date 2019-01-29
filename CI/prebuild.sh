mkdir ../packages
cd ../packages
ln -s ${unityPath}/Editor/Data/Managed/UnityEngine.dll .
cd ../
nuget restore .
