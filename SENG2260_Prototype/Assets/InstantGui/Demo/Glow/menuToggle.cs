using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuToggle : MonoBehaviour {
    private GameObject menu;

    public menuToggle(GameObject menu)
    {
        
    }
	// Use this for initialization
	void Start () {
	menu = GameObject.FindWithTag("Menu");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.B))
        {
            menu.SetActive(!menu.activeSelf);
        }
	}
}
