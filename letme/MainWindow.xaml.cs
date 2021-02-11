using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace letme
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));

        SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        Choices list = new Choices();

        public MainWindow()
        {
            // Configure the audio output.   
            synthesizer.SetOutputToDefaultAudioDevice();

            //list.Add(new String[] { "hello", "good" });

            //Grammar gr = new Grammar(new GrammarBuilder(list));

            recognizer.RequestRecognizerUpdate();

            // Create and load a dictation grammar. 
            recognizer.LoadGrammar(new DictationGrammar());

            // Add a handler for the speech recognized event.  
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

            // Configure input to the speech recognizer.  
            recognizer.SetInputToDefaultAudioDevice();

            // Start asynchronous, continuous speech recognition.  
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

            InitializeComponent();
        }

        // Handle the SpeechRecognized event.  
        public void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string input = e.Result.Text.ToLower();

            textbox.Text += "Recognized text: " + input + "\n";

            if(input == "hello")
            {
                synthesizer.Speak("hello, sir");
            }
        }
    }
}  