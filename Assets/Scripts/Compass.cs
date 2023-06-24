using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{

    public RawImage compassDirection;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        compassDirection.uvRect = new Rect(player.eulerAngles.y / 360f, 0f, 1f, 1f);
    }
}
