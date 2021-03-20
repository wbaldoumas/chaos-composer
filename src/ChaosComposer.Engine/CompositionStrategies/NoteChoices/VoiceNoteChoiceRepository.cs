using System.Collections.Generic;
using Atrea.Utilities.Enums;
using ChaosComposer.Engine.Enums;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    public class VoiceNoteChoiceRepository : IVoiceNoteChoiceRepository
    {
        private readonly IVoiceNoteChoiceGenerator _voiceNoteChoiceGenerator;

        private readonly IDictionary<Voice, ISet<VoiceNoteChoice>> _voiceNoteChoicesByVoice = new Dictionary<Voice, ISet<VoiceNoteChoice>>();

        public VoiceNoteChoiceRepository(IVoiceNoteChoiceGenerator voiceNoteChoiceGenerator)
        {
            _voiceNoteChoiceGenerator = voiceNoteChoiceGenerator;

            foreach (var voice in EnumUtils<Voice>.AsEnumerable())
            {
                _voiceNoteChoicesByVoice.Add(voice, new HashSet<VoiceNoteChoice>());
            }
        }

        public ISet<VoiceNoteChoice> GetVoiceNoteChoices(Voice voice)
        {
            if (_voiceNoteChoicesByVoice[voice].Count > 0)
            {
                return _voiceNoteChoicesByVoice[voice];
            }

            _voiceNoteChoicesByVoice[voice].UnionWith(_voiceNoteChoiceGenerator.GenerateVoiceNoteChoices(voice));

            return _voiceNoteChoicesByVoice[voice];
        }
    }
}