using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Camera anchor;
    private Transform Transform { get; set; }
    private Vector2 Velocity { get; set; }
    public int maxDistance;
    public int minDistance;
    public bool visible;

    // Use this for initialization
    void Start () {
        if (anchor == null)
        {
            anchor = Camera.main;
        }
        Transform = gameObject.transform;
    }

    // FixedUpdate is called once per fixed frame
    void FixedUpdate () {
        double distance = Vector3.Distance(Transform.position, Camera.main.transform.position);
        Vector3 directionVector = (Transform.position - Camera.main.transform.position).normalized;

        // If the menu is more than maxDistance away place it within minDistance of the anchor
        if (distance > maxDistance)
        {
            // Scalar * direction vector + origin
            Transform.position = (maxDistance * directionVector) + Camera.main.transform.position;
        }
        else if (distance <= minDistance)
        {
            // Scalar * direction vector + origin
            Transform.position = (minDistance * directionVector) + Camera.main.transform.position;
        }
        Transform.LookAt(anchor.transform);
    }   
}
