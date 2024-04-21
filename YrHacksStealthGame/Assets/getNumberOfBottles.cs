using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;
using System;

public class getNumberOfBottles : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshPro tmp;
    [SerializeField] playerController player;
    void Start()
    {
        tmp.text = "15";
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = player.ebottles.ToString();
    }
}
