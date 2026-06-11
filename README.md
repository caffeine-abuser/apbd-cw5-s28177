>[!NOTE]
> Yes, I committed a MSSQL connection string into `appsettings.json`, with `sa` and a shoddy password no less, I know I shouldn't do it in production.
> No, I don't really care, since basically the only way of using MSSQL on Linux is via containers and this thing points at 127.0.0.1. Anyone who *actually* rips this off and uses it is foolhardy to say the least.

Anyway, as for the setup on Linux:

```shell
podman run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Your_Password_Here_:3" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

# install sqlcmd in the meantime; see https://learn.microsoft.com/en-us/sql/linux/install-upgrade/setup-tools
sqlcmd -S 127.0.0.1,1433 -U sa -P "Your_Password_Here_:3" -i create.sql

# add the DevDB connection string - user and password - to appsettings.json
vim appsettings.json

# and finally run the application
dotnet run
```
