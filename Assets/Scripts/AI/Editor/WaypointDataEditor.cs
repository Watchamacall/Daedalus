using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WaypointData))]
public class WaypointDataEditor : Editor
{
    private int selectedPointID = 0;
    void OnEnable()
    {
        SceneView.duringSceneGui += this.OnSceneGUI;
    }

    void OnDisable()
    {
        SceneView.duringSceneGui -= this.OnSceneGUI;
    }

    public void OnSceneGUI(SceneView sceneView)
    {
        WaypointData data = (WaypointData)target;



        if(data.points.Count > 0)
        {
            Vector3 lastPoint = data.points[0];

            for (int i = 0; i < data.points.Count; i++)
            {
                if (i == selectedPointID)
                    data.points[i] = Handles.DoPositionHandle(data.points[i], Quaternion.identity);

                if (i != selectedPointID)
                {
                    Handles.color = Color.white;
                    if (Handles.Button(data.points[i], Quaternion.identity, .5f, .5f, Handles.SphereHandleCap))
                    {
                        selectedPointID = i;
                    }
                }
                else
                {
                    Handles.color = Color.red;
                    Handles.SphereHandleCap(0, data.points[i], Quaternion.identity, .3f, EventType.Repaint);
                }

                if (i > 0)
                {
                    Handles.color = Color.white;
                    Handles.DrawLine(data.points[i], lastPoint);
                    lastPoint = data.points[i];
                }
            }
        }
    }

    public override void OnInspectorGUI()
    {
        WaypointData data = (WaypointData)target;
        if (GUILayout.Button("Add Point"))
        {
            if(data.points.Count > 0)
            {
                data.points.Add(data.points[selectedPointID]);
                selectedPointID = data.points.Count - 1;
            }
            else
            {
                data.points.Add(Vector3.zero);
                selectedPointID = 0;
            }

            SceneView.RepaintAll();
        }

        if(data.points.Count > 0)
            if (GUILayout.Button("Delete Point"))
            {
                data.points.RemoveAt(selectedPointID);
                selectedPointID -= 1;

                if (selectedPointID < 0)
                    selectedPointID = 0;

                SceneView.RepaintAll();
            }

        base.OnInspectorGUI();
    }
}
