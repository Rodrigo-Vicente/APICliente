BackEnd feito em clean architecture 

Alguns passos que presisam ser feitos:

Migration:
1- Para iniciar o migration usar o comando add-migration 'Exemplo' -Context AppIdentityContext.
2- update-database.

Docker e SQL:
O banco está em docker comandos utilizados para criar:
1- Baixar a imagem do SQL SERVER no Docker Hub
docker pull mcr.microsoft.com/mssql/server:2019-latest

2- Inicie uma instância do mssql-server em execução como a edição SQL Express
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=SenhaExemplo" -e "MSSQL_PID=Express" --name 'sqlServer' -p 1433:1433 -v sql1data:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2019-latest
