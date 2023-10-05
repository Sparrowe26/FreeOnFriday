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
}
