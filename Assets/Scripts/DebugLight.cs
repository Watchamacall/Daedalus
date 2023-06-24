using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLight : MonoBehaviour
{
    public Light lights;

    public void IncreaseLight()
    {
        lights.range = 100;
    }
}
