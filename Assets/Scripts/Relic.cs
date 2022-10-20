using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Relic : MonoBehaviour
{

#if UNITY_EDITOR
    public Transform cameraTransform;
    public Vector3 p1, p2, p3, p4;
    private void OnDrawGizmos()
    {
        Vector3 pos = cameraTransform.position;
        Gizmos.color = Color.black;
        Gizmos.DrawLine(p1 + pos, p2 + pos);
        Gizmos.DrawLine(p2 + pos, p3 + pos);
        Gizmos.DrawLine(p3 + pos, p4 + pos);
        Gizmos.DrawLine(p4 + pos, p1 + pos);
    }
#endif
}

