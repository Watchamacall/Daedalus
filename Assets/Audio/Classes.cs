using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioSystem
{
    //----------AUDIO HUB---------
    [System.Serializable]
    [SerializeField]
    public class AudioHub
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public bool opened;
        [SerializeField]
        public AudioPiece[] audioPieces;

        public AudioHub()
        {
            
        }
    }


    //---------AUDIO PIECE---------
    [System.Serializable]
    [SerializeField]
    public class AudioPiece
    {
        public AudioPiece()
        {

        }

        //GET SET
        [SerializeField]
        public string name;
        [SerializeField]
        public string description;
        [SerializeField]
        public int priority;
        [SerializeField]
        public AudioClip clip;
        [SerializeField]
        public bool opened;
        [SerializeField]
        public bool audioOpened;
        [SerializeField]
        public GameObject sourcePlacement;
        [SerializeField]
        public AudioSource source;
    }
}
