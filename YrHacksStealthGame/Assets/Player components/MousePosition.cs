using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MousePosition : MonoBehaviour
{
    // Start is called before the first frame update
     Vector3 mousePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       mousePos = Input.mousePosition;
    }
    public Vector3 GetMousePos(){
        return mousePos;
    }
}
