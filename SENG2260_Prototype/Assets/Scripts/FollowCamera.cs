using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Camera anchor;
    [SerializeField]
    private int maxDistance;
    [SerializeField]
    private int minDistance;

    // Start is called before the first frame update
    void Start()
    {
        if (anchor == null)
        {
            anchor = Camera.main;
        }
    }

    // FixedUpdate is called once per fixed frame
    void FixedUpdate()
    {
        double distance = Vector3.Distance(gameObject.transform.position, anchor.transform.position);
        Vector3 directionVector = (gameObject.transform.position - anchor.transform.position).normalized;

        // If the menu is more than maxDistance away place it within minDistance of the anchor
        if (distance > maxDistance)
        {
            // Scalar * direction vector + origin
            gameObject.transform.position = (maxDistance * directionVector) + anchor.transform.position;
        }
        else if (distance <= minDistance)
        {
            // Scalar * direction vector + origin
            gameObject.transform.position = (minDistance * directionVector) + anchor.transform.position;
        }
    }
}
