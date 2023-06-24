using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using AudioSystem;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(AudioManager))]
[CanEditMultipleObjects]
public class AudioManagerEditor : Editor
{
    AudioManager manager;

    private void OnEnable()
    {
        manager = (AudioManager)target;

        if (manager.audioHub == null)
        {
            manager.audioHub = new AudioHub[0];
        }
    }



    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        //ADD IN OUTER RANGE
        if (GUILayout.Button("Add New Audio Hub"))
        {
            Array.Resize(ref manager.audioHub, manager.audioHub.Length + 1);

            manager.audioHub[manager.audioHub.Length - 1] = new AudioHub();

            if (manager.audioHub[manager.audioHub.Length - 1].audioPieces == null)
            {
                manager.audioHub[manager.audioHub.Length - 1].audioPieces = new AudioPiece[0];
            }

            

        }

        //DECREASE IN OUTER RANGE
        if (manager.audioHub.Length != 0)
        {
            if (GUILayout.Button("Remove Recent Audio Hub"))
            {
                if (manager.audioHub.Length > 0)
                {
                    
                    AudioHub tempHub = manager.audioHub[manager.audioHub.Length - 1]; //Gets the last AudioHub in array

                    //Iterates through and destorys any AudioSources that might live (saves sifting through each time)
                    for (int i = 0; i < tempHub.audioPieces.Length; i++)
                    {
                        AudioSource source = tempHub.audioPieces[i].source;

                        if (source != null)
                        {
                            manager.RemoveAudioSource(source);
                        }
                    }
                    
                    Array.Resize(ref manager.audioHub, manager.audioHub.Length - 1); //Resizes the array
                }
            }
        }

        GUILayout.EndHorizontal();

        //Start going through outer area of array
        for (int i = 0; i < manager.audioHub.Length; i++)
        {
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();

            bool beginHori = true;

            GUILayout.BeginVertical();



            if (manager.audioHub[i].name == null || manager.audioHub[i].name == "")
            {
                manager.audioHub[i].opened = EditorGUILayout.Foldout(manager.audioHub[i].opened, $"Hub {i}"); //Set a foldout allowing for it to be collapsed
            }
            else
            {
                manager.audioHub[i].opened = EditorGUILayout.Foldout(manager.audioHub[i].opened, manager.audioHub[i].name); //Set a foldout allowing for it to be collapsed
            }

            GUILayout.EndVertical();


            if (manager.audioHub[i].opened) // If it is opened
            {

                EditorGUI.indentLevel++; //Indent in the inspector

                AudioPiece[] openedAudioPieces = manager.audioHub[i].audioPieces;

                //Inner Button ADD
                if (GUILayout.Button("Add New Audio Piece", EditorStyles.miniButtonRight))
                {
                    Array.Resize(ref openedAudioPieces, openedAudioPieces.Length + 1);

                    openedAudioPieces[openedAudioPieces.Length - 1] = new AudioPiece();

                }

                //Inner Button REMOVE
                if (manager.audioHub[i].audioPieces.Length != 0)
                {
                    if (GUILayout.Button("Remove Recent Audio Piece", EditorStyles.miniButtonRight))
                    {
                        if (manager.audioHub[i].audioPieces.Length > 0)
                        {
                            AudioPiece lastPiece = manager.audioHub[i].audioPieces[manager.audioHub[i].audioPieces.Length - 1];

                            if (lastPiece.source != null)
                            {
                                manager.RemoveAudioSource(lastPiece);
                            }
                            
                            Array.Resize(ref openedAudioPieces, openedAudioPieces.Length - 1);

                        }
                    }
                }



                if (beginHori)
                {
                    GUILayout.EndHorizontal();
                    beginHori = false;
                }

                GUILayout.BeginHorizontal();

                EditorGUILayout.PrefixLabel("Name: ");
                manager.audioHub[i].name = EditorGUILayout.TextField(manager.audioHub[i].name);

                GUILayout.EndHorizontal();

                //Goes through each array element in openDialoguePieces
                for (int j = 0; j < openedAudioPieces.Length; j++)
                {
                    GUILayout.Space(10);
                    GUILayout.BeginVertical();

                    EditorGUI.indentLevel++;

                    //Checking the Foldout for the particular DialoguePieces[j]
                    if (openedAudioPieces[j].name == null || openedAudioPieces[j].name == "")
                    {
                        openedAudioPieces[j].opened = EditorGUILayout.Foldout(openedAudioPieces[j].opened, $"Audio {j}"); //Set a foldout allowing for it to be collapsed
                    }
                    else
                    {
                        openedAudioPieces[j].opened = EditorGUILayout.Foldout(openedAudioPieces[j].opened, openedAudioPieces[j].name); //Set a foldout allowing for it to be collapsed
                    }

                    //If the Foldout is opened
                    if (openedAudioPieces[j].opened)
                    {
                        //NAME
                        GUILayout.BeginHorizontal();

                        EditorGUILayout.PrefixLabel("Name: ");
                        openedAudioPieces[j].name = GUILayout.TextField(openedAudioPieces[j].name);

                        GUILayout.EndHorizontal();

                        //DESCRIPTION
                        GUILayout.BeginHorizontal();

                        EditorGUILayout.PrefixLabel("Desc: ");
                        openedAudioPieces[j].description = GUILayout.TextArea(openedAudioPieces[j].description);

                        GUILayout.EndHorizontal();

                        //PRIORITY
                        GUILayout.BeginHorizontal();

                        openedAudioPieces[j].priority = EditorGUILayout.IntField("Priority:", openedAudioPieces[j].priority);

                        GUILayout.EndHorizontal();

                        //AUDIOCLIP
                        GUILayout.BeginHorizontal();

                        openedAudioPieces[j].clip = (AudioClip)EditorGUILayout.ObjectField("AudioClip:", openedAudioPieces[j].clip, typeof(AudioClip), true);

                        GUILayout.EndHorizontal();

                        //SOURCEPLACEMENT
                        GUILayout.BeginHorizontal();

                        openedAudioPieces[j].sourcePlacement = (GameObject)EditorGUILayout.ObjectField("SourcePlacement:", openedAudioPieces[j].sourcePlacement, typeof(GameObject), true);

                        GUILayout.EndHorizontal();


                        GUILayout.BeginHorizontal();
                        bool audioSourceOpen = true;
                        if (openedAudioPieces[j].source == null)
                        {
                            if (GUILayout.Button("Add AudioSource"))
                            {
                                manager.PlaceAudioSource(openedAudioPieces[j]);
                            }
                        }
                        else
                        {

                            openedAudioPieces[j].audioOpened = EditorGUILayout.Foldout(openedAudioPieces[j].audioOpened, "AudioSource"); //Set a foldout allowing for it to be collapsed

                            if (openedAudioPieces[j].audioOpened)
                            {
                                GUILayout.EndHorizontal();
                                audioSourceOpen = false;

                                //AUDIO SOURCE PLACEMENT
                                GUILayout.BeginVertical();

                                AudioSource tempSource = openedAudioPieces[j].source;

                                tempSource.outputAudioMixerGroup = (UnityEngine.Audio.AudioMixerGroup)EditorGUILayout.ObjectField("Output", tempSource.outputAudioMixerGroup, typeof(UnityEngine.Audio.AudioMixerGroup), true);


                                tempSource.mute = GUILayout.Toggle(tempSource.mute, "Mute");

                                tempSource.bypassEffects = GUILayout.Toggle(tempSource.bypassEffects, "Bypass Effects");

                                tempSource.bypassListenerEffects = GUILayout.Toggle(tempSource.bypassListenerEffects, "Bypass Listener Effects");

                                tempSource.bypassReverbZones = GUILayout.Toggle(tempSource.bypassReverbZones, "Bypass Reverb Zones");

                                tempSource.playOnAwake = GUILayout.Toggle(tempSource.playOnAwake, "Play On Awake");

                                tempSource.loop = GUILayout.Toggle(tempSource.loop, "Loop");

                                EditorGUILayout.IntSlider("Priority", tempSource.priority, 0, 256);

                                EditorGUILayout.Slider("Volume", tempSource.volume, 0.0f, 1.0f);

                                EditorGUILayout.Slider("Pitch", tempSource.pitch, -3.0f, 3.0f);

                                EditorGUILayout.Slider("Stereo Pan", tempSource.panStereo, -1.0f, 1.0f);

                                EditorGUILayout.Slider("Spatial Blend", tempSource.spatialBlend, 0.0f, 1.0f);

                                EditorGUILayout.Slider("Reverb Zone Mix", tempSource.reverbZoneMix, 0.0f, 1.1f);

                                GUILayout.EndVertical();
                            
                            }
                            //If the AudioSource is not open EndHorizontal
                            if (audioSourceOpen)
                            {
                                GUILayout.EndHorizontal();
                            }
                            
                            GUILayout.BeginHorizontal();

                            //BUTTONS (PLAY AUDIO / DELETE AUDIO SOURCE)
                            if (GUILayout.Button("Play Audio"))
                            {
                                openedAudioPieces[j].source.Play();
                            }
                            if (openedAudioPieces[j].source.clip != openedAudioPieces[j].clip || openedAudioPieces[j].sourcePlacement != openedAudioPieces[j].source.gameObject)
                            {
                                if (GUILayout.Button("Change AudioSource"))
                                {
                                    manager.ChangeAudioSource(openedAudioPieces[j]);
                                }
                            }
                            else
                            {
                                if (GUILayout.Button("Delete AudioSource"))
                                {
                                    manager.RemoveAudioSource(openedAudioPieces[j]);
                                }
                            }
                        }
                        GUILayout.EndHorizontal();
                    }
                    
                    EditorGUI.indentLevel--;

                    GUILayout.EndVertical();
                }

                manager.audioHub[i].audioPieces = openedAudioPieces;

                EditorGUI.indentLevel--;
            }

            if (beginHori)
            {
                GUILayout.EndHorizontal();
            }
        }
        //manager.audioHub = manager.audioHub;

        if (GUI.changed)
        {
            serializedObject.ApplyModifiedProperties();

            EditorUtility.SetDirty(manager);
            EditorSceneManager.MarkSceneDirty(manager.gameObject.scene);
        }
    }
    
}
