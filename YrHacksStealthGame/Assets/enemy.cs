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
    public Vector3[] points = new Vector3[3];
    Vector2 direction;
    public float moveSpeed = 4f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        for(int i = 0; i < points.Length; i++){
            points[i] = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(points[num].x,points[num].y) - new Vector2(transform.position.x,transform.position.y);
        direction = direction.normalized;
    }
    void FixedUpdate(){
        rb.velocity = direction*moveSpeed;
    }
    public void SpriteEnabled(){
        spriteRenderer.enabled = true;
    }
    public void SpriteDisabled(){
        spriteRenderer.enabled = false;
    }
}
