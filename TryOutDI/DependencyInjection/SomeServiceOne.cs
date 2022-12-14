using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOutDI.DependencyInjection
{
    public class SomeServiceOne : ISomeService
    {
        //private readonly Guid RandomGuid = Guid.NewGuid();

        private readonly IRandomGuidProvider _randomGuidProvider;

        public SomeServiceOne(IRandomGuidProvider randomGuidProvider)
        {
            _randomGuidProvider = randomGuidProvider;
        }

        public void PrintSomething()
        {
            //Console.Write(RandomGuid);
            Console.WriteLine(_randomGuidProvider.RandomGuid);
        }
    }
}
