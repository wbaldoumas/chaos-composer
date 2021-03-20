using System;
using System.Collections.Generic;
using ChaosComposer.Engine.Enums;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    /// <summary>
    ///     Represents a set of <see cref="VoiceNoteChoice"/>s which indicate how the composition
    ///     should progress from it's current state.
    /// </summary>
    public interface INoteChoice : IEquatable<INoteChoice>
    {
        /// <summary>
        ///     The set of <see cref="VoiceNoteChoice"/>s
        /// </summary>
        ISet<VoiceNoteChoice> VoiceNoteChoices { get; }

        /// <summary>
        ///     Retrieve a <see cref="VoiceNoteChoice"/> for the given <see cref="Voice"/>
        /// </summary>
        /// <param name="voice">The given <see cref="Voice"/> to retrieve the <see cref="VoiceNoteChoice"/> for</param>
        /// <returns>A <see cref="VoiceNoteChoice"/>, indicating how a given <see cref="Voice"/> should progress from its current state</returns>
        VoiceNoteChoice GetVoiceNoteChoice(Voice voice);
    }
}