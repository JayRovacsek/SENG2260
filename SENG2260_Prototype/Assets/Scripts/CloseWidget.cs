using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseWidget : MonoBehaviour {
    [SerializeField]
    private GameObject widget;
    [SerializeField]
    private Button button;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(OnClick);
	}

    private void OnClick()
    {
        widget.SetActive(false);
    }
}
