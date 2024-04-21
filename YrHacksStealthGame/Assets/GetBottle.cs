using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetBottle : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] playerController player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisIOnEnter2D(Collider2D other){
        if(other.tag == "Player"){
            player.canTakeDrink = true;
        }
        Debug.Log("Can take bottle");
    }
    public void takeDrink(){
        player.ebottles++;
        player.canTakeDrink = false;
        Destroy(this);
    }
}
