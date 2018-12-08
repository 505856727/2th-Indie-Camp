using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour {

    private void Update()
    {
        if (Input.GetAxis("LeftX2") > 0)
        {
            print(5);
        }
        if (Input.GetAxis("Attack2") < 0)
        {
            print(5);
        }
    }
}
