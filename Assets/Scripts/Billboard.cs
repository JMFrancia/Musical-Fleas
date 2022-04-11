using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Makes object face camera at all times */
[ExecuteAlways]
public class Billboard : MonoBehaviour
{
    void Update()
    {
        transform.forward = Camera.main.transform.forward * -1;
    }
}
