void Start()
{
    SpeechController = this.GetComponent<SpeechController>();

    SpeechController.Welcome();

    UIController = this.GetComponent<UIController>();

    WorldCursor = this.GetComponent<WorldCursor>();

    CurrentCube = YellowCube;

    CreateKeyWords();


    // Tell the KeywordRecognizer about our keywords.
    keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

    // Register a callback for the KeywordRecognizer and start recognizing!
    keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
    keywordRecognizer.Start();


    _recognizer = new GestureRecognizer();
    _recognizer.TappedEvent += (source, tapCount, ray) =>
    {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            if (Remove)
            {
                if (hitInfo.transform.gameObject.tag == "cube")
                {
                Destroy(hitInfo.transform.gameObject);    
                SpeechController.CubeRemoved();
                }
            }
            else
            {
                Instantiate(CurrentCube, hitInfo.point, Quaternion.identity);
                SpeechController.CubeSet();
            }
        }
        
    };
    
    _recognizer.StartCapturingGestures();
}