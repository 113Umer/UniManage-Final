# Project Name: UniManage

## 31927 - Applications Development with .NET 32998 - .NET Applications Development

## Group Details:
-24890586 Muhammad umer jamil
- 24506800 Fatin Adas

##  RUNNING THE PROJECT
- Simply download and run when the db is configured as advised below

### Pre-requisites
- Ensure mysql version 8 is installed on your device.
- For MySQL, the root account has user: `root` & pass: `rootpassword1`. If attempting to run code on own device modify these variables in the AppDBContext.cs  following method:
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    // Use Pomelo MySQL with connection string
    optionsBuilder.UseMySql("server=localhost;database=unimanage;user=root;password=rootpassword1;",
        new MySqlServerVersion(new Version(8, 0, 32))); 
}



