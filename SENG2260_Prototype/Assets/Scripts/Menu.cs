using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    private GameObject playerObject { get; set; }
    private Transform transform { get; set; }
    private Vector2 velocity { get; set; }
    private float XOffset { get; set; }
    private float YOffset { get; set; }
    private float ZOffset { get; set; }
    public bool Visible { get; set; }

    // Use this for initialization
    void Start () {
        playerObject = GameObject.FindWithTag("Player");
        transform = gameObject.transform;
        XOffset = 1;
        YOffset = 1;
        ZOffset = 1;
    }

    // Update is called once per frame
    void Update () {
        transform.position.Set(playerObject.transform.position.x + XOffset, playerObject.transform.position.y + YOffset, playerObject.transform.position.z + ZOffset);
    }
}
