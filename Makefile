run:
	dotnet restore MKW/MKW.API
	dotnet run --project MKW/MKW.API
migrate:
	dotnet ef database update --project MKW/MKW.API
sql:
	dotnet ef migrations script --project MKW/MKW.API
sqlidempotent:
	dotnet ef migrations script --idempotent  --project MKW/MKW.API
test:
	dotnet test MKW/MKW.Tests/
build:
	cd MKW/MKW.API/
	dotnet build
dbup:
	sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=kZaFL2e#H2eK" -p 1433:1433 -d mssql-custom
dockerdown:
	sudo docker stop $(sudo docker ps --quiet)