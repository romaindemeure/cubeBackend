# Update schema code

dotnet ef dbcontext scaffold "server=localhost;port=3306;user=cubeUser;password=rWjo0jpFuSpQwTQRM5n7Kg;database=cubeSQL" Pomelo.EntityFrameworkCore.MySql -o Models

# Run projet

dotnet watch

# Name of ORM = EF CORE
