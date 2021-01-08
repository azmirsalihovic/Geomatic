//using CluedIn.Core.Data;
//using CluedIn.Core.Data.Vocabularies;
//using CluedIn.Crawling.Factories;
//using CluedIn.Crawling.Helpers;
//using CluedIn.Crawling.Geometic.Vocabularies;
//using CluedIn.Crawling.Geometic.Core.Models;
//using CluedIn.Core;
//using RuleConstants = CluedIn.Core.Constants.Validation.Rules;
//using System.Linq;
//using System;

//namespace CluedIn.Crawling.Geometic.ClueProducers
//{
//    public class PrivateCustomerClueProducer : BaseClueProducer<PrivateCustomer>
//    {
//        private readonly IClueFactory _factory;

//        public PrivateCustomerClueProducer(IClueFactory factory)
//        {
//            _factory = factory;
//        }

//        protected override Clue MakeClueImpl(PrivateCustomer input, Guid id)
//        {

//            var clue = _factory.Create(EntityType.Infrastructure.User, input.KUNLOEB, id);//ToDo EntityType...

//            var data = clue.Data.EntityData;

//            if (!String.IsNullOrWhiteSpace(input.NAVN))
//                data.Name = input.NAVN;

//            if (!data.OutgoingEdges.Any())
//                _factory.CreateEntityRootReference(clue, EntityEdgeType.PartOf);

//            var vocab = new PrivateCustomerVocabulary();
//            if (input.FHANUM != null)
//                data.Properties[vocab.FHANUM] = input.FHANUM.PrintIfAvailable();
//            if (input.KUNLOEB != null)
//                data.Properties[vocab.KUNLOEB] = input.KUNLOEB.PrintIfAvailable();
//            if (input.NAVN != null)
//                data.Properties[vocab.NAVN] = input.NAVN.PrintIfAvailable();
//            if (input.ADRESSE != null)
//                data.Properties[vocab.ADRESSE] = input.ADRESSE.PrintIfAvailable();
//            if (input.ADRESSE2 != null)
//                data.Properties[vocab.ADRESSE2] = input.ADRESSE2.PrintIfAvailable();
//            if (input.POSTBY != null)
//                data.Properties[vocab.POSTBY] = input.POSTBY.PrintIfAvailable();
//            if (input.KUNTLF != null)
//                data.Properties[vocab.KUNTLF] = input.KUNTLF.PrintIfAvailable();
//            if (input.CPRNUM != null)
//                data.Properties[vocab.CPRNUM] = input.CPRNUM.PrintIfAvailable();
//            if (input.CPRNUM2 != null)
//                data.Properties[vocab.CPRNUM2] = input.CPRNUM2.PrintIfAvailable();
//            if (input.CVRNUM != null)
//                data.Properties[vocab.CVRNUM] = input.CVRNUM.PrintIfAvailable();
//            if (input.OutputName != null)
//                data.Properties[vocab.OutputName] = input.OutputName.PrintIfAvailable();
//            if (input.OutputNameFirst != null)
//                data.Properties[vocab.OutputNameFirst] = input.OutputNameFirst.PrintIfAvailable();
//            if (input.OutputNameLast != null)
//                data.Properties[vocab.OutputNameLast] = input.OutputNameLast.PrintIfAvailable();
//            if (input.OutputKvhx != null)
//                data.Properties[vocab.OutputKvhx] = input.OutputKvhx.PrintIfAvailable();
//            if (input.OutputCareof != null)
//                data.Properties[vocab.OutputCareof] = input.OutputCareof.PrintIfAvailable();
//            if (input.OutputLokalitet != null)
//                data.Properties[vocab.OutputLokalitet] = input.OutputLokalitet.PrintIfAvailable();
//            if (input.OutputStreetline != null)
//                data.Properties[vocab.OutputStreetline] = input.OutputStreetline.PrintIfAvailable();
//            if (input.OutputStednavn != null)
//                data.Properties[vocab.OutputStednavn] = input.OutputStednavn.PrintIfAvailable();
//            if (input.OutputPcode != null)
//                data.Properties[vocab.OutputPcode] = input.OutputPcode.PrintIfAvailable();
//            if (input.OutputPdistname != null)
//                data.Properties[vocab.OutputPdistname] = input.OutputPdistname.PrintIfAvailable();
//            if (input.OutputStrname != null)
//                data.Properties[vocab.OutputStrname] = input.OutputStrname.PrintIfAvailable();
//            if (input.OutputHounoNum != null)
//                data.Properties[vocab.OutputHounoNum] = input.OutputHounoNum.PrintIfAvailable();
//            if (input.OutputHounoAlpha != null)
//                data.Properties[vocab.OutputHounoAlpha] = input.OutputHounoAlpha.PrintIfAvailable();
//            if (input.OutputFloor != null)
//                data.Properties[vocab.OutputFloor] = input.OutputFloor.PrintIfAvailable();
//            if (input.OutputSuite != null)
//                data.Properties[vocab.OutputSuite] = input.OutputSuite.PrintIfAvailable();
//            if (input.Mobile != null)
//            {
//                data.Properties[vocab.Mobile] = input.Mobile.PrintIfAvailable();
//                data.Aliases.Add(input.Mobile);
//            }

//            if (input.Landline != null)
//            {
//                data.Properties[vocab.Landline] = input.Landline.PrintIfAvailable();
//                data.Aliases.Add(input.Landline);
//            }

//            if (input.InputKvhx != null)
//                data.Properties[vocab.InputKvhx] = input.InputKvhx.PrintIfAvailable();
//            if (input.InputUnadrMatchlvlDetail != null)
//                data.Properties[vocab.InputUnadrMatchlvlDetail] = input.InputUnadrMatchlvlDetail.PrintIfAvailable();
//            if (input.PartnerRemoved != null)
//                data.Properties[vocab.PartnerRemoved] = input.PartnerRemoved.PrintIfAvailable();
//            if (input.OutputAddressOrigin != null)
//                data.Properties[vocab.OutputAddressOrigin] = input.OutputAddressOrigin.PrintIfAvailable();
//            if (input.OutputNameOrigin != null)
//                data.Properties[vocab.OutputNameOrigin] = input.OutputNameOrigin.PrintIfAvailable();
//            if (input.AddressChange != null)
//                data.Properties[vocab.AddressChange] = input.AddressChange.PrintIfAvailable();
//            if (input.Duplicate != null)
//                data.Properties[vocab.Duplicate] = input.Duplicate.PrintIfAvailable();
//            if (input.DuplicateId != null)
//                data.Properties[vocab.DuplicateId] = input.DuplicateId.PrintIfAvailable();
//            if (input.Per1PnrValidation != null)
//                data.Properties[vocab.Per1PnrValidation] = input.Per1PnrValidation.PrintIfAvailable();
//            if (input.Per2PnrValidation != null)
//                data.Properties[vocab.Per2PnrValidation] = input.Per2PnrValidation.PrintIfAvailable();
//            if (input.Per1InputName != null)
//                data.Properties[vocab.Per1InputName] = input.Per1InputName.PrintIfAvailable();
//            if (input.Per1CprMatch != null)
//                data.Properties[vocab.Per1CprMatch] = input.Per1CprMatch.PrintIfAvailable();
//            if (input.Per1CprStatus != null)
//                data.Properties[vocab.Per1CprStatus] = input.Per1CprStatus.PrintIfAvailable();
//            if (input.Per1Protect != null)
//                data.Properties[vocab.Per1Protect] = input.Per1Protect.PrintIfAvailable();
//            if (input.Per1AdvptectRobinson != null)
//                data.Properties[vocab.Per1AdvptectRobinson] = input.Per1AdvptectRobinson.PrintIfAvailable();
//            if (input.Per1AdvptectRobinsonDate != null)
//                data.Properties[vocab.Per1AdvptectRobinsonDate] = input.Per1AdvptectRobinsonDate.PrintIfAvailable();
//            if (input.Per1Movdat != null)
//                data.Properties[vocab.Per1Movdat] = input.Per1Movdat.PrintIfAvailable();
//            if (input.Per1NameFirsts != null)
//                data.Properties[vocab.Per1NameFirsts] = input.Per1NameFirsts.PrintIfAvailable();
//            if (input.Per1NameLast != null)
//                data.Properties[vocab.Per1NameLast] = input.Per1NameLast.PrintIfAvailable();
//            if (input.Per1NameAdr != null)
//                data.Properties[vocab.Per1NameAdr] = input.Per1NameAdr.PrintIfAvailable();
//            if (input.Per1Careof != null)
//                data.Properties[vocab.Per1Careof] = input.Per1Careof.PrintIfAvailable();
//            if (input.Per1Lokalitet != null)
//                data.Properties[vocab.Per1Lokalitet] = input.Per1Lokalitet.PrintIfAvailable();
//            if (input.Per1Streetline != null)
//                data.Properties[vocab.Per1Streetline] = input.Per1Streetline.PrintIfAvailable();
//            if (input.Per1Stednavn != null)
//                data.Properties[vocab.Per1Stednavn] = input.Per1Stednavn.PrintIfAvailable();
//            if (input.Per1Pcode != null)
//                data.Properties[vocab.Per1Pcode] = input.Per1Pcode.PrintIfAvailable();
//            if (input.Per1Pdistname != null)
//                data.Properties[vocab.Per1Pdistname] = input.Per1Pdistname.PrintIfAvailable();
//            if (input.Per1Kvhx != null)
//                data.Properties[vocab.Per1Kvhx] = input.Per1Kvhx.PrintIfAvailable();
//            if (input.Per1AdrContact1 != null)
//                data.Properties[vocab.Per1AdrContact1] = input.Per1AdrContact1.PrintIfAvailable();
//            if (input.Per1AdrContact2 != null)
//                data.Properties[vocab.Per1AdrContact2] = input.Per1AdrContact2.PrintIfAvailable();
//            if (input.Per1AdrContact3 != null)
//                data.Properties[vocab.Per1AdrContact3] = input.Per1AdrContact3.PrintIfAvailable();
//            if (input.Per1AdrContact4 != null)
//                data.Properties[vocab.Per1AdrContact4] = input.Per1AdrContact4.PrintIfAvailable();
//            if (input.Per1AdrContact5 != null)
//                data.Properties[vocab.Per1AdrContact5] = input.Per1AdrContact5.PrintIfAvailable();
//            if (input.Per1AdrContactDate != null)
//                data.Properties[vocab.Per1AdrContactDate] = input.Per1AdrContactDate.PrintIfAvailable();
//            if (input.Per1AdrForeign1 != null)
//                data.Properties[vocab.Per1AdrForeign1] = input.Per1AdrForeign1.PrintIfAvailable();
//            if (input.Per1AdrForeign2 != null)
//                data.Properties[vocab.Per1AdrForeign2] = input.Per1AdrForeign2.PrintIfAvailable();
//            if (input.Per1AdrForeign3 != null)
//                data.Properties[vocab.Per1AdrForeign3] = input.Per1AdrForeign3.PrintIfAvailable();
//            if (input.Per1AdrForeign4 != null)
//                data.Properties[vocab.Per1AdrForeign4] = input.Per1AdrForeign4.PrintIfAvailable();
//            if (input.Per1AdrForeign5 != null)
//                data.Properties[vocab.Per1AdrForeign5] = input.Per1AdrForeign5.PrintIfAvailable();
//            if (input.Per1AdrForeignDate != null)
//                data.Properties[vocab.Per1AdrForeignDate] = input.Per1AdrForeignDate.PrintIfAvailable();
//            if (input.Per2InputName != null)
//                data.Properties[vocab.Per2InputName] = input.Per2InputName.PrintIfAvailable();
//            if (input.Per2CprMatch != null)
//                data.Properties[vocab.Per2CprMatch] = input.Per2CprMatch.PrintIfAvailable();
//            if (input.Per2CprStatus != null)
//                data.Properties[vocab.Per2CprStatus] = input.Per2CprStatus.PrintIfAvailable();
//            if (input.Per2Protect != null)
//                data.Properties[vocab.Per2Protect] = input.Per2Protect.PrintIfAvailable();
//            if (input.Per2AdvptectRobinson != null)
//                data.Properties[vocab.Per2AdvptectRobinson] = input.Per2AdvptectRobinson.PrintIfAvailable();
//            if (input.Per2AdvptectRobinsonDate != null)
//                data.Properties[vocab.Per2AdvptectRobinsonDate] = input.Per2AdvptectRobinsonDate.PrintIfAvailable();
//            if (input.Per2Movdat != null)
//                data.Properties[vocab.Per2Movdat] = input.Per2Movdat.PrintIfAvailable();
//            if (input.Per2NameFirsts != null)
//                data.Properties[vocab.Per2NameFirsts] = input.Per2NameFirsts.PrintIfAvailable();
//            if (input.Per2NameLast != null)
//                data.Properties[vocab.Per2NameLast] = input.Per2NameLast.PrintIfAvailable();
//            if (input.Per2NameAdr != null)
//                data.Properties[vocab.Per2NameAdr] = input.Per2NameAdr.PrintIfAvailable();
//            if (input.Per2Careof != null)
//                data.Properties[vocab.Per2Careof] = input.Per2Careof.PrintIfAvailable();
//            if (input.Per2Lokalitet != null)
//                data.Properties[vocab.Per2Lokalitet] = input.Per2Lokalitet.PrintIfAvailable();
//            if (input.Per2Streetline != null)
//                data.Properties[vocab.Per2Streetline] = input.Per2Streetline.PrintIfAvailable();
//            if (input.Per2Stednavn != null)
//                data.Properties[vocab.Per2Stednavn] = input.Per2Stednavn.PrintIfAvailable();
//            if (input.Per2Pcode != null)
//                data.Properties[vocab.Per2Pcode] = input.Per2Pcode.PrintIfAvailable();
//            if (input.Per2Pdistname != null)
//                data.Properties[vocab.Per2Pdistname] = input.Per2Pdistname.PrintIfAvailable();
//            if (input.Per2Kvhx != null)
//                data.Properties[vocab.Per2Kvhx] = input.Per2Kvhx.PrintIfAvailable();
//            if (input.Per2AdrContact1 != null)
//                data.Properties[vocab.Per2AdrContact1] = input.Per2AdrContact1.PrintIfAvailable();
//            if (input.Per2AdrContact2 != null)
//                data.Properties[vocab.Per2AdrContact2] = input.Per2AdrContact2.PrintIfAvailable();
//            if (input.Per2AdrContact3 != null)
//                data.Properties[vocab.Per2AdrContact3] = input.Per2AdrContact3.PrintIfAvailable();
//            if (input.Per2AdrContact4 != null)
//                data.Properties[vocab.Per2AdrContact4] = input.Per2AdrContact4.PrintIfAvailable();
//            if (input.Per2AdrContact5 != null)
//                data.Properties[vocab.Per2AdrContact5] = input.Per2AdrContact5.PrintIfAvailable();
//            if (input.Per2AdrContactDate != null)
//                data.Properties[vocab.Per2AdrContactDate] = input.Per2AdrContactDate.PrintIfAvailable();
//            if (input.Per2AdrForeign1 != null)
//                data.Properties[vocab.Per2AdrForeign1] = input.Per2AdrForeign1.PrintIfAvailable();
//            if (input.Per2AdrForeign2 != null)
//                data.Properties[vocab.Per2AdrForeign2] = input.Per2AdrForeign2.PrintIfAvailable();
//            if (input.Per2AdrForeign3 != null)
//                data.Properties[vocab.Per2AdrForeign3] = input.Per2AdrForeign3.PrintIfAvailable();
//            if (input.Per2AdrForeign4 != null)
//                data.Properties[vocab.Per2AdrForeign4] = input.Per2AdrForeign4.PrintIfAvailable();
//            if (input.Per2AdrForeign5 != null)
//                data.Properties[vocab.Per2AdrForeign5] = input.Per2AdrForeign5.PrintIfAvailable();
//            if (input.Per2AdrForeignDate != null)
//                data.Properties[vocab.Per2AdrForeignDate] = input.Per2AdrForeignDate.PrintIfAvailable();

//            clue.ValidationRuleSuppressions.AddRange(new[]
//                                        {
//                                RuleConstants.METADATA_001_Name_MustBeSet,
//                                RuleConstants.PROPERTIES_001_MustExist,
//                                RuleConstants.METADATA_002_Uri_MustBeSet,
//                                RuleConstants.METADATA_003_Author_Name_MustBeSet,
//                                RuleConstants.METADATA_005_PreviewImage_RawData_MustBeSet
//                            });

//            return clue;
//        }
//    }
//}


