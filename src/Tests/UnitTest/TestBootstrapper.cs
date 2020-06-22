using backend.Models;
using Microsoft.EntityFrameworkCore;

public class TestBootstrapper
{
    
    public static DbContextOptions<CattleyaToursContext> GetInMemoryDbContextOptions(string dbName = "Test_DB")
    {
        var options = new DbContextOptionsBuilder<CattleyaToursContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;
        
        return options;
    }

}
    