using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;

     [SerializeField]
    private float rotationspeed = 100f;

    private void Update() {

        transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed), Space.Self);
        transform.Rotate(new Vector3(0, 1, 0), Input.GetAxis("Horizontal")* Time.deltaTime * rotationspeed);

    }


}
