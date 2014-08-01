using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MenuScript : MonoBehaviour
{
    private GameObject scMainMenuGO;
    private GameObject scScoresGO;
    private GameObject levelInfo;
    private GameObject scGameLoadingGO;
    private float startTime;
    private float startGameTime = 0.0f;
    private float speed;
    private Vector3 V3_LEFT = new Vector3(-14f, 0.0f, 0.0f);
    private Vector3 V3_CENTER_INFO = new Vector3(0.0f, 0.0f, -5.0f);
    private Vector3 V3_RIGHT = new Vector3(14f, 0.0f, 0.0f);
    private Vector3 V3_CENTER = Vector3.zero;
    private Vector3 V3_DELTA = new Vector3(0.2f, 0.0f, 0.0f);

    void Start()
    {
        AppCore.Start();
        startTime = Time.time;
        speed = 3.2f;
        scMainMenuGO = GameObject.Find("Screen Main Menu");
        scScoresGO = GameObject.Find("Screen Scores");
        levelInfo = GameObject.Find("Level info");
        scGameLoadingGO = GameObject.Find("Screen Game Loading");
    }

    private void moveAndStopStopAtPosition(GameObject go, Vector3 expectedPosition)
    {
        go.rigidbody.velocity = Vector3.zero;
        go.rigidbody.transform.position = Vector3.Lerp(go.transform.position, expectedPosition, Time.fixedDeltaTime * speed);
        if (go.rigidbody.position.x >= (expectedPosition.x - V3_DELTA.x) && go.rigidbody.position.x <= (expectedPosition.x + V3_DELTA.x))
            go.rigidbody.velocity = Vector3.zero;
    }

    void Update()
    {
        LoadBackButtonEvents();
        switch (AppCore.CurrentStatus)
        {
            case AppCore.Status.SCORES:
                moveAndStopStopAtPosition(scScoresGO, V3_CENTER);
                moveAndStopStopAtPosition(scMainMenuGO, V3_LEFT);
                break;
            case AppCore.Status.MENU:
                if (GameObject.Find("ScoreRecordObject") == null)
                {
                    moveAndStopStopAtPosition(scMainMenuGO, V3_CENTER);
                    moveAndStopStopAtPosition(scScoresGO, V3_RIGHT);
                }
                moveAndStopStopAtPosition(levelInfo, V3_LEFT);
                break;

            case AppCore.Status.FAST_GAME:
                moveAndStopStopAtPosition(scMainMenuGO, V3_LEFT);
                moveAndStopStopAtPosition(scGameLoadingGO, V3_CENTER);
                LoadGame();
                break;

            case AppCore.Status.LOADING:
                if (Time.time > (startTime + 5) || Input.GetMouseButtonUp(0))
                {
                    if (GameObject.Find("Screen First Loading"))
                        MonoBehaviour.Destroy(GameObject.Find("Screen First Loading"));
                    AppCore.CurrentStatus = AppCore.Status.MENU;
                }
                break;
        }
    }


    private void LoadGame()
    {
        if (startGameTime == 0)
            startGameTime = Time.time;
        else
        {
            if (Time.time > (startGameTime + 3))
                Application.LoadLevel(1);
        }
    }


    private void LoadBackButtonEvents()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AppCore.BackButtonPress();
        }
    }
}