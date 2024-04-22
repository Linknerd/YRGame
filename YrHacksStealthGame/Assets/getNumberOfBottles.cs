using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;
using System;

public class getNumberOfBottles : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI tmp;
    [SerializeField] playerController player;
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tmp != null && player != null) {
        tmp.text = player.ebottles.ToString();
    }
    }
}
