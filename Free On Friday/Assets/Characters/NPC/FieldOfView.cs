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

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        StartCoroutine("FindTargetsWithDelay", .05f);
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
            Vector2 dirToTarget = (target.position - transform.position).normalized;

            // check if it is in front of npc viewangle
            if (Vector2.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                RaycastHit2D hit = Physics2D.Linecast(transform.position, target.position, obstabcleMask);

                if (!hit.collider)
                {
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
}
