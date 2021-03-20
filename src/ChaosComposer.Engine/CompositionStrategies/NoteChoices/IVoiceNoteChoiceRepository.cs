using System.Collections.Generic;
using ChaosComposer.Engine.Enums;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    /// <summary>
    ///     Represents a data store of <see cref="VoiceNoteChoice"/>s
    /// </summary>
    public interface IVoiceNoteChoiceRepository
    {
        /// <summary>
        ///     Retrieve the <see cref="VoiceNoteChoice"/>s for the given <see cref="Voice"/>
        /// </summary>
        /// <param name="voice">The given <see cref="Voice"/> to retrieve <see cref="VoiceNoteChoice"/>s for</param>
        /// <returns>A <see cref="ISet{T}"/> of <see cref="VoiceNoteChoice"/>s</returns>
        ISet<VoiceNoteChoice> GetVoiceNoteChoices(Voice voice);
    }
}