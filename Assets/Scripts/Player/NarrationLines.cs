using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioSystem;
public class NarrationLines : MonoBehaviour
{
    [Header("Audio Names")]
    public AudioManager narratorManager;

    public string enemyNearbyAudio;
    AudioPiece[] enemyNearbyHub;

    public string randomPointInMapAudio;
    AudioPiece[] randomPointInMapHub;

    public string nearExitAudio;
    AudioPiece[] nearExitHub;

    public string startOfGameAudio;
    AudioPiece[] startOfGameHub;

    [Header("RandomOnMap Settings")]
    [Tooltip("The minimum time between random lines occuring")]
    public float timeBetweenMin;
    [Tooltip("The max time between random lines occuring")]
    public float timeBetweenMax;

    [Header("EnemyNearby Settings")]
    [SerializeField]
    [Tooltip("The enemy within the game world")]
    private GameObject enemy;
    [Tooltip("The distance the monster has to be from the player in order for the narrator to say something")]
    public float monsterDistance;
    [Tooltip("The duration before the narrator can speak about the monster being nearby again")]
    public float duration;

    [Header("NearExit Settings")]
    [SerializeField]
    [Tooltip("The exit trigger")]
    private GameObject exitTrigger;
    [Tooltip("The distance the exit trigger has to be from the player in order for the narrator to say something")]
    public float exitDistance;

    [Header("Enemy Settings")]
    [Tooltip("The EnemyAI script")]
    public EnemyAI enemyAI;

    //PRIVATE VARIABLES
    private bool enemySpokenNearby, exitSpokenNearby, narratorSpeaking;
    private float enemyTime, exitTime;

    
    // Start is called before the first frame update
    void Start()
    {
        startOfGameHub = narratorManager.GetHub(startOfGameAudio);
        nearExitHub = narratorManager.GetHub(nearExitAudio);
        randomPointInMapHub = narratorManager.GetHub(randomPointInMapAudio);
        enemyNearbyHub = narratorManager.GetHub(nearExitAudio);

        if (startOfGameHub != null)
        {
            narratorManager.PlayHub(startOfGameHub);
        }

        StartCoroutine(Narration(Random.Range(timeBetweenMin, timeBetweenMax)));

    }

    // Update is called once per frame
    void Update()
    {
        EnemyNearby();
        //RandomPointInMap();
        NearExit();
    }

    /// <summary>
    ///     Narrators triggering when the monster is nearby
    /// </summary>
    void EnemyNearby()
    {
        if (Vector3.Distance(transform.position, enemy.transform.position) < monsterDistance)
        {
            if (!enemySpokenNearby)
            {
                //TODO: Random Chance the playing of audio nearby
                narratorManager.Play(narratorManager.GetRandomPiece(enemyNearbyHub));
                
                enemySpokenNearby = true;
            }
            enemyTime = 0;
        }

        else if (Vector3.Distance(transform.position, enemy.transform.position) > monsterDistance)
        {
            //Handmade coroutine which waits for a certain amount of time before the narrator speaks of the monster being nearby
            if (enemyTime < duration)
            {
                enemyTime += Time.deltaTime;
            }
            else
            {
                enemySpokenNearby = false;
                enemyTime = 0;
            }
        }
    }

    /// <summary>
    ///     When near the exit play audio
    /// </summary>
    void NearExit()
    {
        if (Vector3.Distance(transform.position, exitTrigger.transform.position) < exitDistance)
        {
            if (!exitSpokenNearby)
            {
                //TODO: Random Chance the playing of audio nearby
                if (nearExitAudio != null)
                {
                    narratorManager.Play(narratorManager.GetRandomPiece(nearExitHub));
                }
                exitSpokenNearby = true;
            }
            enemyTime = 0;
        }

        else if (Vector3.Distance(transform.position, exitTrigger.transform.position) > exitDistance)
        {
            //Handmade coroutine which waits for a certain amount of time before the narrator speaks of the monster being nearby
            if (exitTime < duration)
            {
                exitTime += Time.deltaTime;
            }
            else
            {
                exitSpokenNearby = false;
                exitTime = 0;
            }
        }
    }

    public IEnumerator Narration (float durationUntilNext)
    {
        Debug.Log(durationUntilNext);
        float time = 0;

        while (time < durationUntilNext)
        {
            time += Time.deltaTime;
            yield return null;
        }

        if (enemyAI.state != EnemyAI.State.ChaseTarget)
        {
            if (randomPointInMapHub != null)
            {
                narratorManager.Play(narratorManager.GetRandomPiece(randomPointInMapHub));
            }
        }
        
        StartCoroutine(Narration(Random.Range(timeBetweenMin, timeBetweenMax)));
    }
}
