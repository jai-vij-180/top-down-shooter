using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public int health = 100;
    public bool isPlayerEnter;
    public float moveSpeed = 5f;
    CharacterController2D player;
    public Transform playerTransform;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<CharacterController2D>();
    }

    void Update()
    {
        if(health <=0)
        {
            Destroy(gameObject);
            print("enemy down");
        }
    //    if(isPlayerEnter)
    //    {
    //        moveAI();
    //    }
    }

    

    public void isHit(int damage)
    {
        health -= damage;
    }
}
