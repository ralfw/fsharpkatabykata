using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Csharp_Bibliothek_mit_Unit_Tests
{
    [TestFixture]
    public class NUnitTest
    {
        [Test]
        public void Hello_World()
        {
            var _ = Begrüßung.Hallo_sagen;
        }

        [Test]
        public void Hello_World2()
        {
            Begrüßung.Hallo_ohne_Rückgabe();
        }
    }
}
