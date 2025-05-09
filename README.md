# Setup
## Database
### Postgres Server
If you do not have postgres server, setup one using docker image by running
```bash
docker run --name postgres -e POSTGRES_PASSWORD=SomePasswordHere -p 5432:5432 -d postgres
```
### Run Migration
To run migration, create `appsettings.json` within `DbMigrations` and run `dotnet-ef database update` command.
(Migration inserts 10.000.000 rows, it takes some time)
(if you want faster, with less record, edit 002_MockUsersSeed.sql and update any of two loops itteration count)
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