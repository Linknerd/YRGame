using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getObjective : MonoBehaviour
{
    [SerializeField] playerController player;
    [SerializeField] interactPrompts prompts;
    SpriteRenderer sprite;
    public static int display;
    public static bool hasReset;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
     void Update()
    {
        if (CanGrab())
        {
            prompts.objective();
            if (Input.GetKeyDown(KeyCode.E))
            {
                grabConsole();
            }
        }
        else
        {
                prompts.needsDisplay--;
                if(!hasReset){
                prompts.Reset();
                hasReset = false;
            }
        }
    }
     public bool CanGrab()
    {
        return Vector2.Distance(player.transform.position, transform.position) < 1f;
    }
    private void grabConsole(){
        sprite.enabled = false;
        prompts.numberOfObjects--;
        player.hasConsole = true;
        Destroy(this);
    }
}
