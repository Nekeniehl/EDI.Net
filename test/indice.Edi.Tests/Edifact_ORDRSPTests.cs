﻿using System.IO;

using indice.Edi.Tests.Models;

using Xunit;

namespace indice.Edi.Tests
{
    public class Edifact_ORDRSPTests
    {
        [Fact]
        [Trait(Traits.Tag, "EDIFact")]
        [Trait(Traits.Issue, "#34")]
        public void ReferenceSegment() {
            var grammar = EdiGrammar.NewEdiFact();
            var interchange = default(ORDRSP);

            using (var stream = Helpers.GetResourceStream("edifact.ORDRSP.edi")) {
                interchange = new EdiSerializer().Deserialize<ORDRSP>(new StreamReader(stream), grammar);
            }


        }

        [Fact]
        public void IMDSegmentsWithConditions() {
            var grammar = EdiGrammar.NewEdiFact();
            var interchange = default(ORDRSP);

            using (var stream = Helpers.GetResourceStream("edifact.ORDRSP.edi")) {
                interchange = new EdiSerializer().Deserialize<ORDRSP>(new StreamReader(stream), grammar);

                //interchange.ListNachricht.First().
                //Assert.NotNull(interchange.ListNachricht.First().Absender.CTA.EM);
                //Assert.NotNull(interchange.ListNachricht.First().Absender.CTA.EM.Art);
            }
        }

        [Fact]
        public void COMSegments() {
            if (EdiStructureType.None < EdiStructureType.Segment) {
            }
            var grammar = EdiGrammar.NewEdiFact();
            var interchange = default(ORDRSP);

            using (var stream = Helpers.GetResourceStream("edifact.ORDRSP.edi")) {
                interchange = new EdiSerializer().Deserialize<ORDRSP>(new StreamReader(stream), grammar);

                //Assert.NotNull(interchange.ListNachricht.First().Absender.CTA.EM);
                //Assert.NotNull(interchange.ListNachricht.First().Absender.CTA.EM.Art);
            }
        }

    }
}
