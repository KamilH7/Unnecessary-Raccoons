using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    bool followPlayer = true;

    [SerializeField]
    GameObject player;
    [SerializeField]
    Vector2 clampX;

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            transform.position = new Vector3(Mathf.Clamp(player.transform.position.x,clampX.x,clampX.y),transform.position.y,transform.position.z);
        }
    }
}
