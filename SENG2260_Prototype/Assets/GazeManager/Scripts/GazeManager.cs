using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GazeManager : MonoBehaviour {
    private static readonly int PRIMARY_MOUSE_BUTTON = 0;
    private static readonly int SECONDARY_MOUSE_BUTTON = 1;
    GameObject Target { get; set; }
    EventSystem EventSystem { get; set; }
    OnClick onClick;
    OnGazeEnter onGazeEnter;
    OnGazeExit onGazeExit;

    delegate void OnClick(GameObject target);
    delegate void OnGazeEnter(GameObject target);
    delegate void OnGazeExit(GameObject target);

    // Use this for initialization
    void Start () {
        EventSystem = GameObject.FindObjectOfType<EventSystem>();

        onClick = target => ExecuteEvents.Execute(
            target, new BaseEventData(EventSystem), ExecuteEvents.submitHandler
        );

        onGazeEnter = target => ExecuteEvents.Execute(
            target, new PointerEventData(EventSystem), ExecuteEvents.pointerEnterHandler
        );

        onGazeExit = target => ExecuteEvents.Execute(
            target, new PointerEventData(EventSystem), ExecuteEvents.pointerExitHandler
        );
    }

    // Update is called once per frame
    void Update () {
        int uiLayer = 5;
        int layerMask = 1 << uiLayer;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            GameObject hitTarget = hit.collider.gameObject;

            if (hitTarget != null)
            {
                Debug.Log("Hit Target: " + hitTarget.name);

                if (hitTarget != Target)
                {
                    if (Target != null)
                    {
                        onGazeExit(Target);
                    }
                    onGazeEnter(hitTarget);
                    Target = hitTarget;
                }

                Debug.Log("Current Target: " + Target.name);

                if (Input.GetMouseButtonDown(PRIMARY_MOUSE_BUTTON))
                {
                    onClick(hitTarget);
                }
            }
        }
        else if (Target != null)
        {
            onGazeExit(Target);
            Target = null;
        }
    }
}
