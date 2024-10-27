# Project Name: UniManage

## 31927 - Applications Development with .NET 32998 - .NET Applications Development

## Group Details:
-
- 24506800 Fatin Adas

##  RUNNING THE PROJECT

### Pre-requisites
- For MySQL, the root account has user: `root` & pass: `rootpassword1`. If attempting to run code on own device modify these variables in the AppDBContext.cs  following method:
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    // Use Pomelo MySQL with connection string
    optionsBuilder.UseMySql("server=localhost;database=unimanage;user=root;password=rootpassword1;",
        new MySqlServerVersion(new Version(8, 0, 32))); 
}

- first time user needs to run in the package manager console in vm the following commands: 
    - 'Add-Migration InitialCreate'
    - 'Update-Database'
- if changed model or their attributes must run follwoign commands to aumoatically update the db locally:
    - 'Add-Migration AddNewProperty'
    - 'Update-Database'


