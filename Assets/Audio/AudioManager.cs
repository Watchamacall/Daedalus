using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioSystem;


    public class AudioManager : MonoBehaviour
    {
        #region Variables
        [HideInInspector]
        public AudioHub[] audioHub;

        [HideInInspector]
        AudioPiece currentlyPlaying;

        Coroutine routine;
    #endregion

        #region Awake
        private void Awake()
        {
            hideFlags = HideFlags.HideAndDontSave;

            foreach (var hub in audioHub)
            {
                foreach (var item in hub.audioPieces)
                {
                    PlaceAudioSource(item);
                }
            }
        }
        #endregion

        #region IsPrioritized
        /// <summary>
        ///     Checks if the priority of <paramref name="piece"/> is less than the currentlyPlayingSound
        /// </summary>
        /// <param name="piece">The piece you wish to play</param>
        /// <returns>true if <paramref name="piece"/>'s priority is bigger than the currently playing sound</returns>
        bool IsPrioritized(AudioPiece piece)
        {
            if (currentlyPlaying.priority < piece.priority)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Play
        /// <summary>
        ///     Plays the <paramref name="piece"/> if it has a higher priority than the currentlyPlaying audio
        /// </summary>
        /// <param name="piece">The audio you wish to play</param>
        public void Play(AudioPiece piece)
        {
            if (currentlyPlaying == null)
            {
                currentlyPlaying = piece;
                piece.source.Play();

                routine = StartCoroutine(AudioStop(piece.source.clip.length));
            }
            else
            {
                if (IsPrioritized(piece))
                {
                    currentlyPlaying.source.Stop();

                    currentlyPlaying = piece;
                    piece.source.Play();

                    routine = StartCoroutine(AudioStop(piece.source.clip.length));
                }
            }
        }
        /// <summary>
        ///     Plays the <paramref name="pieceName"/> if it has a higher priority than the currentlyPlaying audio
        /// </summary>
        /// <param name="pieceName">The name of the audio you wish to play</param>
        /// <param name="hubName">The name of the hub the <paramref name="pieceName"/> resides</param>
        public void Play(string hubName, string pieceName)
        {
            AudioPiece piece = GetPiece(hubName, pieceName);

            if (currentlyPlaying == null)
            {
                currentlyPlaying = piece;
                piece.source.Play();

                routine = StartCoroutine(AudioStop(piece.source.clip.length));
            }
            else
            {
                if (IsPrioritized(piece))
                {
                    currentlyPlaying.source.Stop();

                    currentlyPlaying = piece;
                    piece.source.Play();

                    routine = StartCoroutine(AudioStop(piece.source.clip.length));
                }
            }
        }
        /// <summary>
        ///     Plays the <paramref name="pieceName"/> if it has a higher priority than the currentlyPlaying audio
        /// </summary>
        /// <param name="pieceName">The name of the audio you wish to play</param>

        public void Play(string pieceName)
        {
            AudioPiece piece = GetPiece(pieceName);

            if (currentlyPlaying == null)
            {
                currentlyPlaying = piece;
                piece.source.Play();

                routine = StartCoroutine(AudioStop(piece.source.clip.length));
            }
            else
            {
                if (IsPrioritized(piece))
                {
                    currentlyPlaying.source.Stop();

                    currentlyPlaying = piece;
                    piece.source.Play();

                    routine = StartCoroutine(AudioStop(piece.source.clip.length));
                }
            }
        }
        #endregion

        #region PlayHub
        /// <summary>
        ///     Plays through <paramref name="hubName"/>'s AudioPieces
        /// </summary>
        /// <param name="hubName">The name of the hub you want to play</param>
        public void PlayHub(string hubName)
        {
            AudioPiece[] pieces = GetHub(hubName);

            StartCoroutine(PlayAudioPieces(pieces));
        }
        /// <summary>
        ///     Plays through <paramref name="hubName"/>'s AudioPieces
        /// </summary>
        /// <param name="hubName">The name of the hub you want to play</param>
        public void PlayHub(AudioPiece[] hub)
        {
            StartCoroutine(PlayAudioPieces(hub));
        }
        #endregion

        #region GetHub
        /// <summary>
        ///     Gets the hub corrisponding to the <paramref name="hubName"/>
        /// </summary>
        /// <param name="hubName">The name of the hub you wish to retrieve</param>
        /// <returns>The hub with the name <paramref name="hubName"/></returns>
        public AudioPiece[] GetHub(string hubName)
        {
            foreach (var item in audioHub)
            {
                if (item.name.ToUpper() == hubName.ToUpper())
                {
                    return item.audioPieces;
                }
            }
            return null;
        }
        #endregion

        #region GetPiece
        /// <summary>
        ///     Gets the piece of audio with the namer <paramref name="pieceName"/>
        /// </summary>
        /// <param name="hubName">The hub in which the <paramref name="pieceName"/> resides</param>
        /// <param name="pieceName">The name of the audio you wish to retrieve</param>
        /// <returns>The audio <paramref name="pieceName"/></returns>
        public AudioPiece GetPiece(string hubName, string pieceName)
        {
            AudioPiece[] pieces = GetHub(hubName);
            foreach (var item in pieces)
            {
                if (item.name.ToUpper() == pieceName.ToUpper())
                {
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        ///     Gets the piece of audio with the namer <paramref name="pieceName"/>
        /// </summary>
        /// <param name="pieceName">The name of the audio you wish to retrieve</param>
        /// <returns>The audio <paramref name="pieceName"/></returns>
        public AudioPiece GetPiece(string pieceName)
        {
            foreach (var item in audioHub)
            {
                for (int i = 0; i < item.audioPieces.Length; i++)
                {
                    if (item.audioPieces[i].name.ToUpper() == pieceName.ToUpper())
                    {
                        return item.audioPieces[i];
                    }
                }
            }
            return null;
        }
    #endregion

        #region GetRandomPiece
    /// <summary>
    ///     Gets a random AudioPiece from <paramref name="hub"/>
    /// </summary>
    /// <param name="hub">The hub to get the Random from</param>
    /// <returns>A random AudioPiece from <paramref name="hub"/></returns>
    public AudioPiece GetRandomPiece(AudioPiece[] hub)
    {
        return hub[UnityEngine.Random.Range(0, hub.Length)];
    }
    /// <summary>
    ///     Gets a random AudioPiece from <paramref name="hubName"/>
    /// </summary>
    /// <param name="hubName">The hub name to get the Random from</param>
    /// <returns>A random AudioPiece from <paramref name="hubName"/></returns>
    public AudioPiece GetRandomPiece(string hubName)
    {
        AudioPiece[] hub = GetHub(hubName);
        return hub[UnityEngine.Random.Range(0, hub.Length)];
    }
    #endregion

        #region PlaceAudioSource
    /// <summary>
    ///     Places the AudioSource based on the GameObject within <paramref name="piece"/>
    /// </summary>
    /// <param name="piece">The audio to place the AudioSource down on</param>
    public void PlaceAudioSource(AudioPiece piece)
        {
            if (piece.source == null)
            {
                if (piece.sourcePlacement == null)
                {
                    piece.sourcePlacement = this.gameObject;
                    piece.source = this.gameObject.AddComponent<AudioSource>();
                }
                else
                {
                    piece.source = piece.sourcePlacement.AddComponent<AudioSource>();
                }
                piece.source.clip = piece.clip;
                piece.source.playOnAwake = false;
            }
        }
        #endregion

        #region ChangeAudioSource
        /// <summary>
        ///     Changes the AudioSource of <paramref name="piece"/>
        /// </summary>
        /// <param name="piece">The object to be changed</param>
        public void ChangeAudioSource(AudioPiece piece)
        {
            RemoveAudioSource(piece);
            PlaceAudioSource(piece);
        }
        #endregion

        #region RemoveAudioSource
        /// <summary>
        ///     Removes the AudioSource based on the GameObjet within <paramref name="piece"/>
        /// </summary>
        /// <param name="piece">The audio to destroy the AudioSource on</param>
        public void RemoveAudioSource(AudioPiece piece)
        {
            var array = piece.source.GetComponents<AudioSource>();
            foreach (var item in array)
            {
                if (item.clip == piece.source.clip)
                {
                    DestroyImmediate(item);
                    break;
                }
            }
        }

        public void RemoveAudioSource(AudioSource source)
        {
            var array = source.gameObject.GetComponents<AudioSource>();
            foreach (var item in array)
            {
                if (item.clip == source.clip)
                {
                    DestroyImmediate(item);
                    break;
                }
            }
        }
        #endregion

        #region AudioStop IEnumerator
        /// <summary>
        ///     Waits for the length given in <paramref name="waitTime"/> and then sets currentlyPlaying to null
        /// </summary>
        /// <param name="waitTime">The time to wait</param>
        public IEnumerator AudioStop(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);

            currentlyPlaying = null;
        }
        #endregion

        #region PlayHub IEnumerator
        public IEnumerator PlayAudioPieces(AudioPiece[] pieces)
        {
            foreach (var item in pieces)
            {
                Play(item);
                while (currentlyPlaying != null)
                {
                    yield return null;
                }
            }
        }
        #endregion
    }