using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartScreen : MonoBehaviour
{
    public static bool GamePaused = false;
    public static bool GameStarted = false;

    Vector3 cameraStartPos;

    [SerializeField]
    Image DimPanel;
    [SerializeField]
    GameObject mainCamera;

    [SerializeField]
    GameObject[] DeactivateOnPause;
    [SerializeField]
    GameObject[] ActivateOnPause;
    [SerializeField]
    GameObject[] DeactivateOnUnpause;
    [SerializeField]
    GameObject[] ActivateOnUnpause;

    void Start()
    {
        Deactivate(DeactivateOnPause);
        cameraStartPos = mainCamera.transform.position;
        mainCamera.transform.position += Vector3.up * 175;
    }

    bool starting = false;

    void Update()
    {
        if (starting)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraStartPos , Time.deltaTime * 3);

            if (Mathf.Abs(mainCamera.transform.position.y - cameraStartPos.y) <= 1 || cameraStartPos.y < 0)
            {
                mainCamera.transform.position = cameraStartPos;
                starting = false;
                GameStart();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameStarted)
            {
                if (GamePaused)
                {
                    Unpause();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void GameStart()
    {
        GameStarted = true;
        DimPanel.color = new Color(DimPanel.color.r, DimPanel.color.g, DimPanel.color.b, 0.3f);
        Unpause();
    }


    public void Unpause()
    {
        Activate(ActivateOnUnpause);
        Deactivate(DeactivateOnUnpause);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause()
    {
        Activate(ActivateOnPause);
        Deactivate(DeactivateOnPause);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void StartButton()
    {
        if (!GameStarted)
        {
            Deactivate(DeactivateOnUnpause);
            starting = true;
        }
        else
        {
            Unpause();
        }
    }

    public void SettingsButton()
    {
        
    }

    public void QuitButton()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }


    void Activate(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }

    void Deactivate(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
