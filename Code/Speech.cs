public void Welcome()
{
    textToSpeech = this.GetComponent<TextToSpeech>();
    textToSpeech.Voice = TextToSpeechVoice.Zira;
    textToSpeech.StartSpeaking("Welcome to the WorldBuilder. You can build what ever you like out of cubes only with your voice and gestures.");
}