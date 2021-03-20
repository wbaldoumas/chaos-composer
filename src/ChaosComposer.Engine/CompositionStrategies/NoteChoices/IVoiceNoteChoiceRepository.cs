using System.Collections.Generic;
using ChaosComposer.Engine.Enums;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    public interface IVoiceNoteChoiceRepository
    {
        ISet<VoiceNoteChoice> GetVoiceNoteChoices(Voice voice);
    }
}