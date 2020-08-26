using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const float gizmoRadius = 0.3f;

    private void OnDrawGizmos()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            int j = GetNextIndex(i);
            Gizmos.DrawSphere(GetPosition(i), gizmoRadius);
            Gizmos.DrawLine(GetPosition(i), GetPosition(j));
        }
    }

    public Vector3 GetPosition(int i)
    {
        return transform.GetChild(i).position;
    }

    public int GetNextIndex(int i)
    {
        if(i + 1 == transform.childCount)
        {
            return 0;
        }
        return i + 1;
    }
}
