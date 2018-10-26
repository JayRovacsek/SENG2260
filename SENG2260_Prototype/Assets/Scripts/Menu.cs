using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject PlayerMenu { get; set; }

	// Use this for initialization
	void Start () {
        PlayerMenu = GameObject.FindWithTag("Menu");
        PlayerMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerMenu.SetActive(!PlayerMenu.activeSelf);
        }
	}
}
