using ChaosComposer.Engine.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    public class VoiceNoteChoiceGenerator : IVoiceNoteChoiceGenerator
    {
        private const int MinimumPitchChangeDistance = 1;
        private const int MaximumPitchChangeDistance = 6;

        public IEnumerable<VoiceNoteChoice> GenerateVoiceNoteChoices(Voice voice)
        {
            var noteMotions = new List<NoteMotion> { NoteMotion.Ascending, NoteMotion.Descending };
            var pitchChanges = Enumerable.Range(
                MinimumPitchChangeDistance,
                MaximumPitchChangeDistance
            ).Select(pitchChange => (byte) pitchChange);

            var noteChoices = pitchChanges.SelectMany(
                pitchChange => noteMotions.Select(
                    noteMotion => new VoiceNoteChoice(voice, noteMotion, pitchChange)
                )
            ).Append(new VoiceNoteChoice(voice, NoteMotion.Oblique, 0));

            return noteChoices;
        }
    }
}