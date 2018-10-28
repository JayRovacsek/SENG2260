using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginDisabled : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(false);
    }
}   
