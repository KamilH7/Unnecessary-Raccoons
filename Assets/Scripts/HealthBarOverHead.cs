using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarOverHead : MonoBehaviour
{
    [SerializeField]
    private Health hp;

    Vector3 localScale;
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = hp.HealthActual*2;
        transform.localScale = localScale;
    }
}
