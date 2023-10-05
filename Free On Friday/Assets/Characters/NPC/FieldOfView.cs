using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewDst;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstabcleMask;

    public List<Transform> visibleTargets = new List<Transform>();
    private SpriteRenderer spriteRend;

    public float meshRes;
    public MeshFilter viewMeshFilter;
    Mesh viewMesh;

    // Start is called before the first frame update
    void Start()
    {
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;
        spriteRend = GetComponent<SpriteRenderer>();
        StartCoroutine("FindTargetsWithDelay", .05f);
    }

    private void Update()
    {
        DrawFieldOfView();
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    /// <summary>
    /// finds all visible targets within range and sight cone and add them to list above
    /// </summary>
    void FindVisibleTargets()
    {
        // clear list and set color to white every new frame
        visibleTargets.Clear();
        spriteRend.color = Color.white;
        // add all targets within a circle of radius viewdst around npc
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewDst, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            // take each transform for all targets in radius
            Transform target = targetsInViewRadius[i].transform;
            // issue with some hitboxes being too long as the player transform.position is too high on the model when compared to the hitbox
            // BoxCollider2D targetCol = targetsInViewRadius[i].GetComponent<BoxCollider2D>();
            BoxCollider2D targetCollider = target.GetComponent<BoxCollider2D>();
            Vector2 dirToTarget = ((target.position + (Vector3) targetCollider.offset) - transform.position).normalized;
            float dstToTarget = Vector2.Distance(transform.position, (target.position + (Vector3)targetCollider.offset));

            // check if it is in front of npc viewangle
            if (Vector2.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                // raycast only works to a point, may need to switch it up to work with an entire hitbox for the whole character
                RaycastHit2D hit = Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstabcleMask);

                if (!hit.collider)
                {
                    // add to list of visible targets
                    visibleTargets.Add(target);
                    spriteRend.color = Color.red;
                }
            }
        }
    }

    /// <summary>
    /// calculates the way the npc is looking
    /// </summary>
    /// <param name="angleDeg"></param>
    /// <returns>point where npc is looking</returns>
    public Vector2 DirFromAngle(float angleDeg)
    {
        return new Vector2(Mathf.Sin(angleDeg * Mathf.Deg2Rad), Mathf.Cos(angleDeg * Mathf.Deg2Rad));
    }

    /// <summary>
    /// draws the fov in front of character
    /// </summary>
    void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshRes);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();

        for (int i = 0; i < stepCount; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
            Debug.DrawLine(transform.position, transform.position + (Vector3)DirFromAngle(angle) * viewDst, Color.red);
            ViewCastInfo newViewCast = ViewCast(angle);
            viewPoints.Add(newViewCast.point);
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);

            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }
        viewMesh.Clear();

        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }

    //void DrawFieldOfView()
    //{
    //    int stepCount = Mathf.RoundToInt(viewAngle * meshRes);
    //    float stepAngleSize = viewAngle / stepCount;
    //    List<Vector3> viewPoints = new List<Vector3>();
    //    ViewCastInfo oldViewCast = new ViewCastInfo();
    //    for (int i = 0; i <= stepCount; i++)
    //    {
    //        float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
    //        ViewCastInfo newViewCast = ViewCast(angle);

    //        if (i > 0)
    //        {
    //            bool edgeDstThresholdExceeded = Mathf.Abs(oldViewCast.dst - newViewCast.dst) > edgeDstThreshold;
    //            if (oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded))
    //            {
    //                EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
    //                if (edge.pointA != Vector3.zero)
    //                {
    //                    viewPoints.Add(edge.pointA);
    //                }
    //                if (edge.pointB != Vector3.zero)
    //                {
    //                    viewPoints.Add(edge.pointB);
    //                }
    //            }

    //        }


    //        viewPoints.Add(newViewCast.point);
    //        oldViewCast = newViewCast;
    //    }

    //    int vertexCount = viewPoints.Count + 1;
    //    Vector3[] vertices = new Vector3[vertexCount];
    //    int[] triangles = new int[(vertexCount - 2) * 3];

    //    vertices[0] = Vector3.zero;
    //    for (int i = 0; i < vertexCount - 1; i++)
    //    {
    //        vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);

    //        if (i < vertexCount - 2)
    //        {
    //            triangles[i * 3] = 0;
    //            triangles[i * 3 + 1] = i + 1;
    //            triangles[i * 3 + 2] = i + 2;
    //        }
    //    }

    //    viewMesh.Clear();

    //    viewMesh.vertices = vertices;
    //    viewMesh.triangles = triangles;
    //    viewMesh.RecalculateNormals();
    //}

    ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirFromAngle(globalAngle);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, viewDst, obstabcleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + dir * viewDst, viewDst, globalAngle);
        }
    }


    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }
}