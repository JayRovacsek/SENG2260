using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOld : MonoBehaviour {

    public GameObject PlayerMenu { get; set; }
    public IEnumerable<GameObject> PlayerSubmenu { get; set; }
    public GameObject Player { get; set; }
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPersonController { get; set; }
    public Camera Camera { get; set; }
    public bool FreezeCamera { get; set; }

	// Use this for initialization
	void Start () {
        PlayerMenu = GameObject.FindWithTag("Menu");
        PlayerSubmenu = GameObject.FindGameObjectsWithTag("Submenu");
        Player = GameObject.FindWithTag("Player");
        FirstPersonController = Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        Camera = Player.GetComponent<Camera>();
        PlayerMenu.SetActive(false);
        foreach (var Submenu in PlayerSubmenu)
        {
            Submenu.SetActive(false);
        }
        FreezeCamera = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerMenu.SetActive(!PlayerMenu.activeSelf);
            foreach (var Submenu in PlayerSubmenu)
            {
                Submenu.SetActive(false);
            }
        }

        if (PlayerMenu.activeSelf)
        {
            PlayerIsFrozen(true);
        }
        else
        {
            PlayerIsFrozen(false);
        }
    }

    private void PlayerIsFrozen(bool status)
    {
        Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_cursorIsLocked = !status;

        if (status)
        {
            FirstPersonController.m_WalkSpeed = 0;
            FirstPersonController.m_RunSpeed = 0;
        }
        else
        {
            FirstPersonController.m_WalkSpeed = 5;
            FirstPersonController.m_RunSpeed = 10;
        }
    }
}
