using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    public UnityEvent PointerDown;
    [SerializeField]
    public UnityEvent PointerUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (PointerDown != null)
            PointerDown.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (PointerUp != null)
            PointerUp.Invoke();
    }
}