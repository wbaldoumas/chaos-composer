using System;
using System.Collections.Generic;
using ChaosComposer.Engine.Enums;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    public interface INoteChoice : IEquatable<INoteChoice>
    {
        ISet<VoiceNoteChoice> VoiceNoteChoices { get; }

        VoiceNoteChoice GetVoiceNoteChoice(Voice voice);
    }
}