using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField]
    GameObject[] ActivateOnOpen;
    [SerializeField]
    GameObject[] DeactivateOnOpen;
    [SerializeField]
    GameObject[] ActivateOnClose;
    [SerializeField]
    GameObject[] DeactivateOnClose;

    public void SettingsButton()
    {
        Activate(ActivateOnOpen);
        Deactivate(DeactivateOnOpen);
    }

    public void BackButton()
    {
        Activate(ActivateOnClose);
        Deactivate(DeactivateOnClose);
    }

    public void MusicCheckboxChecked(bool value)
    {
        Debug.Log(value);
    }

    public void VolumeSliderValueChanged(float value)
    {
        Debug.Log(value);
    }

    public void FullscreenCheckboxChecked(bool value)
    {
        Debug.Log(value);
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
