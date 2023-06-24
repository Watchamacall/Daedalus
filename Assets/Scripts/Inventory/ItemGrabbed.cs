using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemGrabbed : MonoBehaviour
{
    [Tooltip("The player GameObject")]
    public GameObject player;
    [Tooltip("The name of the item")]
    public string itemName;
    [Tooltip("The name of the AudioManager dealing with misc audio")]
    public AudioManager manager;
    [Tooltip("The AudioHub name of the audio to play")]
    public string itemGrabbedHub;
    [Tooltip("The enemy GameObject")]
    public GameObject enemy;
    [Tooltip("The Empty to teleport the enemy to once object is picked up")]
    public GameObject teleportEmpty;

    public void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<MiniInventory>().AddItem(gameObject.name);
            //manager.Play(manager.GetRandomPiece(manager.GetHub(itemGrabbedHub)));

            enemy.transform.position = teleportEmpty.transform.position;
            enemy.GetComponent<EnemyAI>().state = EnemyAI.State.ChaseTarget;

            Destroy(gameObject);
        }
    }
}
