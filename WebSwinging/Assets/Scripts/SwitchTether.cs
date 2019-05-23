using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTether : MonoBehaviour
{
    public Transform newTether;
    public Swing swing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            swing.pendulum.SwitchTether(newTether.transform.position);
        }
    }
}
