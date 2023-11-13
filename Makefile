run:
	dotnet restore MKW/MKW.API
	dotnet run --urls http://localhost:7240 --project MKW/MKW.API
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
	# sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=kZaFL2e#H2eK" -p 1433:1433 -d mssql-custom
	docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=kZaFL2e#H2eK" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
dockerdown:
	docker stop $(docker ps --quiet)
client:
	cd ../MKW.Client/MKW && ionic serve
all: dbup migrate run client

analyze:
	dotnet sonarscanner begin /k:"MKW" /d:sonar.host.url="http://localhost:9000" /d:sonar.scm.provider="git" /d:sonar.token="sqp_7e26a388d42517d1cf47ee2b95e2f32f2bae6fae" /d:sonar.cs.opencover.reportsPaths=coverage.xml
	dotnet build MKW/MKW.API --no-incremental
	# dotnet test MKW/MKW.Tests /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=coverage.xml -l trx --no-build 
	coverlet ./MKW/MKW.Tests/bin/Debug/net6.0/MKW.Tests.dll --target "dotnet" --targetargs "test MKW/MKW.Tests --no-build" -f=opencover -o="coverage.xml"
	dotnet sonarscanner end /d:sonar.token="sqp_7e26a388d42517d1cf47ee2b95e2f32f2bae6fae"
