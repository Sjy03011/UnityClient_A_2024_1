using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExsoundPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Alpha1))
         {
            SoundManagaer.instance.PlaySound("BacKGround_001");
         }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SoundManagaer.instance.PlaySound("Cannon");

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SoundManagaer.instance.PlaySound("Laser");

        }

    }

}
