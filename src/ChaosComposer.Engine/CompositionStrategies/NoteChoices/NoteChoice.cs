using System;
using System.Collections.Generic;
using ChaosComposer.Engine.Enums;

namespace ChaosComposer.Engine.CompositionStrategies.NoteChoices
{
    public class NoteChoice : INoteChoice, IEquatable<NoteChoice>
    {
        private static readonly VoiceNoteChoice DefaultVoiceNoteChoice = new(
            Voice.Melody,
            NoteMotion.Oblique,
            byte.MaxValue
        );

        private IDictionary<Voice, VoiceNoteChoice> VoiceNoteChoicesByVoice { get; }

        public NoteChoice(ISet<VoiceNoteChoice> voiceNoteChoices)
        {
            VoiceNoteChoices = voiceNoteChoices ?? new HashSet<VoiceNoteChoice>();

            VoiceNoteChoicesByVoice = new Dictionary<Voice, VoiceNoteChoice>
            {
                { Voice.Melody, DefaultVoiceNoteChoice },
                { Voice.Harmony, DefaultVoiceNoteChoice },
                { Voice.Bass, DefaultVoiceNoteChoice }
            };

            foreach (var voiceNoteChoice in VoiceNoteChoices)
            {
                VoiceNoteChoicesByVoice[voiceNoteChoice.Voice] = voiceNoteChoice;
            }
        }

        public bool Equals(NoteChoice other) => Equals<NoteChoice>(other);

        public ISet<VoiceNoteChoice> VoiceNoteChoices { get; }

        public VoiceNoteChoice GetVoiceNoteChoice(Voice voice) => VoiceNoteChoicesByVoice[voice];

        public bool Equals(INoteChoice other) => Equals<INoteChoice>(other);

        private bool Equals<T>(T other) where T : INoteChoice
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(VoiceNoteChoices, other.VoiceNoteChoices))
            {
                return true;
            }

            return !(VoiceNoteChoices is null || other.VoiceNoteChoices is null) &&
                   VoiceNoteChoices.SetEquals(other.VoiceNoteChoices);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((NoteChoice)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = VoiceNoteChoicesByVoice[Voice.Melody].GetHashCode();

                hashCode = (hashCode * 397) ^ VoiceNoteChoicesByVoice[Voice.Harmony].GetHashCode();
                hashCode = (hashCode * 397) ^ VoiceNoteChoicesByVoice[Voice.Bass].GetHashCode();

                return hashCode;
            }
        }

        public static bool operator ==(NoteChoice left, NoteChoice right) => Equals(left, right);

        public static bool operator !=(NoteChoice left, NoteChoice right) => !Equals(left, right);
    }
}