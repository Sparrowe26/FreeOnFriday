using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        // draws circle around target
        FieldOfView fov = (FieldOfView) target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.up, 360, fov.viewDst);

        Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2 - fov.transform.eulerAngles.z);
        Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2 - fov.transform.eulerAngles.z);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewDst);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewDst);

        Handles.color = Color.red; 
        foreach(Transform visibleTarget in fov.visibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTarget.position);
        }
    }
}
