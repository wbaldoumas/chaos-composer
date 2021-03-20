using System.Collections.Generic;
using ChaosComposer.Engine.CompositionStrategies.NoteChoices;
using ChaosComposer.Engine.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace ChaosComposer.UnitTests.CompositionStrategies.NoteChoices
{
    [TestFixture]
    public class NoteChoiceTests
    {
        [Test]
        public void When_note_choices_have_same_voice_note_choices_they_are_equal()
        {
            // arrange
            var voiceNoteChoicesA = new HashSet<VoiceNoteChoice>
            {
                new(Voice.Bass, NoteMotion.Oblique, 1),
                new(Voice.Harmony, NoteMotion.Descending, 12),
                new(Voice.Melody, NoteMotion.Ascending, 123)
            };

            var voiceNoteChoicesB = new HashSet<VoiceNoteChoice>
            {
                new(Voice.Bass, NoteMotion.Oblique, 1),
                new(Voice.Harmony, NoteMotion.Descending, 12),
                new(Voice.Melody, NoteMotion.Ascending, 123)
            };

            var noteChoiceA = new NoteChoice(voiceNoteChoicesA);
            var noteChoiceB = new NoteChoice(voiceNoteChoicesB);

            // act
            var areEqual = noteChoiceA.Equals(noteChoiceB);
            var areEqualOperator = noteChoiceA == noteChoiceB;
            var areNotEqualOperator = noteChoiceA != noteChoiceB;
            var areHashCodesEqual = noteChoiceA.GetHashCode() == noteChoiceB.GetHashCode();

            // assert
            areEqual.Should().BeTrue();
            areEqualOperator.Should().BeTrue();
            areNotEqualOperator.Should().BeFalse();
            areHashCodesEqual.Should().BeTrue();
        }

        [Test]
        public void When_note_choices_have_different_voice_note_choices_they_are_not_equal()
        {
            // arrange
            var voiceNoteChoicesA = new HashSet<VoiceNoteChoice>
            {
                new(Voice.Bass, NoteMotion.Oblique, 2),
                new(Voice.Harmony, NoteMotion.Descending, 13),
                new(Voice.Melody, NoteMotion.Ascending, 124)
            };

            var voiceNoteChoicesB = new HashSet<VoiceNoteChoice>
            {
                new(Voice.Bass, NoteMotion.Oblique, 1),
                new(Voice.Harmony, NoteMotion.Descending, 12),
                new(Voice.Melody, NoteMotion.Ascending, 123)
            };

            var noteChoiceA = new NoteChoice(voiceNoteChoicesA);
            var noteChoiceB = new NoteChoice(voiceNoteChoicesB);

            // act
            var areEqual = noteChoiceA.Equals(noteChoiceB);
            var areEqualOperator = noteChoiceA == noteChoiceB;
            var areNotEqualOperator = noteChoiceA != noteChoiceB;
            var areHashCodesEqual = noteChoiceA.GetHashCode() == noteChoiceB.GetHashCode();

            // assert
            areEqual.Should().BeFalse();
            areEqualOperator.Should().BeFalse();
            areNotEqualOperator.Should().BeTrue();
            areHashCodesEqual.Should().BeFalse();
        }
    }
}