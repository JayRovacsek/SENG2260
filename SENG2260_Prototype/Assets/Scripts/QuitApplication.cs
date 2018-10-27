using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitApplication : MonoBehaviour {
    [SerializeField]
    private Button button;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(Quit);
	}

    private void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
