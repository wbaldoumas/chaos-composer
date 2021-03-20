using Atrea.Utilities.Enums;
using ChaosComposer.Engine.CompositionStrategies.NoteChoices;
using ChaosComposer.Engine.Enums;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ChaosComposer.UnitTests.CompositionStrategies.NoteChoices
{
    [TestFixture]
    public class NoteChoiceGeneratorTests
    {
        private IVoiceNoteChoiceRepository _mockVoiceNoteChoiceRepository;

        [SetUp]
        public void SetUp()
        {
            _mockVoiceNoteChoiceRepository = Substitute.For<IVoiceNoteChoiceRepository>();

            foreach (var voice in EnumUtils<Voice>.AsEnumerable())
            {
                _mockVoiceNoteChoiceRepository
                    .GetVoiceNoteChoices(voice)
                    .Returns(MockVoiceNoteChoicesByVoice[voice]);
            }
        }

        [Test]
        public void GetNoteChoiceIndices_Throws_Exception_When_Uninitialized()
        {
            // arrange
            var noteChoiceGenerator = new NoteChoiceGenerator(_mockVoiceNoteChoiceRepository);

            var act = new Func<IDictionary<INoteChoice, int>>(() => noteChoiceGenerator.GetNoteChoiceIndices());

            // act + assert
            act.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Note choices must be generated before attempting to retrieve their indices!");
        }

        [Test]
        [TestCaseSource(nameof(VoiceSetTestCases))]
        public void NoteChoiceGenerator_Generates_Unique_Note_Choices(
            ISet<Voice> chosenVoices,
            int expectedNoteChoiceCount)
        {
            // arrange
            var noteChoiceGenerator = new NoteChoiceGenerator(_mockVoiceNoteChoiceRepository);

            // act
            var noteChoices = noteChoiceGenerator.GetNoteChoices(chosenVoices);
            var otherNoteChoices = noteChoiceGenerator.GetNoteChoices(chosenVoices);

            // assert
            _mockVoiceNoteChoiceRepository.ReceivedWithAnyArgs(chosenVoices.Count).GetVoiceNoteChoices(default);
            noteChoices.Should().OnlyHaveUniqueItems();
            noteChoices.Should().HaveCount(expectedNoteChoiceCount);
            otherNoteChoices.Should().BeSubsetOf(noteChoices);
        }

        [Test]
        public void NoteChoiceGenerator_Generates_Valid_Note_Choice_Indices()
        {
            // arrange
            var chosenVoices = new HashSet<Voice> { Voice.Melody, Voice.Harmony, Voice.Bass };
            var noteChoiceGenerator = new NoteChoiceGenerator(_mockVoiceNoteChoiceRepository);

            // act
            var noteChoices = noteChoiceGenerator.GetNoteChoices(chosenVoices);
            var noteChoiceIndices = noteChoiceGenerator.GetNoteChoiceIndices();

            // assert
            noteChoiceIndices.Values.Should().OnlyHaveUniqueItems();

            foreach (var noteChoice in noteChoices)
            {
                noteChoiceIndices.Should().ContainKey(noteChoice);
            }
        }

        private static readonly IDictionary<Voice, ISet<VoiceNoteChoice>> MockVoiceNoteChoicesByVoice =
            new Dictionary<Voice, ISet<VoiceNoteChoice>>
            {
                {
                    Voice.Melody, new HashSet<VoiceNoteChoice>
                    {
                        new(Voice.Melody, NoteMotion.Ascending, 5),
                        new(Voice.Melody, NoteMotion.Descending, 5),
                        new(Voice.Melody, NoteMotion.Oblique, 0)
                    }
                },
                {
                    Voice.Harmony, new HashSet<VoiceNoteChoice>
                    {
                        new(Voice.Harmony, NoteMotion.Ascending, 4),
                        new(Voice.Harmony, NoteMotion.Descending, 4),
                        new(Voice.Harmony, NoteMotion.Oblique, 0)
                    }
                },
                {
                    Voice.Bass, new HashSet<VoiceNoteChoice>
                    {
                        new(Voice.Bass, NoteMotion.Ascending, 3),
                        new(Voice.Bass, NoteMotion.Descending, 3),
                        new(Voice.Bass, NoteMotion.Oblique, 0)
                    }
                }
            };

        public static IEnumerable<TestCaseData> VoiceSetTestCases
        {
            get
            {
                yield return new TestCaseData(new HashSet<Voice> { Voice.Melody }, 3);
                yield return new TestCaseData(new HashSet<Voice> { Voice.Melody, Voice.Harmony }, 9);
                yield return new TestCaseData(new HashSet<Voice> { Voice.Melody, Voice.Harmony, Voice.Bass }, 27);
            }
        }
    }
}