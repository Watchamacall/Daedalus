using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class GameObjectEditor : EditorWindow
{
    private float angle = 15;
    private bool rotateToggle = false;

    private GameObject replacement;
    private bool swapPosition = true;
    private bool swapRotation = true;
    private bool swapScale = true;
    private bool swapParent = true;
    private bool swapPrefabs = false;

    private bool snapToGroundToggle = false;

    //Display the window.
    [MenuItem("Tools/Game Object Editor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(GameObjectEditor), false, "Game Object Editor");
    }

    void OnEnable()
    {
        Selection.selectionChanged += Repaint;
    }

    void OnDisable()
    {
        Selection.selectionChanged -= Repaint;
    }

    public void OnGUI()
    {
        EditorGUILayout.LabelField("Game Object Editor");

        rotateToggle = EditorGUILayout.Foldout(rotateToggle, "Rotate");
        if (rotateToggle)
            Rotate();

        swapPrefabs = EditorGUILayout.Foldout(swapPrefabs, "Swap Prefabs");
        if (swapPrefabs)
            SwapAll();

        snapToGroundToggle = EditorGUILayout.Foldout(snapToGroundToggle, "Snap To Ground");
        if (snapToGroundToggle)
            SnapToGround();
    }

    private void SnapToGround()
    {
        if (Selection.gameObjects.Length != 0)
        {
            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            if (GUILayout.Button("up"))
                Snap(Vector3.up);
            EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("left"))
                Snap(Vector3.left);

            EditorGUILayout.BeginVertical();
            if (GUILayout.Button("forward"))
                Snap(Vector3.forward);
            if (GUILayout.Button("backward"))
                Snap(Vector3.back);
            EditorGUILayout.EndVertical();

            if (GUILayout.Button("right"))
                Snap(Vector3.right);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            if (GUILayout.Button("down"))
                Snap(Vector3.down);
            EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();
        }
        else
            EditorGUILayout.HelpBox("Select any objects in the scene to get started", MessageType.Info);
    }

    private void Snap(Vector3 dir)
    {
        GameObject[] allObjects = Selection.gameObjects;

        RaycastHit hit;
        for (int i = 0; i < allObjects.Length; i++)
        {
            if (Physics.Raycast(allObjects[i].transform.position, dir, out hit))
            {
                allObjects[i].transform.position = hit.point;
            }
            else
                Debug.Log("Failed to find surface to snap to.");
        }
    }

    private void SwapAll()
    {
        EditorGUILayout.BeginVertical("box");

        replacement = EditorGUILayout.ObjectField("Replacement", replacement, typeof(GameObject), false) as GameObject;

        EditorGUILayout.BeginVertical("box");
        swapPosition = EditorGUILayout.Toggle("Swap Position", swapPosition);
        swapRotation = EditorGUILayout.Toggle("Swap Rotation", swapRotation);
        swapScale = EditorGUILayout.Toggle("Swap Scale", swapScale);
        swapParent = EditorGUILayout.Toggle("Swap Parent", swapParent);
        EditorGUILayout.EndVertical();

        if (Selection.gameObjects.Length != 0 && replacement != null)
        {
            if (GUILayout.Button("Swap!"))
            {
                GameObject[] allObjects = Selection.gameObjects;
                for (int i = 0; i < allObjects.Length; i++)
                {
                    GameObject clone = PrefabUtility.InstantiatePrefab(replacement) as GameObject;

                    if (swapPosition)
                        clone.transform.position = allObjects[i].transform.position;

                    if (swapRotation)
                        clone.transform.rotation = allObjects[i].transform.rotation;

                    if (swapScale)
                        clone.transform.localScale = allObjects[i].transform.localScale;

                    if (swapParent)
                        clone.transform.parent = allObjects[i].transform.parent;

                    DestroyImmediate(allObjects[i]);
                }
            }
        }
        else
            EditorGUILayout.HelpBox("Select any objects in the scene and define a replacement to get started", MessageType.Info);

        EditorGUILayout.EndVertical();
    }

    private void Rotate()
    {
        angle = EditorGUILayout.FloatField("Angle", angle);

        EditorGUILayout.BeginHorizontal("box");
        if (GUILayout.Button("<"))
        {
            Transform t = Selection.activeTransform;

            if (t != null)
                t.Rotate(t.up, -angle);
        }

        if (GUILayout.Button(">"))
        {
            Transform t = Selection.activeTransform;

            if (t != null)
                t.Rotate(t.up, angle);
        }
        EditorGUILayout.EndHorizontal();
    }
}
