using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;
using System.Collections.ObjectModel;

namespace KomMee
{
    public class TextToSpeech
    {
        private SpeechSynthesizer synthesizer = null;
        private static TextToSpeech instance = null;

        private TextToSpeech()
        {
            this.synthesizer = new SpeechSynthesizer();
            this.synthesizer.SetOutputToDefaultAudioDevice();
            this.synthesizer.Rate = 1;
            this.synthesizer.Volume = 100;
            bool voiceFound = false;

            ReadOnlyCollection<InstalledVoice> voices = this.synthesizer.GetInstalledVoices();
            if (voices.Count > 0)
            {
                foreach (InstalledVoice voice in voices)
                {
                    if (voice.VoiceInfo.Culture.LCID == 1031)
                    {
                        this.synthesizer.SelectVoice(voice.VoiceInfo.Name);
                        voiceFound = true;
                        break;
                    }
                }
                if (!voiceFound)
                    this.synthesizer.SelectVoice(voices[0].VoiceInfo.Name);
            }
        }

        public static TextToSpeech getInstance()
        {
            if (TextToSpeech.instance == null)
                TextToSpeech.instance = new TextToSpeech();
            return TextToSpeech.instance;
        }

        public void speak(string text)
        {
            this.synthesizer.SpeakAsync(text);
        }
    }
}
