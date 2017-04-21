#region Using

using System.Collections.Generic;

using indice.Edi.Serialization;

#endregion

namespace indice.Edi.Tests.Models
{

    [EdiPath("COM[0][0]"), EdiSegment]
    public class ORDRSP_COM
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

    [EdiSegmentGroup("CUX[0][0]", SequenceEnd = "LIN[0][0]")]
    public class ORDRSP_CUX
    {
        [EdiValue("X(3)", Path = "CUX/0/0")]
        public string Waehrungsangaben {
            get; set;
        }

        [EdiValue("X(3)", Path = "CUX/0/1")]
        public string Code {
            get; set;
        }

        [EdiValue("X(3)", Path = "CUX/0/2")]
        public string Qualifier {
            get; set;
        }
    }

    [EdiPath("DTM[0][0]"), EdiSegment]
    public class ORDRSP_DTM
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

    [EdiPath("FTX[0][0]"), EdiSegment]
    public class ORDRSP_FTX
    {
        [EdiValue("X(3)", Path = "FTX/0/0")]
        public string Qualifier {
            get; set;
        }

        [EdiValue("X(35)", Path = "FTX/3/0")]
        public string Text1 {
            get; set;
        }

        [EdiValue("X(35)", Path = "FTX/3/1")]
        public string Text2 {
            get; set;
        }

        [EdiValue("X(35)", Path = "FTX/3/2")]
        public string Text3 {
            get; set;
        }

        [EdiValue("X(35)", Path = "FTX/3/3")]
        public string Text4 {
            get; set;
        }

        [EdiValue("X(35)", Path = "FTX/3/4")]
        public string Text5 {
            get; set;
        }
    }

    [EdiPath("IMD[0][0]"), EdiSegment]
    public class ORDRSP_IMD
    {
        [EdiValue("X(3)", Path = "IMD/0/0")]
        public string Beschreibungsformat {
            get; set;
        }

        [EdiValue("X(3)", Path = "IMD/1/0")]
        public string Produkt {
            get; set;
        }

        [EdiValue("X(3)", Path = "IMD/2/0")]
        public string Code {
            get; set;
        }
    }

    [EdiPath("LOC[0][0]"), EdiSegment]
    public class ORDRSP_LOC
    {
        [EdiValue("X(3)", Path = "LOC/0/0")]
        public string Code {
            get; set;
        }

        [EdiValue("X(35)", Path = "LOC/1/0")]
        public string ID {
            get; set;
        }
    }

    [EdiPath("MOA[0][0]"), EdiSegment]
    public class ORDRSP_MOA
    {
        [EdiValue("X(3)", Path = "MOA/0/0")]
        public string Qualifier {
            get; set;
        }

        [EdiValue("X(35)", Path = "MOA/0/1")]
        public string Geldbetrag {
            get; set;
        }
    }

    [EdiMessage]
    public class ORDRSP_Nachricht
    {
        public ORDRSP_UNH Nachrichten_Kopfsegment {
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

        [EdiCondition("137", Path = "DTM[0][0]")]
        public ORDRSP_DTM Nachrichtendatum {
            get; set;
        }

        [EdiCondition("203", Path = "DTM[0][0]")]
        public ORDRSP_DTM Ausführungsdatum {
            get; set;
        }

        [EdiCondition("Z02", Path = "DTM[0][0]")]
        public ORDRSP_DTM Verschobener_Abmeldetermin {
            get; set;
        }

        [EdiCondition("Z02", Path = "IMD[1][0]"), EdiCondition("Z01", Path = "IMD[1][0]")]
        public ORDRSP_IMD Abonnement {
            get; set;
        }

        [EdiCondition("Z11", Path = "IMD[1][0]"), EdiCondition("Z08", Path = "IMD[1][0]"), EdiCondition("Z10", Path = "IMD[1][0]"), EdiCondition("Z12", Path = "IMD[1][0]"), EdiCondition("Z13", Path = "IMD[1][0]"), EdiCondition("Z07", Path = "IMD[1][0]")]
        public ORDRSP_IMD Leistungsbeschreibung {
            get; set;
        }

        [EdiCondition("ON", Path = "RFF[0][0]")]
        public ORDRSP_SG1 Referenz_der_Anfrage {
            get; set;
        }

        [EdiCondition("Z13", Path = "RFF[0][0]")]
        public ORDRSP_SG1 Pruefidentifikator {
            get; set;
        }

        public ORDRSP_SG2 Antwortkategorie {
            get; set;
        }

        [EdiCondition("MR", Path = "NAD[0][0]")]
        public ORDRSP_SG3 Empfaenger {
            get; set;
        }

        [EdiCondition("MS", Path = "NAD[0][0]")]
        public ORDRSP_SG3 Absender {
            get; set;
        }

        [EdiCondition("DP", Path = "NAD[0][0]")]
        public ORDRSP_SG3 Lieferanschrift {
            get; set;
        }

        [EdiCondition("2", Path = "CUX[0][0]")]
        public ORDRSP_SG8 Waehrungsangaben {
            get; set;
        }

        public List<ORDRSP_SG27> ListPositionsdaten {
            get; set;
        }

        [EdiCondition("24", Path = "MOA[0][0]")]
        public ORDRSP_MOA Netto_Summenbetrag {
            get; set;
        }

        public ORDRSP_UNT Nachrichten_Endsegment {
            get; set;
        }
    }

    public class ORDRSP
    {
        public ORDRSP_UNB Dokument_Kopfsegment { get; set; }

        public List<ORDRSP_Nachricht> ListNachricht {
            get; set;
        }

        public ORDRSP_UNZ Dokument_Endsegment { get; set; }
    }

    [EdiPath("UNZ"), EdiSegment]
    public class ORDRSP_UNZ
    {
        [EdiValue("9(6)", Path = "UNZ/0/0")]
        public int Anzahl_der_Segmente {
            get; set;
        }

        [EdiValue("X(14)", Path = "UNZ/1/0")]
        public string Referenznummer {
            get; set;
        }

    }

    [EdiPath("QTY[0][0]"), EdiSegment]
    public class ORDRSP_QTY
    {
        [EdiValue("X(3)", Path = "QTY/0/0")]
        public string Qualifier {
            get; set;
        }

        [EdiValue("X(35)", Path = "QTY/0/1")]
        public string Menge {
            get; set;
        }

        [EdiValue("X(8)", Path = "QTY/0/2")]
        public string Code {
            get; set;
        }
    }

    [EdiSegmentGroup("RFF[0][0]", SequenceEnd = "AJT[0][0]")]
    public class ORDRSP_SG1
    {
        [EdiValue("X(70)", Path = "RFF/0/0")]
        public string ID {
            get; set;
        }

        [EdiValue("X(3)", Path = "RFF/0/1")]
        public string Code {
            get; set;
        }

        public DTM Referenz_Datum {
            get; set;
        }
    }

    [EdiSegmentGroup("AJT[0][0]", SequenceEnd = "NAD[0][0]")]
    public class ORDRSP_SG2
    {
        [EdiValue("X(3)", Path = "AJT/0/0")]
        public string Code {
            get; set;
        }
    }

    [EdiSegmentGroup("LIN[0][0]", SequenceEnd = "UNS[0][0]")]
    public class ORDRSP_SG27
    {
        [EdiValue("X(6)", Path = "LIN/0/0")]
        public string Positionsnummer {
            get; set;
        }

        [EdiValue("X(35)", Path = "LIN/2/0")]
        public string Leistungsnummer {
            get; set;
        }

        [EdiValue("X(3)", Path = "LIN/2/1")]
        public string Code {
            get; set;
        }

        [EdiCondition("145", Path = "QTY[0][0]")]
        public ORDRSP_QTY Menge {
            get; set;
        }

        [EdiCondition("203", Path = "MOA[0][0]")]
        public ORDRSP_MOA Positionsnettobetrag {
            get; set;
        }

        [EdiCondition("ACB", Path = "FTX[0][0]")]
        public FTX Allgemeine_Information {
            get; set;
        }

        [EdiCondition("CAL", Path = "PRI[0][0]")]
        public ORDRSP_SG31 Preisangaben {
            get; set;
        }

        [EdiCondition("Z09", Path = "RFF[0][0]")]
        public ORDRSP_SG32 Geraetenummer {
            get; set;
        }

        [EdiCondition("Z06", Path = "RFF[0][0]")]
        public ORDRSP_SG32 Positionsnummer_der_Bestellung {
            get; set;
        }
    }

    [EdiSegmentGroup("NAD[0][0]", SequenceEnd = "CUX[0][0]")]
    public class ORDRSP_SG3
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

        public ORDRSP_LOC LOC {
            get; set;
        }

        public ORDRSP_SG6 CTA {
            get; set;
        }
    }

    [EdiPath("PRI[0][0]"), EdiSegment]
    public class ORDRSP_SG31
    {
        [EdiValue("X(3)", Path = "PRI/0/0")]
        public string Qualifier {
            get; set;
        }

        [EdiValue("X(15)", Path = "PRI/0/1")]
        public string Betrag {
            get; set;
        }
    }

    [EdiPath("RFF[0][0]"), EdiSegment]
    public class ORDRSP_SG32
    {
        [EdiValue("X(3)", Path = "RFF/0/0")]
        public string Qualifier {
            get; set;
        }

        [EdiValue("X(70)", Path = "RFF/0/1")]
        public string Identifikation {
            get; set;
        }
    }

    [EdiSegmentGroup("CTA[0][0]")]
    public class ORDRSP_SG6
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
        public ORDRSP_COM Elektronische_Post {
            get; set;
        }

        [EdiCondition("FX", Path = "COM[0][1]")]
        public ORDRSP_COM Telefax {
            get; set;
        }

        [EdiCondition("TE", Path = "COM[0][1]")]
        public ORDRSP_COM Telefon {
            get; set;
        }

        [EdiCondition("AJ", Path = "COM[0][1]")]
        public ORDRSP_COM Weiteres_Telefon {
            get; set;
        }

        [EdiCondition("AL", Path = "COM[0][1]")]
        public ORDRSP_COM Handy {
            get; set;
        }
    }

    [EdiSegmentGroup("CUX[0][0]", SequenceEnd = "LIN[0][0]")]
    public class ORDRSP_SG8
    {
        [EdiValue("X(3)", Path = "CUX/0/0")]
        public string Waehrungsangaben {
            get; set;
        }

        [EdiValue("X(3)", Path = "CUX/0/1")]
        public string Code {
            get; set;
        }

        [EdiValue("X(3)", Path = "CUX/0/2")]
        public string Qualifier {
            get; set;
        }
    }

    [EdiPath("UNT"), EdiSegment]
    public class ORDRSP_UNT
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

    [EdiPath("UNB")]
    [EdiSegment]
    public class ORDRSP_UNB
    {
        #region Properties

        public ORDRSP_Absender Absender { get; set; }

        [EdiValue("X(14)", Path = "UNB/5")]
        public string Anwendungsreferenz { get; set; }

        [EdiValue("X(14)", Path = "UNB/4")]
        public string Datenaustauschreferenz { get; set; }

        public ORDRSP_Empfaenger Empfaenger { get; set; }

        public ORDRSP_Erstellungsdatum Erstellungsdatum { get; set; }

        public ORDRSP_Syntax_Bezeichner SyntaxBezeichner { get; set; }

        #endregion Properties
    }

    [EdiPath("UNH")]
    [EdiSegment]
    public class ORDRSP_UNH
    {
        #region Properties

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

        #endregion Properties
    }

    [EdiElement]
    [EdiPath("UNB/1")]
    public class ORDRSP_Absender
    {
        #region Properties

        [EdiValue("X(35)", Path = "UNB/1/0")]
        public string ID { get; set; }

        [EdiValue("X(4)", Path = "UNB/1/1")]
        public string Qualifier { get; set; }

        #endregion Properties
    }

    [EdiElement]
    [EdiPath("UNB/2")]
    public class ORDRSP_Empfaenger
    {
        #region Properties

        [EdiValue("X(35)", Path = "UNB/2/0")]
        public string ID { get; set; }

        [EdiValue("X(4)", Path = "UNB/2/1")]
        public string Qualifier { get; set; }

        #endregion Properties
    }

    [EdiElement]
    [EdiPath("UNB/3")]
    public class ORDRSP_Erstellungsdatum
    {
        #region Properties

        [EdiValue("X(6)", Path = "UNB/3/0")]
        public string Datum { get; set; }

        [EdiValue("X(4)", Path = "UNB/3/1")]
        public string Zeit { get; set; }

        #endregion Properties
    }

    [EdiElement]
    [EdiPath("UNB/0")]
    public class ORDRSP_Syntax_Bezeichner
    {
        #region Properties

        [EdiValue("X(4)", Path = "UNB/0/0")]
        public string Syntax_Kennung { get; set; }

        [EdiValue("9(1)", Path = "UNB/0/1")]
        public int Syntax_Versionnr { get; set; }

        #endregion Properties
    }
}