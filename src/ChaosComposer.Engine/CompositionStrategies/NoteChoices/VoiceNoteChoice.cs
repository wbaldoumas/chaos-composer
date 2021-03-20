using ChaosComposer.Engine.Enums;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    public sealed record VoiceNoteChoice(Voice Voice, NoteMotion NoteMotion, byte PitchChange);
}