using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorCheck : MonoBehaviour
{
    public GameObject player;
    public string itemNeededToOpen;

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        if (player.GetComponent<MiniInventory>().isGot(itemNeededToOpen))
        {
            Destroy(gameObject);
        }
    }
}
