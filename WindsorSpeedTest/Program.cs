using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindsorSpeedTest.Api;
using WindsorSpeedTest.Impl;

namespace WindsorSpeedTest
{
    class Program
    {
        private const int NumberOfTestAllocations = 100000;

        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new WindsorSpeedTestInstaller());

            Console.Out.WriteLine("Foo:");
            var fooResult = TestFoo(container);
            Console.Out.WriteLine(fooResult.ToString());

            Console.Out.WriteLine("Baf:");
            var bafResult = TestFoo(container);
            Console.Out.WriteLine(bafResult.ToString());
        }

        static BenchmarkResult TestFoo(IWindsorContainer container)
        {
            var swNew = new Stopwatch();
            var swCastle = new Stopwatch();

            var fooListNew = new List<IFoo>();
            var fooListCastle = new List<IFoo>();

            swNew.Start();
            for (int i = 0; i < NumberOfTestAllocations; i++)
            {
                fooListNew.Add(new Foo());
            }
            swNew.Stop();

            swCastle.Start();
            for (int i = 0; i < NumberOfTestAllocations; i++)
            {
                fooListCastle.Add(container.Resolve<IFoo>());
            }
            swCastle.Stop();

            return new BenchmarkResult { NewMilliseconds = swNew.ElapsedMilliseconds, CastleMilliseconds = swCastle.ElapsedMilliseconds };
        }

        static BenchmarkResult TestBaf(IWindsorContainer container)
        {
            var swNew = new Stopwatch();
            var swCastle = new Stopwatch();

            var bafListNew = new List<IBaf>();
            var bafListCastle = new List<IBaf>();

            swNew.Start();
            for (int i = 0; i < NumberOfTestAllocations; i++)
            {
                bafListNew.Add(new Baf(new Bar(new Foo())));
            }
            swNew.Stop();

            swCastle.Start();
            for (int i = 0; i < NumberOfTestAllocations; i++)
            {
                bafListCastle.Add(container.Resolve<IBaf>());
            }
            swCastle.Stop();

            return new BenchmarkResult { NewMilliseconds = swNew.ElapsedMilliseconds, CastleMilliseconds = swCastle.ElapsedMilliseconds };
        }
    }
}
