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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CanGrab())
        {
            prompts.bottle();
            if (Input.GetKeyDown(KeyCode.E))
            {
                takeDrink();
            }
        }else{
            prompts.Reset();
        }
    }
    bool CanGrab()
    {
        return Vector2.Distance(player.transform.position, transform.position) < 1f;
    }

    public void takeDrink()
    {
        player.ebottles++;
        player.canTakeDrink = false;
        Destroy(this);
    }
}
