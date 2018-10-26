using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggle : MonoBehaviour {

    public GameObject Menu { get; set; }

	// Use this for initialization
	void Start () {
        Menu = GameObject.FindWithTag("Menu");
        Menu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Menu.SetActive(!Menu.activeSelf);
        }
	}
}
