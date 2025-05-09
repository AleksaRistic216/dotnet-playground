# Setup
## Database
### Postgres Server
If you do not have postgres server, setup one using docker image by running
```bash
docker run --name postgres -e POSTGRES_PASSWORD=SomePasswordHere -p 5432:5432 -d postgres
```
### Run Migration
To run migration, create `appsettings.json` within `DbMigrations` and run `dotnet-ef database update` command
#### appsettings.json template
```json
{
    "POSTGRES_HOST": "localhost",
    "POSTGRES_PORT": 5432,
    "POSTGRES_USER": "postgres",
    "POSTGRES_PASSWORD": "SomePasswordHere",
    "POSTGRES_DATABASE": "LDSSM"
}
```