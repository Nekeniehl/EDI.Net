using System.IO;
using System.Linq;
using indice.Edi.Tests.Models;

using Xunit;

namespace indice.Edi.Tests
{
    public class Edifact_MSCONSTests
    {
        [Fact]
        public void MSCONSTest() {
            if (EdiStructureType.None < EdiStructureType.Segment) {
            }
            var grammar = EdiGrammar.NewEdiFact();
            var interchange = default(MSCONS);

            using (var stream = Helpers.GetResourceStream("mscons.edi")) {
                interchange = new EdiSerializer().Deserialize<MSCONS>(new StreamReader(stream), grammar);

                Assert.NotNull(interchange.ListNachricht.First().Nachrichten_Endsegment);

                //Assert.NotNull(interchange.ListNachricht.First().Absender.CTA.EM);
                //Assert.NotNull(interchange.ListNachricht.First().Absender.CTA.EM.Art);

            }
        }

    }
}
