using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour {

    private void Update()
    {
        if (Input.GetAxis("LeftX1") > 0)
        {
            print(1);
        }
        if (Input.GetAxis("Attack1") > 0)
        {
            print(2);
        }
    }
}
