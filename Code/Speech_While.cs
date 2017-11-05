public void CubeSet()
{
    StartCoroutine(CubeSetSpeak());
}

private IEnumerator CubeSetSpeak()
{
    yield return new WaitWhile(() => textToSpeech.SpeechTextInQueue() || textToSpeech.IsSpeaking());
    if (firstBlockSet)
    {
        textToSpeech.StartSpeaking("Great! You can remove cubes by saying Remove Cubes!");
        firstBlockSet = false;
    }
}