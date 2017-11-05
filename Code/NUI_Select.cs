private void SelectYellowCube()
{
    CurrentCube = YellowCube;

    WorldCursor.SetCurrentCube(CurrentCube);

    UIController.CubeColor(Color.yellow);
    UIController.RemoveMode(false);

    SpeechController.CubeColorChanged();
}