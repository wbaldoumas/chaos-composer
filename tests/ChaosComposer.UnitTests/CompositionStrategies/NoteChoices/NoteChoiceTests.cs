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
        public void GetVoiceNoteChoice_returns_expected_VoiceNoteChoice()
        {
            // arrange
            var voiceNoteChoices = new HashSet<VoiceNoteChoice>
            {
                new(Voice.Bass, NoteMotion.Oblique, 1),
                new(Voice.Harmony, NoteMotion.Descending, 12),
                new(Voice.Melody, NoteMotion.Ascending, 123)
            };

            var noteChoice = new NoteChoice(voiceNoteChoices);

            // act
            var voiceNoteChoice = noteChoice.GetVoiceNoteChoice(Voice.Melody);

            // assert
            voiceNoteChoice.Should().Be(new VoiceNoteChoice(Voice.Melody, NoteMotion.Ascending, 123));
        }
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

        [Test]
        public void When_other_NoteChoice_is_null_they_are_not_equal()
        {
            // arrange
            var noteChoice = new NoteChoice(new HashSet<VoiceNoteChoice>());

            // act
            var areEqual = noteChoice.Equals(null);
            var areObjectEqual = noteChoice.Equals((object) null);

            // assert
            areEqual.Should().BeFalse();
            areObjectEqual.Should().BeFalse();
        }

        [Test]
        public void When_other_NoteChoice_is_same_reference_they_are_equal()
        {
            // arrange
            var noteChoice = new NoteChoice(new HashSet<VoiceNoteChoice>());
            var noteChoiceB = noteChoice;

            // act
            var areEqual = noteChoice.Equals(noteChoiceB);
            var areObjectEqual = noteChoice.Equals((object) noteChoiceB);

            // assert
            areEqual.Should().BeTrue();
            areObjectEqual.Should().BeTrue();
        }

        [Test]
        public void When_other_VoiceNoteChoices_are_same_reference_they_are_equal()
        {
            // arrange
            var voiceNoteChoices = new HashSet<VoiceNoteChoice>();

            var noteChoice = new NoteChoice(voiceNoteChoices);
            var noteChoiceB = new NoteChoice(voiceNoteChoices);

            // act
            var areEqual = noteChoice.Equals(noteChoiceB);
            var areObjectEqual = noteChoice.Equals((object) noteChoiceB);

            // assert
            areEqual.Should().BeTrue();
            areObjectEqual.Should().BeTrue();
        }

        [Test]
        public void When_other_NoteChoice_is_not_a_NoteChoice_they_are_not_equal()
        {
            // arrange
            var voiceNoteChoices = new HashSet<VoiceNoteChoice>();

            var noteChoice = new NoteChoice(voiceNoteChoices);
            var noteChoiceB = new { SomeField = 1 };

            // act
            var areEqual = noteChoice.Equals(noteChoiceB);

            // assert
            areEqual.Should().BeFalse();
        }

        [Test]
        public void When_other_VoiceNoteChoices_are_null_they_are_not_equal()
        {
            // arrange
            var voiceNoteChoices = new HashSet<VoiceNoteChoice>
            {
                new(Voice.Bass, NoteMotion.Oblique, 2),
                new(Voice.Harmony, NoteMotion.Descending, 13),
                new(Voice.Melody, NoteMotion.Ascending, 124)
            };

            var noteChoice = new NoteChoice(voiceNoteChoices);
            var noteChoiceB = new NoteChoice(null);

            // act
            var areEqual = noteChoice.Equals(noteChoiceB);

            // assert
            areEqual.Should().BeFalse();
        }
    }
}