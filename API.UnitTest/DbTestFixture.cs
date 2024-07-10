using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API.Mapping;

namespace API.UnitTest
{
    public class DbTestFixture<TContext> : IDisposable where TContext : DbContext
    {
        public TContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public DbTestFixture()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<TContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            Context = (TContext)Activator.CreateInstance(typeof(TContext), options);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GeneralProfile());
                mc.AddProfile(new PersonasProfile());
            });
            Mapper = mappingConfig.CreateMapper();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
