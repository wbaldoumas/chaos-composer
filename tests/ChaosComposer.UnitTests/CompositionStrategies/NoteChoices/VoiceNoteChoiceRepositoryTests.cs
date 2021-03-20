using Atrea.Utilities.Enums;
using ChaosComposer.Engine.CompositionStrategies.NoteChoices;
using ChaosComposer.Engine.Enums;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChaosComposer.UnitTests.CompositionStrategies.NoteChoices
{
    [TestFixture]
    public class VoiceNoteChoiceRepositoryTests
    {
        [Test]
        public void VoiceNoteChoiceRepository_Caches_VoiceNoteChoices()
        {
            // arrange
            var mockVoiceNoteChoiceGenerator = Substitute.For<IVoiceNoteChoiceGenerator>();
            var mockVoiceNoteChoice = new VoiceNoteChoice(Voice.Bass, NoteMotion.Ascending, 1);
            var mockVoiceNoteChoiceGeneratorReturn = new HashSet<VoiceNoteChoice> { mockVoiceNoteChoice };

            mockVoiceNoteChoiceGenerator
                .GenerateVoiceNoteChoices(Arg.Any<Voice>())
                .Returns(mockVoiceNoteChoiceGeneratorReturn);

            var voiceNoteChoiceRepository = new VoiceNoteChoiceRepository(mockVoiceNoteChoiceGenerator);

            foreach (var voice in EnumUtils<Voice>.AsEnumerable())
            {
                // act
                var nonCachedVoiceNoteChoices = voiceNoteChoiceRepository.GetVoiceNoteChoices(voice);
                var cachedVoiceNoteChoices = voiceNoteChoiceRepository.GetVoiceNoteChoices(voice);

                // assert
                nonCachedVoiceNoteChoices.Should().NotBeEmpty();
                cachedVoiceNoteChoices.Should().NotBeEmpty();

                nonCachedVoiceNoteChoices.Should().BeSameAs(cachedVoiceNoteChoices);

                mockVoiceNoteChoiceGenerator.Received(1).GenerateVoiceNoteChoices(voice);
            }
        }
    }
}