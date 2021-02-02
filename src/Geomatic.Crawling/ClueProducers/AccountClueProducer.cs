using CluedIn.Core.Data;
using CluedIn.Core.Data.Vocabularies;
using CluedIn.Crawling.Factories;
using CluedIn.Crawling.Helpers;
using CluedIn.Crawling.Geometic.Vocabularies;
using CluedIn.Crawling.Geometic.Core.Models;
using CluedIn.Core;
using RuleConstants = CluedIn.Core.Constants.Validation.Rules;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;
using CluedIn.Crawling.Geomatic.Infrastructure;
using System.Globalization;

namespace CluedIn.Crawling.Geometic.ClueProducers
{
    public class AccountClueProducer : BaseClueProducer<Account>
    {
        private readonly IClueFactory _factory;
        private readonly ILogger<GeomaticClient> _log;

        public AccountClueProducer([NotNull] IClueFactory factory, ILogger<GeomaticClient> _log)
        {
            _factory = factory;
            this._log = _log;
        }

        protected override Clue MakeClueImpl(Account input, Guid id)
        {
            bool isPerson = string.IsNullOrEmpty(input.CVRNUM);

            Clue clue = null;

            if (isPerson)
                clue = _factory.Create(EntityType.Infrastructure.User, input.KUNLOEB, id);
            else
                clue = _factory.Create(EntityType.Organization, input.KUNLOEB, id);

            if (clue == null)
            {
                //If not person nor organization then log.
                _log.LogWarning($"Tried to parse {nameof(Account)} but was not person nor organization. Could not process {input.CVRNUM}", input.NAVN);
                return null;
            }

            var data = clue.Data.EntityData;

            //Create identifiers
            //if (!string.IsNullOrWhiteSpace(input.CVRNUM) && !isPerson)
            //{
            //    data.Codes.Add(new EntityCode(EntityType.Organization, Semler.Common.Origins.Cvr, input.CVRNUM));
            //}

            if (!string.IsNullOrWhiteSpace(input.KUNLOEB))
            {
                if (!isPerson)
                    data.Codes.Add(new EntityCode(EntityType.Organization, Semler.Common.Origins.CustId, input.KUNLOEB));
                else
                    data.Codes.Add(new EntityCode(EntityType.Infrastructure.User, Semler.Common.Origins.CustId, input.KUNLOEB));
            }

            if (!string.IsNullOrWhiteSpace(input.DuplicateId))
            {
                if (!isPerson)
                    data.Codes.Add(new EntityCode(EntityType.Organization, Semler.Common.Origins.DuplicateId, input.DuplicateId));
                else
                    data.Codes.Add(new EntityCode(EntityType.Infrastructure.User, Semler.Common.Origins.DuplicateId, input.DuplicateId));
            }

            if (!string.IsNullOrWhiteSpace(input.OutputName))
            {
                data.Name = input.OutputName;
                data.DisplayName = input.OutputName.ToLower().ToTitleCase();
            }

            //Create Edges
            if (!data.OutgoingEdges.Any())
                _factory.CreateEntityRootReference(clue, EntityEdgeType.PartOf);

            var vocab = new GeomaticAccountVocabulary(isPerson);

            data.Properties[vocab.FHANUM] = input.FHANUM.PrintIfAvailable();
            data.Properties[vocab.KUNLOEB] = input.KUNLOEB.PrintIfAvailable();
            data.Properties[vocab.NAVN] = input.NAVN.PrintIfAvailable();
            data.Properties[vocab.ADRESSE] = input.ADRESSE.PrintIfAvailable();
            data.Properties[vocab.ADRESSE2] = input.ADRESSE2.PrintIfAvailable();
            data.Properties[vocab.POSTBY] = input.POSTBY.PrintIfAvailable();
            data.Properties[vocab.KUNTLF] = input.KUNTLF.PrintIfAvailable();
            data.Properties[vocab.CPRNUM] = input.CPRNUM.PrintIfAvailable();
            data.Properties[vocab.CPRNUM2] = input.CPRNUM2.PrintIfAvailable();
            data.Properties[vocab.CVRNUM] = input.CVRNUM.PrintIfAvailable();
            data.Properties[vocab.OutputName] = input.OutputName.PrintIfAvailable();
            data.Properties[vocab.OutputNameFirst] = input.OutputNameFirst.PrintIfAvailable();
            data.Properties[vocab.OutputNameLast] = input.OutputNameLast.PrintIfAvailable();
            data.Properties[vocab.OutputKvhx] = input.OutputKvhx.PrintIfAvailable();
            data.Properties[vocab.OutputCareof] = input.OutputCareof.PrintIfAvailable();
            data.Properties[vocab.OutputLokalitet] = input.OutputLokalitet.PrintIfAvailable();
            data.Properties[vocab.OutputStreetline] = input.OutputStreetline.PrintIfAvailable();
            data.Properties[vocab.OutputStednavn] = input.OutputStednavn.PrintIfAvailable();
            data.Properties[vocab.OutputPcode] = input.OutputPcode.PrintIfAvailable();
            data.Properties[vocab.OutputPdistname] = input.OutputPdistname.PrintIfAvailable();
            data.Properties[vocab.OutputStrname] = input.OutputStrname.PrintIfAvailable();
            data.Properties[vocab.OutputHounoNum] = input.OutputHounoNum.PrintIfAvailable();
            data.Properties[vocab.OutputHounoAlpha] = input.OutputHounoAlpha.PrintIfAvailable();
            data.Properties[vocab.OutputFloor] = input.OutputFloor.PrintIfAvailable();
            data.Properties[vocab.OutputSuite] = input.OutputSuite.PrintIfAvailable();

            if (!string.IsNullOrWhiteSpace(input.Mobile))
            {
                data.Properties[vocab.Mobile] = input.Mobile.PrintIfAvailable();
                data.Aliases.Add(input.Mobile);
            }

            if (!string.IsNullOrWhiteSpace(input.Landline))
            {
                data.Properties[vocab.Landline] = input.Landline.PrintIfAvailable();
                data.Aliases.Add(input.Landline);
            }

            data.Properties[vocab.InputKvhx] = input.InputKvhx.PrintIfAvailable();
            data.Properties[vocab.InputUnadrMatchlvlDetail] = input.InputUnadrMatchlvlDetail.PrintIfAvailable();
            data.Properties[vocab.PartnerRemoved] = input.PartnerRemoved.PrintIfAvailable();
            data.Properties[vocab.OutputAddressOrigin] = input.OutputAddressOrigin.PrintIfAvailable();
            data.Properties[vocab.OutputNameOrigin] = input.OutputNameOrigin.PrintIfAvailable();
            data.Properties[vocab.AddressChange] = input.AddressChange.PrintIfAvailable();
            data.Properties[vocab.Duplicate] = input.Duplicate.PrintIfAvailable();
            data.Properties[vocab.DuplicateId] = input.DuplicateId.PrintIfAvailable();
            data.Properties[vocab.Per1PnrValidation] = input.Per1PnrValidation.PrintIfAvailable();
            data.Properties[vocab.Per2PnrValidation] = input.Per2PnrValidation.PrintIfAvailable();
            data.Properties[vocab.Per1InputName] = input.Per1InputName.PrintIfAvailable();
            data.Properties[vocab.Per1CprMatch] = input.Per1CprMatch.PrintIfAvailable();
            data.Properties[vocab.Per1CprStatus] = input.Per1CprStatus.PrintIfAvailable();
            data.Properties[vocab.Per1Protect] = input.Per1Protect.PrintIfAvailable();
            data.Properties[vocab.Per1AdvptectRobinson] = input.Per1AdvptectRobinson.PrintIfAvailable();
            data.Properties[vocab.Per1AdvptectRobinsonDate] = input.Per1AdvptectRobinsonDate.PrintIfAvailable();
            data.Properties[vocab.Per1Movdat] = input.Per1Movdat.PrintIfAvailable();
            data.Properties[vocab.Per1NameFirsts] = input.Per1NameFirsts.PrintIfAvailable();
            data.Properties[vocab.Per1NameLast] = input.Per1NameLast.PrintIfAvailable();
            data.Properties[vocab.Per1NameAdr] = input.Per1NameAdr.PrintIfAvailable();
            data.Properties[vocab.Per1Careof] = input.Per1Careof.PrintIfAvailable();
            data.Properties[vocab.Per1Lokalitet] = input.Per1Lokalitet.PrintIfAvailable();
            data.Properties[vocab.Per1Streetline] = input.Per1Streetline.PrintIfAvailable();
            data.Properties[vocab.Per1Stednavn] = input.Per1Stednavn.PrintIfAvailable();
            data.Properties[vocab.Per1Pcode] = input.Per1Pcode.PrintIfAvailable();
            data.Properties[vocab.Per1Pdistname] = input.Per1Pdistname.PrintIfAvailable();
            data.Properties[vocab.Per1Kvhx] = input.Per1Kvhx.PrintIfAvailable();
            data.Properties[vocab.Per1AdrContact1] = input.Per1AdrContact1.PrintIfAvailable();
            data.Properties[vocab.Per1AdrContact2] = input.Per1AdrContact2.PrintIfAvailable();
            data.Properties[vocab.Per1AdrContact3] = input.Per1AdrContact3.PrintIfAvailable();
            data.Properties[vocab.Per1AdrContact4] = input.Per1AdrContact4.PrintIfAvailable();
            data.Properties[vocab.Per1AdrContact5] = input.Per1AdrContact5.PrintIfAvailable();
            data.Properties[vocab.Per1AdrContactDate] = input.Per1AdrContactDate.PrintIfAvailable();
            data.Properties[vocab.Per1AdrForeign1] = input.Per1AdrForeign1.PrintIfAvailable();
            data.Properties[vocab.Per1AdrForeign2] = input.Per1AdrForeign2.PrintIfAvailable();
            data.Properties[vocab.Per1AdrForeign3] = input.Per1AdrForeign3.PrintIfAvailable();
            data.Properties[vocab.Per1AdrForeign4] = input.Per1AdrForeign4.PrintIfAvailable();
            data.Properties[vocab.Per1AdrForeign5] = input.Per1AdrForeign5.PrintIfAvailable();
            data.Properties[vocab.Per1AdrForeignDate] = input.Per1AdrForeignDate.PrintIfAvailable();
            data.Properties[vocab.Per2InputName] = input.Per2InputName.PrintIfAvailable();
            data.Properties[vocab.Per2CprMatch] = input.Per2CprMatch.PrintIfAvailable();
            data.Properties[vocab.Per2CprStatus] = input.Per2CprStatus.PrintIfAvailable();
            data.Properties[vocab.Per2Protect] = input.Per2Protect.PrintIfAvailable();
            data.Properties[vocab.Per2AdvptectRobinson] = input.Per2AdvptectRobinson.PrintIfAvailable();
            data.Properties[vocab.Per2AdvptectRobinsonDate] = input.Per2AdvptectRobinsonDate.PrintIfAvailable();
            data.Properties[vocab.Per2Movdat] = input.Per2Movdat.PrintIfAvailable();
            data.Properties[vocab.Per2NameFirsts] = input.Per2NameFirsts.PrintIfAvailable();
            data.Properties[vocab.Per2NameLast] = input.Per2NameLast.PrintIfAvailable();
            data.Properties[vocab.Per2NameAdr] = input.Per2NameAdr.PrintIfAvailable();
            data.Properties[vocab.Per2Careof] = input.Per2Careof.PrintIfAvailable();
            data.Properties[vocab.Per2Lokalitet] = input.Per2Lokalitet.PrintIfAvailable();
            data.Properties[vocab.Per2Streetline] = input.Per2Streetline.PrintIfAvailable();
            data.Properties[vocab.Per2Stednavn] = input.Per2Stednavn.PrintIfAvailable();
            data.Properties[vocab.Per2Pcode] = input.Per2Pcode.PrintIfAvailable();
            data.Properties[vocab.Per2Pdistname] = input.Per2Pdistname.PrintIfAvailable();
            data.Properties[vocab.Per2Kvhx] = input.Per2Kvhx.PrintIfAvailable();
            data.Properties[vocab.Per2AdrContact1] = input.Per2AdrContact1.PrintIfAvailable();
            data.Properties[vocab.Per2AdrContact2] = input.Per2AdrContact2.PrintIfAvailable();
            data.Properties[vocab.Per2AdrContact3] = input.Per2AdrContact3.PrintIfAvailable();
            data.Properties[vocab.Per2AdrContact4] = input.Per2AdrContact4.PrintIfAvailable();
            data.Properties[vocab.Per2AdrContact5] = input.Per2AdrContact5.PrintIfAvailable();
            data.Properties[vocab.Per2AdrContactDate] = input.Per2AdrContactDate.PrintIfAvailable();
            data.Properties[vocab.Per2AdrForeign1] = input.Per2AdrForeign1.PrintIfAvailable();
            data.Properties[vocab.Per2AdrForeign2] = input.Per2AdrForeign2.PrintIfAvailable();
            data.Properties[vocab.Per2AdrForeign3] = input.Per2AdrForeign3.PrintIfAvailable();
            data.Properties[vocab.Per2AdrForeign4] = input.Per2AdrForeign4.PrintIfAvailable();
            data.Properties[vocab.Per2AdrForeign5] = input.Per2AdrForeign5.PrintIfAvailable();
            data.Properties[vocab.Per2AdrForeignDate] = input.Per2AdrForeignDate.PrintIfAvailable();

            clue.ValidationRuleSuppressions.AddRange(new[]
            {
                RuleConstants.METADATA_001_Name_MustBeSet,
                RuleConstants.PROPERTIES_001_MustExist,
                RuleConstants.METADATA_002_Uri_MustBeSet,
                RuleConstants.METADATA_003_Author_Name_MustBeSet,
                RuleConstants.METADATA_005_PreviewImage_RawData_MustBeSet
            });

            return clue;
        }
    }
}


