using CluedIn.Core.Data;
using CluedIn.Core.Data.Vocabularies;

namespace CluedIn.Crawling.Geometic.Vocabularies
{
    public class MetadataVocabulary : SimpleVocabulary
    {
        public MetadataVocabulary()
        {
            VocabularyName = "Geometic Metadata"; // TODO: Set value
            KeyPrefix = "geometic.metadata"; // TODO: Set value
            KeySeparator = ".";
            Grouping = EntityType.Unknown; // TODO: Set value

            AddGroup("Metadata Details", group =>
            {
                FHANUM = group.Add(new VocabularyKey("FHANUM", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("FHANUM"));
                KUNLOEB = group.Add(new VocabularyKey("KUNLOEB", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("KUNLOEB"));
                NAVN = group.Add(new VocabularyKey("NAVN", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("NAVN"));
                ADRESSE = group.Add(new VocabularyKey("ADRESSE", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("ADRESSE"));
                ADRESSE2 = group.Add(new VocabularyKey("ADRESSE2", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("ADRESSE 2"));
                POSTBY = group.Add(new VocabularyKey("POSTBY", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("POSTBY"));
                KUNTLF = group.Add(new VocabularyKey("KUNTLF", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("KUNTLF"));
                CPRNUM = group.Add(new VocabularyKey("CPRNUM", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("CPRNUM"));
                CPRNUM2 = group.Add(new VocabularyKey("CPRNUM2", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("CPRNUM 2"));
                CVRNUM = group.Add(new VocabularyKey("CVRNUM", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("CVRNUM"));
                OutputName = group.Add(new VocabularyKey("OutputName", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Name"));
                OutputNameFirst = group.Add(new VocabularyKey("OutputNameFirst", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Name First"));
                OutputNameLast = group.Add(new VocabularyKey("OutputNameLast", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Name Last"));
                OutputKvhx = group.Add(new VocabularyKey("OutputKvhx", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Kvhx"));
                OutputCareof = group.Add(new VocabularyKey("OutputCareof", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Careof"));
                OutputLokalitet = group.Add(new VocabularyKey("OutputLokalitet", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Lokalitet"));
                OutputStreetline = group.Add(new VocabularyKey("OutputStreetline", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Streetline"));
                OutputStednavn = group.Add(new VocabularyKey("OutputStednavn", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Stednavn"));
                OutputPcode = group.Add(new VocabularyKey("OutputPcode", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Pcode"));
                OutputPdistname = group.Add(new VocabularyKey("OutputPdistname", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Pdistname"));
                OutputStrname = group.Add(new VocabularyKey("OutputStrname", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Strname"));
                OutputHounoNum = group.Add(new VocabularyKey("OutputHounoNum", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Houno Num"));
                OutputHounoAlpha = group.Add(new VocabularyKey("OutputHounoAlpha", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Houno Alpha"));
                OutputFloor = group.Add(new VocabularyKey("OutputFloor", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Floor"));
                OutputSuite = group.Add(new VocabularyKey("OutputSuite", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Suite"));
                Mobile = group.Add(new VocabularyKey("Mobile", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Mobile"));
                Landline = group.Add(new VocabularyKey("Landline", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Landline"));
                InputKvhx = group.Add(new VocabularyKey("InputKvhx", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Input Kvhx"));
                InputUnadrMatchlvlDetail = group.Add(new VocabularyKey("InputUnadrMatchlvlDetail", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Input Unadr Matchlvl Detail"));
                PartnerRemoved = group.Add(new VocabularyKey("PartnerRemoved", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Partner Removed"));
                OutputAddressOrigin = group.Add(new VocabularyKey("OutputAddressOrigin", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Address Origin"));
                OutputNameOrigin = group.Add(new VocabularyKey("OutputNameOrigin", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Output Name Origin"));
                AddressChange = group.Add(new VocabularyKey("AddressChange", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Address Change"));
                Duplicate = group.Add(new VocabularyKey("Duplicate", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Duplicate"));
                DuplicateId = group.Add(new VocabularyKey("DuplicateId", VocabularyKeyDataType.Text, VocabularyKeyVisibility.HiddenInFrontendUI).WithDisplayName("Duplicate Id"));
                Per1PnrValidation = group.Add(new VocabularyKey("Per1PnrValidation", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Pnr Validation"));
                Per2PnrValidation = group.Add(new VocabularyKey("Per2PnrValidation", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Pnr Validation"));
                Per1InputName = group.Add(new VocabularyKey("Per1InputName", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Input Name"));
                Per1CprMatch = group.Add(new VocabularyKey("Per1CprMatch", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Cpr Match"));
                Per1CprStatus = group.Add(new VocabularyKey("Per1CprStatus", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Cpr Status"));
                Per1Protect = group.Add(new VocabularyKey("Per1Protect", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Protect"));
                Per1AdvptectRobinson = group.Add(new VocabularyKey("Per1AdvptectRobinson", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Advptect Robinson"));
                Per1AdvptectRobinsonDate = group.Add(new VocabularyKey("Per1AdvptectRobinsonDate", VocabularyKeyDataType.DateTime, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Advptect Robinson Date"));
                Per1Movdat = group.Add(new VocabularyKey("Per1Movdat", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Movdat"));
                Per1NameFirsts = group.Add(new VocabularyKey("Per1NameFirsts", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Name Firsts"));
                Per1NameLast = group.Add(new VocabularyKey("Per1NameLast", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Name Last"));
                Per1NameAdr = group.Add(new VocabularyKey("Per1NameAdr", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Name Adr"));
                Per1Careof = group.Add(new VocabularyKey("Per1Careof", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Careof"));
                Per1Lokalitet = group.Add(new VocabularyKey("Per1Lokalitet", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Lokalitet"));
                Per1Streetline = group.Add(new VocabularyKey("Per1Streetline", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Streetline"));
                Per1Stednavn = group.Add(new VocabularyKey("Per1Stednavn", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Stednavn"));
                Per1Pcode = group.Add(new VocabularyKey("Per1Pcode", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Pcode"));
                Per1Pdistname = group.Add(new VocabularyKey("Per1Pdistname", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Pdistname"));
                Per1Kvhx = group.Add(new VocabularyKey("Per1Kvhx", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Kvhx"));
                Per1AdrContact1 = group.Add(new VocabularyKey("Per1AdrContact1", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Adr Contact 1"));
                Per1AdrContact2 = group.Add(new VocabularyKey("Per1AdrContact2", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Adr Contact 2"));
                Per1AdrContact3 = group.Add(new VocabularyKey("Per1AdrContact3", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Adr Contact 3"));
                Per1AdrContact4 = group.Add(new VocabularyKey("Per1AdrContact4", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Adr Contact 4"));
                Per1AdrContact5 = group.Add(new VocabularyKey("Per1AdrContact5", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Adr Contact 5"));
                Per1AdrContactDate = group.Add(new VocabularyKey("Per1AdrContactDate", VocabularyKeyDataType.DateTime, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Adr Contact Date"));
                Per1AdrForeign1 = group.Add(new VocabularyKey("Per1AdrForeign1", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Adr Foreign 1"));
                Per1AdrForeign2 = group.Add(new VocabularyKey("Per1AdrForeign2", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Adr Foreign 2"));
                Per1AdrForeign3 = group.Add(new VocabularyKey("Per1AdrForeign3", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Adr Foreign 3"));
                Per1AdrForeign4 = group.Add(new VocabularyKey("Per1AdrForeign4", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Adr Foreign 4"));
                Per1AdrForeign5 = group.Add(new VocabularyKey("Per1AdrForeign5", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Adr Foreign 5"));
                Per1AdrForeignDate = group.Add(new VocabularyKey("Per1AdrForeignDate", VocabularyKeyDataType.DateTime, VocabularyKeyVisibility.Visible).WithDisplayName("Per 1 Adr Foreign Date"));
                Per2InputName = group.Add(new VocabularyKey("Per2InputName", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Input Name"));
                Per2CprMatch = group.Add(new VocabularyKey("Per2CprMatch", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Cpr Match"));
                Per2CprStatus = group.Add(new VocabularyKey("Per2CprStatus", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Cpr Status"));
                Per2Protect = group.Add(new VocabularyKey("Per2Protect", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Protect"));
                Per2AdvptectRobinson = group.Add(new VocabularyKey("Per2AdvptectRobinson", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Advptect Robinson"));
                Per2AdvptectRobinsonDate = group.Add(new VocabularyKey("Per2AdvptectRobinsonDate", VocabularyKeyDataType.DateTime, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Advptect Robinson Date"));
                Per2Movdat = group.Add(new VocabularyKey("Per2Movdat", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Movdat"));
                Per2NameFirsts = group.Add(new VocabularyKey("Per2NameFirsts", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Name Firsts"));
                Per2NameLast = group.Add(new VocabularyKey("Per2NameLast", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Name Last"));
                Per2NameAdr = group.Add(new VocabularyKey("Per2NameAdr", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Name Adr"));
                Per2Careof = group.Add(new VocabularyKey("Per2Careof", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Careof"));
                Per2Lokalitet = group.Add(new VocabularyKey("Per2Lokalitet", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Lokalitet"));
                Per2Streetline = group.Add(new VocabularyKey("Per2Streetline", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Streetline"));
                Per2Stednavn = group.Add(new VocabularyKey("Per2Stednavn", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Stednavn"));
                Per2Pcode = group.Add(new VocabularyKey("Per2Pcode", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Pcode"));
                Per2Pdistname = group.Add(new VocabularyKey("Per2Pdistname", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Pdistname"));
                Per2Kvhx = group.Add(new VocabularyKey("Per2Kvhx", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Kvhx"));
                Per2AdrContact1 = group.Add(new VocabularyKey("Per2AdrContact1", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Adr Contact 1"));
                Per2AdrContact2 = group.Add(new VocabularyKey("Per2AdrContact2", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Adr Contact 2"));
                Per2AdrContact3 = group.Add(new VocabularyKey("Per2AdrContact3", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Adr Contact 3"));
                Per2AdrContact4 = group.Add(new VocabularyKey("Per2AdrContact4", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Adr Contact 4"));
                Per2AdrContact5 = group.Add(new VocabularyKey("Per2AdrContact5", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Adr Contact 5"));
                Per2AdrContactDate = group.Add(new VocabularyKey("Per2AdrContactDate", VocabularyKeyDataType.DateTime, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Adr Contact Date"));
                Per2AdrForeign1 = group.Add(new VocabularyKey("Per2AdrForeign1", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Adr Foreign 1"));
                Per2AdrForeign2 = group.Add(new VocabularyKey("Per2AdrForeign2", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Adr Foreign 2"));
                Per2AdrForeign3 = group.Add(new VocabularyKey("Per2AdrForeign3", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Adr Foreign 3"));
                Per2AdrForeign4 = group.Add(new VocabularyKey("Per2AdrForeign4", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Adr Foreign 4"));
                Per2AdrForeign5 = group.Add(new VocabularyKey("Per2AdrForeign5", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Adr Foreign 5"));
                Per2AdrForeignDate = group.Add(new VocabularyKey("Per2AdrForeignDate", VocabularyKeyDataType.DateTime, VocabularyKeyVisibility.Visible).WithDisplayName("Per 2 Adr Foreign Date"));
            });

            //Need to check this out after we get some data from CSV and map the rest of data
            AddMapping(ADRESSE, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.HomeAddress);
            AddMapping(POSTBY, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.HomeAddressZipCode);
            AddMapping(KUNTLF, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.PhoneNumber);
            AddMapping(CVRNUM, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInOrganization.CodesCVR);
        }

        public VocabularyKey FHANUM { get; private set; }
        public VocabularyKey KUNLOEB { get; private set; }
        public VocabularyKey NAVN { get; private set; }
        public VocabularyKey ADRESSE { get; private set; }
        public VocabularyKey ADRESSE2 { get; private set; }
        public VocabularyKey POSTBY { get; private set; }
        public VocabularyKey KUNTLF { get; private set; }
        public VocabularyKey CPRNUM { get; private set; }
        public VocabularyKey CPRNUM2 { get; private set; }
        public VocabularyKey CVRNUM { get; private set; }
        public VocabularyKey OutputName { get; private set; }
        public VocabularyKey OutputNameFirst { get; private set; }
        public VocabularyKey OutputNameLast { get; private set; }
        public VocabularyKey OutputKvhx { get; private set; }
        public VocabularyKey OutputCareof { get; private set; }
        public VocabularyKey OutputLokalitet { get; private set; }
        public VocabularyKey OutputStreetline { get; private set; }
        public VocabularyKey OutputStednavn { get; private set; }
        public VocabularyKey OutputPcode { get; private set; }
        public VocabularyKey OutputPdistname { get; private set; }
        public VocabularyKey OutputStrname { get; private set; }
        public VocabularyKey OutputHounoNum { get; private set; }
        public VocabularyKey OutputHounoAlpha { get; private set; }
        public VocabularyKey OutputFloor { get; private set; }
        public VocabularyKey OutputSuite { get; private set; }
        public VocabularyKey Mobile { get; private set; }
        public VocabularyKey Landline { get; private set; }
        public VocabularyKey InputKvhx { get; private set; }
        public VocabularyKey InputUnadrMatchlvlDetail { get; private set; }
        public VocabularyKey PartnerRemoved { get; private set; }
        public VocabularyKey OutputAddressOrigin { get; private set; }
        public VocabularyKey OutputNameOrigin { get; private set; }
        public VocabularyKey AddressChange { get; private set; }
        public VocabularyKey Duplicate { get; private set; }
        public VocabularyKey DuplicateId { get; private set; }
        public VocabularyKey Per1PnrValidation { get; private set; }
        public VocabularyKey Per2PnrValidation { get; private set; }
        public VocabularyKey Per1InputName { get; private set; }
        public VocabularyKey Per1CprMatch { get; private set; }
        public VocabularyKey Per1CprStatus { get; private set; }
        public VocabularyKey Per1Protect { get; private set; }
        public VocabularyKey Per1AdvptectRobinson { get; private set; }
        public VocabularyKey Per1AdvptectRobinsonDate { get; private set; }
        public VocabularyKey Per1Movdat { get; private set; }
        public VocabularyKey Per1NameFirsts { get; private set; }
        public VocabularyKey Per1NameLast { get; private set; }
        public VocabularyKey Per1NameAdr { get; private set; }
        public VocabularyKey Per1Careof { get; private set; }
        public VocabularyKey Per1Lokalitet { get; private set; }
        public VocabularyKey Per1Streetline { get; private set; }
        public VocabularyKey Per1Stednavn { get; private set; }
        public VocabularyKey Per1Pcode { get; private set; }
        public VocabularyKey Per1Pdistname { get; private set; }
        public VocabularyKey Per1Kvhx { get; private set; }
        public VocabularyKey Per1AdrContact1 { get; private set; }
        public VocabularyKey Per1AdrContact2 { get; private set; }
        public VocabularyKey Per1AdrContact3 { get; private set; }
        public VocabularyKey Per1AdrContact4 { get; private set; }
        public VocabularyKey Per1AdrContact5 { get; private set; }
        public VocabularyKey Per1AdrContactDate { get; private set; }
        public VocabularyKey Per1AdrForeign1 { get; private set; }
        public VocabularyKey Per1AdrForeign2 { get; private set; }
        public VocabularyKey Per1AdrForeign3 { get; private set; }
        public VocabularyKey Per1AdrForeign4 { get; private set; }
        public VocabularyKey Per1AdrForeign5 { get; private set; }
        public VocabularyKey Per1AdrForeignDate { get; private set; }
        public VocabularyKey Per2InputName { get; private set; }
        public VocabularyKey Per2CprMatch { get; private set; }
        public VocabularyKey Per2CprStatus { get; private set; }
        public VocabularyKey Per2Protect { get; private set; }
        public VocabularyKey Per2AdvptectRobinson { get; private set; }
        public VocabularyKey Per2AdvptectRobinsonDate { get; private set; }
        public VocabularyKey Per2Movdat { get; private set; }
        public VocabularyKey Per2NameFirsts { get; private set; }
        public VocabularyKey Per2NameLast { get; private set; }
        public VocabularyKey Per2NameAdr { get; private set; }
        public VocabularyKey Per2Careof { get; private set; }
        public VocabularyKey Per2Lokalitet { get; private set; }
        public VocabularyKey Per2Streetline { get; private set; }
        public VocabularyKey Per2Stednavn { get; private set; }
        public VocabularyKey Per2Pcode { get; private set; }
        public VocabularyKey Per2Pdistname { get; private set; }
        public VocabularyKey Per2Kvhx { get; private set; }
        public VocabularyKey Per2AdrContact1 { get; private set; }
        public VocabularyKey Per2AdrContact2 { get; private set; }
        public VocabularyKey Per2AdrContact3 { get; private set; }
        public VocabularyKey Per2AdrContact4 { get; private set; }
        public VocabularyKey Per2AdrContact5 { get; private set; }
        public VocabularyKey Per2AdrContactDate { get; private set; }
        public VocabularyKey Per2AdrForeign1 { get; private set; }
        public VocabularyKey Per2AdrForeign2 { get; private set; }
        public VocabularyKey Per2AdrForeign3 { get; private set; }
        public VocabularyKey Per2AdrForeign4 { get; private set; }
        public VocabularyKey Per2AdrForeign5 { get; private set; }
        public VocabularyKey Per2AdrForeignDate { get; private set; }
    }
}
