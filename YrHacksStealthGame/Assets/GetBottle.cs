using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GetBottle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] playerController player;
    [SerializeField] interactPrompts prompts;
    public static int display;
    public static bool hasReset;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CanGrab())
        {
            prompts.bottle();
            display = 2;
            if (Input.GetKeyDown(KeyCode.E))
            {
                takeDrink();
            }
        }
        else
        {
            if (display > 0 && !CanGrab())
            {
                display--;
            }
            else
            {
                prompts.needsDisplay--;
                display = 0;
                if(!hasReset){
                prompts.Reset();
                hasReset = false;
                }
            }
        }
    }
    public bool CanGrab()
    {
        return Vector2.Distance(player.transform.position, transform.position) < 1f;
    }

    public void takeDrink()
    {
        player.ebottles++;
        player.canTakeDrink = false;
        prompts.Reset();
        display = 0;
        Destroy(this);
    }
}
