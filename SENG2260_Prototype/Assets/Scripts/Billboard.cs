using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDudes
{
    public class Billboard : MonoBehaviour
    {
        [SerializeField]
        private GameObject anchor;
        [SerializeField]
        private Camera camera;
        [SerializeField]
        private float height;

        // Start is called before the first frame update
        void Start()
        {
            if (anchor == null)
            {
                anchor = Camera.main.gameObject;
            }
            if (camera == null)
            {
                camera = Camera.main;
            }
        }

        // FixedUpdate is called once per fixed frame
        void FixedUpdate()
        {
            gameObject.transform.position = anchor.transform.position + new Vector3(0f, height, 0f);
            gameObject.transform.LookAt(camera.transform);
            gameObject.transform.Rotate(Quaternion.AngleAxis(0, new Vector3(0, 0, 1)).eulerAngles);
            gameObject.transform.Rotate(Quaternion.AngleAxis(180, new Vector3(0, 1, 0)).eulerAngles);
        }
    }

}
