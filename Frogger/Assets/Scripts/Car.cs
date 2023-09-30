using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] bool isRightToLeft;
    [SerializeField] SpriteRenderer spriteRenderer;

    void Start() 
    {
        Destroy(gameObject, 10);    
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 newPos = transform.position;
        newPos.x += moveSpeed * Time.deltaTime;

        transform.position = newPos;
    }

    public void OpenRight()
    {
        moveSpeed *= -1;
        spriteRenderer.flipX = true;
    }

}
