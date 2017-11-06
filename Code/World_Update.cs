void Update()
{
    var headPosition = Camera.main.transform.position;
    var gazeDirection = Camera.main.transform.forward;

    RaycastHit hitInfo;

    if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
    {
        if (Remove)
        {
            CurrentCubeMeshRenderer.enabled = false;

            CursorMeshRenderer.enabled = true;

            Cursor.transform.position = hitInfo.point;

            Cursor.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            SpeechController.RemoveCubes();
        }
        else
        {
            loadingText.text = "";
            
            CurrentCubeMeshRenderer.enabled = true;
            CursorMeshRenderer.enabled = false;
            CurrentCube.transform.position = hitInfo.point;

            SpeechController.CubeCursor();
        }
    }
    else
    {
        loadingText.text = "Loading Room! \nPlease Wait ...";
        
        CurrentCubeMeshRenderer.enabled = false;
        CursorMeshRenderer.enabled = false;
    }
}