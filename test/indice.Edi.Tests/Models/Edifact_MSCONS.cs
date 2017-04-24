#region Using

using System.Collections.Generic;

using indice.Edi.Serialization;

#endregion
namespace indice.Edi.Tests.Models
{
    [EdiPath("COM[0][0]"), EdiSegment]
    public class MSCONS_COM
    {
        [EdiValue("X(255)", Path = "COM/0/0")]
        public string ID {
            get; set;
        }

        [EdiValue("X(3)", Path = "COM/0/1")]
        public string Code {
            get; set;
        }
    }

    [EdiPath("DTM[0][0]"), EdiSegment]
    public class MSCONS_DTM
    {
        [EdiValue("X(3)", Path = "DTM/0/0")]
        public string Code {
            get; set;
        }

        [EdiValue("X(35)", Path = "DTM/0/1")]
        public string Datum {
            get; set;
        }

        [EdiValue("X(3)", Path = "DTM/0/2")]
        public string Format {
            get; set;
        }
    }

    public class MSCONS
    {
        public ORDRSP_UNB Dokument_Kopfsegment { get; set; }

        public List<MSCONS_Nachricht> ListNachricht {
            get; set;
        }

        public ORDRSP_UNZ Dokument_Endsegment { get; set; }
    }

    [EdiMessage]
    public class MSCONS_Nachricht
    {
        public MSCONS_UNH Nachrichten_Kopfsegment {
            get; set;
        }

        [EdiValue("X(3)", Path = "BGM/0/0")]
        public string Dokumentenname {
            get; set;
        }

        [EdiValue("X(70)", Path = "BGM/1/0")]
        public string Dokumentennummer {
            get; set;
        }

        [EdiValue("X(3)", Path = "BGM/2/0")]
        public string Nachrichtenfunktion {
            get; set;
        }

        [EdiCondition("137", Path = "DTM[0][0]")]
        public MSCONS_DTM Nachrichtendatum {
            get; set;
        }

        [EdiCondition("AGI", Path = "RFF[0][0]"), EdiCondition("ACW", Path = "RFF[0][0]")]
        public MSCONS_SG1 Referenzangaben {
            get; set;
        }

        [EdiCondition("Z13", Path = "RFF[0][0]")]
        public MSCONS_SG1 Pruefidentifikator {
            get; set;
        }

        [EdiCondition("MR", Path = "NAD[0][0]")]
        public MSCONS_SG2 Empfaenger {
            get; set;
        }

        [EdiCondition("MS", Path = "NAD[0][0]")]
        public MSCONS_SG2 Absender {
            get; set;
        }

        [EdiCondition("DP", Path = "NAD/0/0")]
        public MSCONS_SG5 Lieferanschrift { get; set; }

        public MSCONS_UNT Nachrichten_Endsegment {
            get; set;
        }
    }

    [EdiPath("UNT"), EdiSegment]
    public class MSCONS_UNT
    {
        [EdiValue("9(6)", Path = "UNT/0/0")]
        public int Anzahl_der_Segmente {
            get; set;
        }

        [EdiValue("X(14)", Path = "UNT/1/0")]
        public string Referenznummer {
            get; set;
        }
    }

    [EdiSegmentGroup("NAD", SequenceEnd = "UNT")]
    public class MSCONS_SG5
    {
        [EdiValue("X(3)", Path = "NAD/0/0")]
        public string Qualifier { get; set; }

        [EdiCondition("237", Path = "LOC[0][0]")]
        public MSCONS_SG6 Bilanzkreis { get; set; }

        [EdiCondition("172", Path = "LOC[0][0]")]
        public MSCONS_SG6 Zaehlpunkt { get; set; }

        [EdiCondition("Z04", Path = "LOC[0][0]")]
        public MSCONS_SG6 Profilbezeichnung { get; set; }

        [EdiCondition("107", Path = "LOC[0][0]")]
        public MSCONS_SG6 Bilanzierungsgebiet { get; set; }

        [EdiCondition("Z06", Path = "LOC[0][0]")]
        public MSCONS_SG6 Profilschar { get; set; }
    }

    [EdiSegmentGroup("LOC")]
    public class MSCONS_SG6
    {
        [EdiValue("X(3)", Path = "LOC/0/0")]
        public string Code {
            get; set;
        }

        [EdiValue("X(35)", Path = "LOC/1/0")]
        public string ID {
            get; set;
        }

        [EdiValue("X(25)", Path = "LOC/2/0")]
        public string Zugehoeriger_Ort {
            get; set;
        }

        [EdiCondition("163", Path = "DTM[0][0]")]
        public MSCONS_DTM Beginn_Messperiode {
            get; set;
        }

        [EdiCondition("164", Path = "DTM[0][0]")]
        public MSCONS_DTM Ende_Messperiode {
            get; set;
        }

        [EdiCondition("492", Path = "DTM[0][0]")]
        public MSCONS_DTM Bilanzierungsmonat {
            get; set;
        }

        [EdiCondition("293", Path = "DTM[0][0]")]
        public MSCONS_DTM Fertigstellungsdatum {
            get; set;
        }

        [EdiCondition("157", Path = "DTM[0][0]")]
        public MSCONS_DTM Beginndatum_Profilschar {
            get; set;
        }

        [EdiCondition("9", Path = "DTM[0][0]")]
        public MSCONS_DTM Erfassungsdatum {
            get; set;
        }

        [EdiCondition("MG", Path = "RFF[0][0]")]
        public MSCONS_SG7 Geraetenr {
            get; set;
        }

        [EdiCondition("ACH", Path = "CCI[0][0]")]
        public MSCONS_SG8 Ablesegrund {
            get; set;
        }

        [EdiCondition("16", Path = "CCI[0][0]")]
        public MSCONS_SG8 Erfassungshinweis {
            get; set;
        }

        [EdiCondition("15", Path = "CCI[0][0]")]
        public MSCONS_SG8 Zeitreihentyp {
            get; set;
        }

        public List<MSCONS_SG9> ListPositions {
            get; set;
        }
    }

    [EdiSegmentGroup("LIN")]
    //[EdiPath("LIN"), EdiSegment]
    public class MSCONS_SG9
    {
        [EdiValue("X(6)", Path = "LIN/0/0")]
        public string Positionsnummer {
            get; set;
        }

        public List<MSCONS_SG10> Mengenangaben {
            get; set;
        }

        [EdiCondition("MG", Path = "RFF[0][0]")]
        public MSCONS_SG7 Geraetenummer {
            get; set;
        }

        [EdiCondition("5", Path = "PIA[0][0]")]
        public MSCONS_PIA OBIS {
            get; set;
        }

    }

    [EdiPath("PIA[0][0]"), EdiSegment]
    public class MSCONS_PIA
    {
        [EdiValue("X(3)", Path = "PIA/0/0")]
        public string Qualifier {
            get; set;

        }

        [EdiValue("X(35)", Path = "PIA/1/0")]
        public string OBIS_Kennzahl {
            get; set;
        }

        [EdiValue("X(3)", Path = "PIA/1/1")]
        public string Code {
            get; set;
        }
    }

    //[EdiPath("QTY[0][0]"), EdiSegment]
    [EdiSegmentGroup("QTY")]
    public class MSCONS_SG10
    {
        [EdiValue("X(3)", Path = "QTY/0/0")]
        public string Qualifier {
            get; set;
        }

        [EdiValue("X(35)", Path = "QTY/0/1")]
        public string Menge {
            get; set;
        }

        [EdiCondition("163", Path = "DTM[0][0]")]
        public MSCONS_DTM Beginn_Messperiode {
            get; set;
        }

        [EdiCondition("164", Path = "DTM[0][0]")]
        public MSCONS_DTM Ende_Messperiode {
            get; set;
        }

        [EdiCondition("9", Path = "DTM[0][0]")]
        public MSCONS_DTM Ablesedatum {
            get; set;
        }

        [EdiCondition("306", Path = "DTM[0][0]")]
        public MSCONS_DTM Leistungsperiode {
            get; set;
        }

        public MSCONS_STS Statuszusatzinformation {
            get; set;
        }
    }

    [EdiPath("RFF[0][0]"), EdiSegment]
    public class MSCONS_SG7
    {
        [EdiValue("X(3)", Path = "RFF/0/0")]
        public string Code {
            get; set;
        }

        [EdiValue("X(70)", Path = "RFF/0/1")]
        public string ID {
            get; set;
        }
    }

    [EdiPath("CCI[0][0]"), EdiSegment]
    public class MSCONS_SG8
    {
        [EdiValue("X(3)", Path = "CCI/0/0")]
        public string Qualifier {
            get; set;
        }

        [EdiValue("X(17)", Path = "CCI/2/0")]
        public string Merkmal {
            get; set;
        }
    }

    [EdiPath("STS[0][0]"), EdiSegment]
    public class MSCONS_STS
    {
        [EdiValue("X(3)", Path = "STS/0/0")]
        public string Kategorie {
            get; set;
        }

        [EdiValue("X(3)", Path = "STS/1/0")]
        public string Tarif {
            get; set;
        }

        [EdiValue("X(17)", Path = "STS/1/1")]
        public string Codeliste {
            get; set;
        }

        [EdiValue("X(3)", Path = "STS/2/0")]
        public string Statusanlass {
            get; set;
        }
    }

    [EdiSegment, EdiPath("UNH")]
    public class MSCONS_UNH
    {
        [EdiValue("X(70)", Path = "UNH/0/0")]
        public string Referenznr { get; set; }

        [EdiValue("X(6)", Path = "UNH/1/0")]
        public string Nachrichtentyp { get; set; }

        [EdiValue("X(3)", Path = "UNH/1/1")]
        public string VersionTyp { get; set; }

        [EdiValue("X(3)", Path = "UNH/1/2")]
        public string Freigabenr { get; set; }

        [EdiValue("X(2)", Path = "UNH/1/3")]
        public string Verwaltende_Organisation { get; set; }

        [EdiValue("X(6)", Path = "UNH/1/4")]
        public string Versionnr { get; set; }


        [EdiValue("X(35)", Path = "UNH/2/0")]
        public string Allgemeine_Zuordnungsref {
            get; set;
        }

        [EdiValue("9(2)", Path = "UNH/3/0")]
        public int Uebermittlungsfolgenr {
            get; set;
        }

        [EdiValue("X(1)", Path = "UNH/3/1")]
        public string Erste_Und_Letzte {
            get; set;
        }
    }

    //[EdiSegmentGroup("RFF[0][0]", SequenceEnd = "NAD")]
    [EdiSegment]
    [EdiPath("RFF/0")]
    public class MSCONS_SG1
    {
        [EdiValue("X(3)", Path = "RFF/0/0")]
        public string Code {
            get; set;
        }

        [EdiValue("X(70)", Path = "RFF/0/1")]
        public string ID {
            get; set;
        }
    }

    [EdiSegmentGroup("NAD[0][0]", SequenceEnd = "UNS")]
    //[EdiSegment]
    //[EdiPath("NAD/0")]
    public class MSCONS_SG2
    {
        [EdiValue("X(3)", Path = "NAD/0/0")]
        public string Code {
            get; set;
        }

        [EdiValue("X(35)", Path = "NAD/1/0")]
        public string ID {
            get; set;
        }

        [EdiValue("X(3)", Path = "NAD/1/2")]
        public string Codeliste {
            get; set;
        }

        public SG4 CTA { get; set; }
    }

    //[EdiSegmentGroup("CTA[0][0]")]
    [EdiSegment]
    [EdiPath("CTA/0")]
    public class SG4
    {
        [EdiValue("X(3)", Path = "CTA/0/0")]
        public string Funktion {
            get; set;
        }

        [EdiValue("X(17)", Path = "CTA/1/0")]
        public string Kontaktnummer {
            get; set;
        }

        [EdiValue("X(0)", Path = "CTA/1/1")]
        public string Kontakt {
            get; set;
        }

        [EdiCondition("EM", Path = "COM[0][1]")]
        public MSCONS_COM Elektronische_Post {
            get; set;
        }

        [EdiCondition("FX", Path = "COM[0][1]")]
        public MSCONS_COM Telefax {
            get; set;
        }

        [EdiCondition("TE", Path = "COM[0][1]")]
        public MSCONS_COM Telefon {
            get; set;
        }

        [EdiCondition("AJ", Path = "COM[0][1]")]
        public MSCONS_COM Weiteres_Telefon {
            get; set;
        }

        [EdiCondition("AL", Path = "COM[0][1]")]
        public MSCONS_COM Handy {
            get; set;
        }
    }
}


