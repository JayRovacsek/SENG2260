using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Menu))]
public class WearableHoloLens : MonoBehaviour
{
    [SerializeField]
    private Menu menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        menu.WearingHoloLens = true;
        menu.SetActive(false);
        Object.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
