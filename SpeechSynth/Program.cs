using System;
using System.Linq;
using System.Speech.Synthesis;
namespace ConsoleApplication1
{   class Program
	{
		static void Main(string[] args)
		{
			SpeechSynthesizer synthesizer = new SpeechSynthesizer();
			foreach(var v in synthesizer.GetInstalledVoices().
					Select(v => v.VoiceInfo))
				Console.WriteLine("Name:{0}, Gender:{1}, Age:{2}",
						v.Description, v.Gender, v.Age);
			// select male adult (if it exists)
			synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
			synthesizer.Volume = 100;  // (0 - 100)
			synthesizer.Rate = 0;     // (-10 - 10)
									  // select audio device
			synthesizer.SetOutputToDefaultAudioDevice();
			// build and speak a prompt
			PromptBuilder builder = new PromptBuilder();
			builder.AppendText("Hello George!");
			synthesizer.Speak(builder);
			//Female - Adult - Great Britain
			synthesizer.SelectVoice("Microsoft Hazel Desktop");
			synthesizer.Speak("Now I'm speaking.");
		}
	}
}
