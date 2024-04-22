using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 movementInput;
    Rigidbody2D rb;
    public float moveSpeed = 5f;
    ContactFilter2D movementFilter;
    Transform transform;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    public float collisionOffset = 0.1f;
    public int ebottles = 3;
    public bool canTakeDrink = false;
    bool hasEnergy;
    int smokeBomb = 0;
  //  [SerializeField] textUpdate textUpdate;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)){
            if(ebottles>0){
                StartCoroutine(energyDrink());
                //textUpdate.UpdateDisplay();
            }else{
                Debug.Log("No more drinks");
            }
        }
        

    }
    void FixedUpdate()
    {
        if (movementInput != UnityEngine.Vector2.zero)
        {
            bool success = tryMove(movementInput);
            if (success)
            {
                rb.velocity = movementInput * moveSpeed;
            }
            else if (!success)
            {
                success = tryMove(new UnityEngine.Vector2(movementInput.x, 0));
                if (success)
                {
                    rb.velocity = new UnityEngine.Vector2(movementInput.x, 0);
                }
                else if (!success)
                {
                    success = tryMove(new UnityEngine.Vector2(0, movementInput.y));
                    if (success)
                    {
                        rb.velocity = new UnityEngine.Vector2(0, movementInput.y * moveSpeed);
                    }
                }
            }
        }else{
                rb.velocity = Vector2.zero;
            }
    }

    IEnumerator energyDrink(){
       ebottles -= 1;
       moveSpeed = 2;
       yield return new WaitForSeconds(3f);
       moveSpeed = 8;
       yield return new WaitForSeconds(20f);
       moveSpeed = 5f; 
    }
    private bool tryMove(UnityEngine.Vector2 direction)
    {
        int count = rb.Cast(direction, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);
        if (count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
