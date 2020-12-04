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

namespace CluedIn.Crawling.Geometic.ClueProducers
{
    public class MetadataClueProducer : BaseClueProducer<Metadata>
    {
        private readonly IClueFactory _factory;

        public MetadataClueProducer(IClueFactory factory)
        {
            _factory = factory;
        }

        protected override Clue MakeClueImpl(Metadata input, Guid id)
        {

            var clue = _factory.Create(EntityType.Unknown, input.CPRNUM, id);//ToDo EntityType...

            var data = clue.Data.EntityData;

            if (!String.IsNullOrWhiteSpace(input.NAVN))
                data.Name = input.NAVN;

            if (!data.OutgoingEdges.Any())
                _factory.CreateEntityRootReference(clue, EntityEdgeType.PartOf);


            var vocab = new MetadataVocabulary();

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


