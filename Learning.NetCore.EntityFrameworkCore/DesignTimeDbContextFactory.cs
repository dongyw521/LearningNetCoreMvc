using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Learning.NetCore.EntityFrameworkCore
{

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<kuchenDbContext>
    {
        public kuchenDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<kuchenDbContext>();
            builder.UseMySql("server=localhost;database=kuchen;user=root;password=Dongyanwei;");
            return new kuchenDbContext(builder.Options);

            //throw new System.NotImplementedException();
        }
    }
}
