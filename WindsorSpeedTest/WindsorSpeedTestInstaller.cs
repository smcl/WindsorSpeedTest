using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WindsorSpeedTest.Api;
using WindsorSpeedTest.Impl;

namespace WindsorSpeedTest
{
    class WindsorSpeedTestInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFoo>()
                .ImplementedBy<Foo>()
                .LifeStyle.Transient);

            container.Register(Component.For<IBar>()
                .ImplementedBy<Bar>()
                .LifeStyle.Transient);

            container.Register(Component.For<IBaf>()
                .ImplementedBy<Baf>()
                .LifeStyle.Transient);
        }
    }
}
