from mcr.microsoft.com/dotnet/sdk:5.0

expose 5000

COPY bin/Debug/net5.0/wwwroot App/
WORKDIR /App
ENTRYPOINT ["dotnet", "editor.dll"]
