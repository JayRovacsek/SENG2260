using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinGroupController : MonoBehaviour
{
    [SerializeField]
    private GroupMenuWidget widget;
    [SerializeField]
    private List<GameObject> objects;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
    }

    // FixedUpdate is called once per fixed frame
    void FixedUpdate()
    {
        if (widget.isJoiningGroup)
        {
            foreach (var obj in objects)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            foreach (var obj in objects)
            {
                obj.SetActive(false);
            }
        }
    }
}
