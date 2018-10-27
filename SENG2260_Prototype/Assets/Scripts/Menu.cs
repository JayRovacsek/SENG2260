using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    public bool WearingHoloLens { get; set; }

    // Use this for initialization
    void Start () {
        WearingHoloLens = false;
        if (!WearingHoloLens)
        {
            var widgets = gameObject.GetComponentsInChildren<MenuWidget>();
            foreach (var widget in widgets)
            {
                widget.Close();
            }
            gameObject.SetActive(false);
        }
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active && WearingHoloLens);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

    private void PlayerIsFrozen(bool status)
    {
        return;
    //    FirstPersonController FirstPersonController = gameObject.GetComponent<FirstPersonController>().m_MouseLook.m_cursorIsLocked = !status;

    //    if (status)
    //    {
    //        FirstPersonController.m_WalkSpeed = 0;
    //        FirstPersonController.m_RunSpeed = 0;
    //    }
    //    else
    //    {
    //        FirstPersonController.m_WalkSpeed = 5;
    //        FirstPersonController.m_RunSpeed = 10;
    //    }
    //}
    //    Transform.LookAt(anchor.transform);
    }
}
