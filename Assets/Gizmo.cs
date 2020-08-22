using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public float gizmosize = 0.75f;
    public Color gizmocolor = Color.yellow;
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmocolor;
        Gizmos.DrawWireSphere(transform.position, gizmosize);
    }
}
