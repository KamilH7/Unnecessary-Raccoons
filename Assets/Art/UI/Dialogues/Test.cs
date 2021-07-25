using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    bool animating = true;

    private void Start()
    {
        StartCoroutine(AnimateCharacter());
    }

    IEnumerator AnimateCharacter()
    {
        while (animating)
        {
            Debug.Log("Animating");
            yield return new WaitForSeconds(0.2f);
        }
    }
}
