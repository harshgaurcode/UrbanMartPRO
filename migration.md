
Powershell cmd for Migration -


    dotnet ef migrations add InitialIdentity `
        --context IdentityDbContext `
        --project UrbanMart.Modules `
        --startup-project UrbanMart.Api `
        --output-dir Identity/Persistence/Migrations


Update Database

dotnet ef database update `
    --context IdentityDbContext `
    --project UrbanMart.Modules `
    --startup-project UrbanMart.Api