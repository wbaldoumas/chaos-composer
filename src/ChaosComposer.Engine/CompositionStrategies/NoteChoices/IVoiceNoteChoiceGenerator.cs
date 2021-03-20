using ChaosComposer.Engine.Enums;
using System.Collections.Generic;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    public interface IVoiceNoteChoiceGenerator
    {
        IEnumerable<VoiceNoteChoice> GenerateVoiceNoteChoices(Voice voice);
    }
}