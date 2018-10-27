using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWidget : MonoBehaviour
{
    [SerializeField]
    private Camera anchor;
    [SerializeField]
    protected MenuWidget parent;

    // Start is called before the first frame update
    void Start()
    {
        if (anchor == null)
        {
            anchor = Camera.main;
        }

        if (parent != null)
        {
            if (parent.IsActive())
            {
                Close();
            }
        }
        else
        {
            Open();
        }
    }

    public void Toggle()
    {
        if (IsActive())
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Open()
    {
        Reorient();
        SetActive(true);
        // This must be done after in case the caller is in the parent's scene graph
        if (parent != null)
        {
            parent.Close();
        }
    }

    public void Close()
    {
        if (parent != null)
        {
            parent.Open();
        }
        SetActive(false);
    }

    public bool IsActive()
    {
        return GetWidget().gameObject.activeSelf;
    }

    public void SetActive(bool active)
    {
        GetWidget().gameObject.SetActive(active);
    }

    public virtual MenuWidget GetWidget()
    {
        return this;
    }

    public void Reorient()
    {
        // Reorient the menu to face the main camera
        GetWidget().gameObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2;
        GetWidget().gameObject.transform.LookAt(Camera.main.transform);
        GetWidget().gameObject.transform.Rotate(Quaternion.AngleAxis(0, new Vector3(0, 0, 1)).eulerAngles);
        GetWidget().gameObject.transform.Rotate(Quaternion.AngleAxis(180, new Vector3(0, 1, 0)).eulerAngles);
    }
}
