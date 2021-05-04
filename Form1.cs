using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using System.Globalization;

namespace Assistant_Virtual {
    public partial class Form1 : Form {

        private SpeechRecognitionEngine engine;
        private CultureInfo ci;
        public string NAME_ASSISTANT = "Assistent01";

        public Form1() {
            InitializeComponent();
            Init();
        }
        
        private void Init() {
            try {
                ci = new CultureInfo("pt_BR");
                engine = new SpeechRecognitionEngine(ci);
                
                SpeechRec();
            }
            catch (Exception e) {

                MessageBox.Show(e.Message, "Error in Init()");
            }
        }

        private List<Grammar> Load_Grammar() {
            List<Grammar> grammar_Speak = new List<Grammar>();

            #region Choices
            Choices commands_System = new Choices();
            commands_System.Add(Grammar_pt_BR.Hours.ToArray());
            #endregion
            #region GrammarBuilder
            GrammarBuilder commands_System_gb = new GrammarBuilder();
            commands_System_gb.Culture = ci;
            commands_System_gb.Append(commands_System);
            #endregion
            #region Grammar
            Grammar grammar_System = new Grammar(commands_System_gb);
            grammar_System.Name = "system";
            #endregion

            grammar_Speak.Add(grammar_System);

            return grammar_Speak;
        }
        private void SpeechRec() {
            try {
                List<Grammar> g = Load_Grammar();

                #region Speech Recognition Events
                engine.SetInputToDefaultAudioDevice();

                foreach(Grammar gr in g) {
                    engine.LoadGrammar(gr);
                }

                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Rec);
                engine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(AudioLevel);
                engine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(Rejected);

                #endregion

                engine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception e) {

                MessageBox.Show(e.Message, "Erro em Speech()");
            }
        }
        private void Rec(object s, SpeechRecognizedEventArgs e) {

        }
        private void AudioLevel(object s,AudioLevelUpdatedEventArgs e) {
            if(e.AudioLevel > Bar_Audio.Maximum) {
                Bar_Audio.Value = Bar_Audio.Maximum;
            }
            else if(e.AudioLevel < Bar_Audio.Minimum){
                Bar_Audio.Value = Bar_Audio.Minimum;
            }
            else {
                Bar_Audio.Value = e.AudioLevel;
            }
        }
        private void Rejected(object s, SpeechRecognitionRejectedEventArgs e) {

        }
    }
}
