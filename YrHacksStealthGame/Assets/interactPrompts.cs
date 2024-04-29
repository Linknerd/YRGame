using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class interactPrompts : MonoBehaviour
{
    TextMeshProUGUI tmp;
    public int numberOfObjects = 0;
    public int needsDisplay;
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
        needsDisplay = numberOfObjects;
        Debug.Log(needsDisplay);
    }
    public void bottle(){
        if(tmp != null){
            Debug.Log("asdf");
            tmp.text = "Press E to collect bottle";
        }
    }
    public void hideTrash(){
        if(tmp != null){
            tmp.text = "Press E to hide";
        }
    }
    public void leaveTrash(){
        if(tmp != null){
            tmp.text = "Press E to leave";
        }
    }
    public void Reset(){
        if(needsDisplay < 0){
        tmp.text = "";
        Debug.Log("fdfsa");
        }
    }
    public void objective(){
        if(tmp!=null){
            tmp.text = "Press E to get the console!";
        }
    }
}
