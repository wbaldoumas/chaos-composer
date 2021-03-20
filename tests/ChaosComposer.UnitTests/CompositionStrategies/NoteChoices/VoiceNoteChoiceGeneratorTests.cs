using Atrea.Utilities.Enums;
using ChaosComposer.Engine.CompositionStrategies.NoteChoices;
using ChaosComposer.Engine.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace ChaosComposer.UnitTests.CompositionStrategies.NoteChoices
{
    [TestFixture]
    public class VoiceNoteChoiceGeneratorTests
    {
        [Test]
        public void VoiceNoteChoiceGenerator_Only_Generates_List_Of_Unique_Voice_Note_Choices()
        {
            var voiceNoteChoiceGenerator = new VoiceNoteChoiceGenerator();

            foreach (var voice in EnumUtils<Voice>.AsEnumerable())
            {
                var voiceNoteChoices = voiceNoteChoiceGenerator.GenerateVoiceNoteChoices(voice);

                voiceNoteChoices.Should().OnlyHaveUniqueItems();
            }
        }
    }
}