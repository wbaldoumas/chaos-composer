using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Atrea.Extensions;
using ChaosComposer.Engine.Enums;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    public class NoteChoiceGenerator : INoteChoiceGenerator
    {
        private readonly ConcurrentDictionary<INoteChoice, int> _noteChoiceIndices = new();
        private readonly List<INoteChoice> _noteChoices = new();
        private readonly IVoiceNoteChoiceRepository _voiceNoteChoiceRepository;

        public NoteChoiceGenerator(IVoiceNoteChoiceRepository voiceNoteChoiceRepository) =>
            _voiceNoteChoiceRepository = voiceNoteChoiceRepository;

        public IReadOnlyList<INoteChoice> GetNoteChoices(ISet<Voice> voices)
        {
            if (_noteChoices.Count > 0)
            {
                return _noteChoices;
            }

            var noteChoices = new HashSet<INoteChoice>();

            noteChoices.UnionWith(
                voices
                    .Select(voice => _voiceNoteChoiceRepository.GetVoiceNoteChoices(voice))
                    .CartesianProduct()
                    .Select(voiceNoteChoices => new NoteChoice(voiceNoteChoices.ToHashSet()))
            );

            _noteChoices.AddRange(noteChoices.ToList());

            InitializeNoteChoiceIndices();

            return _noteChoices;
        }

        public IDictionary<INoteChoice, int> GetNoteChoiceIndices()
        {
            if (_noteChoices.Count == 0)
            {
                throw new InvalidOperationException("Note choices must be generated before attempting to retrieve their indices!");
            }

            return _noteChoiceIndices;
        }

        private void InitializeNoteChoiceIndices()
        {
            _noteChoices.ForEachWithIndex((noteChoice, index) => { _noteChoiceIndices.TryAdd(noteChoice, index); });
        }
    }
}