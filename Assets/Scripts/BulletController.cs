using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// Mechanism for the bullet and its API
/// </summary>
public class BulletController : MonoBehaviour
{
    [Header("Status")]
    [SerializeField]
    bool IsInitialized;
    [Header("Bullet Settings")]
    public float bulletSpeed = 100;
    public float bulletCheckingDistance = 0.05f;
    public int bulletDamage = 20;
    //public LayerMask WhatDoBulletsHit;
    public bool AutoDestroy;
    public float DestroyAfterSeconds = 3f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bulletSpeed);
    }

    void Update()
    {
        if (IsInitialized)
        {
            BulletHitCheck();
        }
    }



    void BulletHitCheck()
    {

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, transform.up
           , bulletCheckingDistance);
        //Debug.DrawRay(transform.position, transform.up, Color.cyan);

        
        if (hit.collider)//if it hits enemy 
        {
            //Debug.DrawRay(transform.position, hit.transform.position);
            //EditorApplication.isPaused = true;
            GameObject enemyThatWasHit = hit.collider.gameObject;
            if(enemyThatWasHit != null)
                enemyThatWasHit.GetComponent<EnemyController>().isHit(bulletDamage);
            enemyThatWasHit = null;
            Destroy(this.gameObject);

        }
        //if(hit.collider)
        //{
        //    Destroy(this.gameObject);
        //}
    }
    #region API
    /// <summary>
    /// This method allows others to tell the bullet when to ACTIVATE its functionality, Start runs automatically, we wan which ever script spawns the bullet to be able to activate as needed- ,maybe it would want to do some priliminary checks, if the bullet starts doing its own thing as soon as instantiated, it will be hard to handle.
    /// </summary>
    public void InitBullet()
    {

        //rb.AddForce(transform.up * bulletSpeed);
        if (AutoDestroy)
        {
            Destroy(this.gameObject, DestroyAfterSeconds);
        }
        IsInitialized = true;

    }
    #endregion
}
