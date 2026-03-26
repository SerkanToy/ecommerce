
using Microsoft.Extensions.DependencyInjection;

namespace ecommerce.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            //service.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            return service;
        }
    }
}
