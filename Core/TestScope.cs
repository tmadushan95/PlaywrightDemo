using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;

namespace PlaywrightDemo.Core
{
    public sealed class TestScope : IAsyncDisposable
    {
        private readonly IServiceScope _scope;
        public IServiceProvider Services => _scope.ServiceProvider;

        public TestScope(IServiceProvider rootProvider)
        {
            _scope = rootProvider.CreateScope();
        }

        public ValueTask DisposeAsync()
        {
            _scope.Dispose();
            return ValueTask.CompletedTask;
        }
    }

}
