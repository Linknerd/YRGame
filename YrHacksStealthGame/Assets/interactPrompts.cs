using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class interactPrompts : MonoBehaviour
{
    TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        if(tmp != null){
        tmp.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void bottle(){
        if(tmp != null){
            Debug.Log("asdf");
            tmp.text = "Press E to collect bottle";
        }
    }
    public void Reset(){
        tmp.text = "";
        Debug.Log("fdfsa");
    }
}
