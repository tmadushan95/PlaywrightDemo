using PlaywrightDemo.Core;

namespace PlaywrightDemo
{
    public abstract class TestBase :
        IClassFixture<PlaywrightFixture>,
        IAsyncLifetime
    {
        private readonly PlaywrightFixture _fixture;
        protected IServiceProvider Root { get; private set; } = null!;
        protected TestScope Scope = null!;

        protected TestBase(PlaywrightFixture fixture)
        {
            _fixture = fixture;
        }

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
