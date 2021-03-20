using ChaosComposer.Engine.Enums;
using System.Collections.Generic;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    /// <summary>
    ///     Represents a class which can generate <see cref="VoiceNoteChoice"/>s
    /// </summary>
    public interface IVoiceNoteChoiceGenerator
    {
        /// <summary>
        ///     Generate and return a <see cref="IEnumerable{T}"/> of <see cref="VoiceNoteChoice"/>s
        /// </summary>
        /// <param name="voice">The <see cref="Voice"/> to generate <see cref="VoiceNoteChoice"/>s for</param>
        /// <returns>A <see cref="IEnumerable{T}"/> of <see cref="VoiceNoteChoice"/>s</returns>
        IEnumerable<VoiceNoteChoice> GenerateVoiceNoteChoices(Voice voice);
    }
}