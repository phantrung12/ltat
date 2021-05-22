using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace SoundProcess
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine listener = new SpeechRecognitionEngine();
        SpeechSynthesizer Tam = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(Object sender, EventArgs e)
        {
            listener.SetInputToDefaultAudioDevice();
            listener.LoadGrammar(new Grammar(new GrammarBuilder(new Choices("Hello", "Garden", "Kitchen"))));
            listener.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Speech_recognized);
        }

        private void Speech_recognized(object sender, SpeechRecognizedEventArgs e)
        {
            string s = e.Result.Text;
            switch (s)
            {
                case "Hello":
                    pictureBox1.Image = Image.FromFile(@"..\..\..\Pictures\Welcome.png");
                    break;
                case "Garden":
                    pictureBox1.Image = Image.FromFile(@"..\..\..\Pictures\Garden.png");
                    break;
                case "Kitchen":
                    pictureBox1.Image = Image.FromFile(@"..\..\..\Pictures\Kitchen.png");
                    break;
                default:
                    pictureBox1.Image = Image.FromFile(@"..\..\..\Pictures\Sorry.png");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listener.RecognizeAsync(RecognizeMode.Multiple);
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listener.RecognizeAsyncCancel();
            button1.Enabled = true;
            button2.Enabled = false;
            pictureBox1.Image = Image.FromFile(@"..\..\..\Pictures\Choice.png");
        }
    }
}
