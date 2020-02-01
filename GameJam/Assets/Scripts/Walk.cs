using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public string forward;
    // Start is called before the first frame update
    void Start()
    {
        forward = "right";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(forward))
        {
            print("ok");
        }
    }
}
