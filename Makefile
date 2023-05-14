run:
	dotnet restore MKW/MKW.API
	dotnet run --project MKW/MKW.API
test:
	dotnet test MKW/MKW.Tests/
