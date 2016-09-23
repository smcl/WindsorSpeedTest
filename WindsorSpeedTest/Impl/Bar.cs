using WindsorSpeedTest.Api;

namespace WindsorSpeedTest.Impl
{
    class Bar : IBar
    {
        public IFoo Foo { get; set; }

        public Bar(IFoo foo)
        {
            Foo = foo;
        }
    }
}
