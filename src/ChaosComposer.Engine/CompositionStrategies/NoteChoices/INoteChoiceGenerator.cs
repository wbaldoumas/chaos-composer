using System.Collections.Generic;
using ChaosComposer.Engine.Enums;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    public interface INoteChoiceGenerator
    {
        IReadOnlyList<INoteChoice> GetNoteChoices(ISet<Voice> voices);

        IDictionary<INoteChoice, int> GetNoteChoiceIndices();
    }
}