using WindsorSpeedTest.Api;

namespace WindsorSpeedTest.Impl
{
    class Baf : IBaf
    {
        public IBar Bar { get; set; }

        public Baf(IBar bar)
        {
            Bar = bar;
        }
    }
}
