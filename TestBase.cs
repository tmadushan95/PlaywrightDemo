using PlaywrightDemo.Core;

namespace PlaywrightDemo
{
    public abstract class TestBase(PlaywrightFixture _fixture) :
        IClassFixture<PlaywrightFixture>,
        IAsyncLifetime
    {
        protected IServiceProvider Root { get; private set; } = null!;
        protected TestScope Scope = null!;

        public virtual Task InitializeAsync()
        {
            Root = ServiceFactory.CreateRoot(_fixture);
            Scope = new TestScope(Root);
            return Task.CompletedTask;
        }

        public async Task DisposeAsync()
        {
            await Scope.DisposeAsync();
        }
    }
}
