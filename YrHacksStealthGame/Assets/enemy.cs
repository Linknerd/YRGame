using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    public int num = 0;
    bool switched = false;
    public Transform[] points = new Transform[3];
    [SerializeField] LayerMask layerMask;
    Vector2 direction;
    public float moveSpeed = 4f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        // for(int i = 0; i < points.Length; i++){
        //     points[i] = transform.position;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(points[num].position.x,points[num].position.y) - new Vector2(transform.position.x,transform.position.y);
        direction = direction.normalized;
    }
    void FixedUpdate(){
        if(switched == true){
            return;
        }
        if(pointReached()){
            StartCoroutine(Switch());
            if(num<points.Length-1){
            num++;
            }
            else if(num>=points.Length-1){
                num = 0;
            }
        }
        rb.velocity = direction*moveSpeed;
    }
    public void SpriteEnabled(){
        spriteRenderer.enabled = true;
    }
    public void SpriteDisabled(){
        spriteRenderer.enabled = false;
    }
    private bool pointReached(){
        return Physics2D.OverlapCircle(transform.position, 0.2f, layerMask);
    }

    private IEnumerator Switch(){
        switched = true;
        yield return new WaitForSeconds(0.5f);
        switched = false;
    }
}
