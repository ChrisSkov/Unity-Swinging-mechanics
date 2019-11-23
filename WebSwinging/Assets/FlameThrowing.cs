using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowing : MonoBehaviour
{
    [SerializeField] GameObject flameObj;
    bool flameIsActive;
    // Start is called before the first frame update
    void Start()
    {
        flameObj.SetActive(false);
    }

    // Update is called once per frame

    void Update()
    {
        ActivateFlame();
    }
    void ActivateFlame()
    {

        // if(!flameIsActive && Input.GetKeyDown(KeyCode.Q))
        // {
        //     flameObj.SetActive(true);//TODO: Refactor repeating code
        //     flameIsActive = true;
        //     print("eow");
        // }
        // else if(Input.GetKeyDown(KeyCode.Q))
        // {
        //     flameObj.SetActive(false);
        //     flameIsActive = false;
        // }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            flameObj.SetActive(true);//TODO: Refactor repeating code
           // flameIsActive = true;
            print("eow");
        }
        else if(Input.GetKeyUp(KeyCode.Q))
        {
            flameObj.SetActive(false);
            print("ses");
        }

    }
}
