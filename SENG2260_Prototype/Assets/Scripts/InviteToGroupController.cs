using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviteToGroupController : MonoBehaviour
{
    [SerializeField]
    private GroupMenuWidget widget;
    [SerializeField]
    private List<GameObject> showWhenActive;
    [SerializeField]
    private List<GameObject> showWhenInactive;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in showWhenActive)
        {
            obj.SetActive(false);
        }
        foreach (var obj in showWhenInactive)
        {
            obj.SetActive(true);
        }
    }

    // FixedUpdate is called once per fixed frame
    void FixedUpdate()
    {
        if (widget.isInviting)
        {
            foreach (var obj in showWhenActive)
            {
                obj.SetActive(true);
            }
            foreach (var obj in showWhenInactive)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (var obj in showWhenActive)
            {
                obj.SetActive(false);
            }
            foreach (var obj in showWhenInactive)
            {
                obj.SetActive(true);
            }
        }
    }
}
