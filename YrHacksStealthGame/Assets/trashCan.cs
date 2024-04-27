using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCan : MonoBehaviour
{
    [SerializeField] playerController player;
    [SerializeField] interactPrompts prompts;
    public static int display;
    static bool hidden = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanHide())
        {
            if(!hidden){
                prompts.hideTrash();
                Debug.Log("Yes I'm running");
            }else{
                prompts.leaveTrash();
                Debug.Log("Yes I'm hiding");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
               if(hidden == false){
                hide();
               }else{
                stopHiding();
               }
            }
        }
        else
        {
                prompts.Reset();
                Debug.Log("Resetting");
        }
    }
    public bool CanHide()
    {
        return Vector2.Distance(player.transform.position, transform.position) < 1f;
    }
    private void hide(){
        player.hide();
        hidden = true;
    }
    private void stopHiding(){
        player.leave();
        hidden = false;
    }
}
