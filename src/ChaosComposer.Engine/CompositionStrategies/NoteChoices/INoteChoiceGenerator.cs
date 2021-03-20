using System.Collections.Generic;
using ChaosComposer.Engine.Enums;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    /// <summary>
    ///     Represents a class that can generate a set of unique <see cref="INoteChoice"/>s.
    /// </summary>
    public interface INoteChoiceGenerator
    {
        /// <summary>
        ///     Generate a set of unique <see cref="INoteChoice"/>s
        /// </summary>
        /// <param name="voices">The <see cref="Voice"/>s for which to generate <see cref="INoteChoice"/>s for</param>
        /// <returns>A unique set of <see cref="INoteChoice"/> for the given <see cref="Voice"/>s</returns>
        IReadOnlyList<INoteChoice> GetNoteChoices(ISet<Voice> voices);

        /// <summary>
        ///     Retrieve a dictionary of <see cref="INoteChoice"/> to index
        /// </summary>
        /// <returns>A <see cref="IDictionary{TKey,TValue}"/> of <see cref="INoteChoice"/> to <see cref="int"/> index</returns>
        IDictionary<INoteChoice, int> GetNoteChoiceIndices();
    }
}