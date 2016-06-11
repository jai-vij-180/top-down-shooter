using UnityEngine;
using System.Collections;

/// <summary>
/// Mechanism for the bullet and its API
/// </summary>
public class BulletController : MonoBehaviour {
    [Header("Status")]
    [SerializeField]
    bool IsInitialized;
    [Header("Bullet Settings")]
    public float bulletSpeed = 5000;
    public float bulletCheckingDistance = 0.05f;
    public LayerMask WhatDoBulletsHit;
    public bool AutoDestroy;
    public float DestroyAfterSeconds=3f;

	void Start () {
        
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
           , bulletCheckingDistance, WhatDoBulletsHit);

        if (hit.collider)
        {
           var enemyThatWasHit = hit.collider.gameObject;
           print("die pls");
            
            //Damage enemy here
        }
    }
    #region API
    /// <summary>
    /// This method allows others to tell the bullet when to ACTIVATE its functionality, Start runs automatically, we wan which ever script spawns the bullet to be able to activate as needed- ,maybe it would want to do some priliminary checks, if the bullet starts doing its own thing as soon as instantiated, it will be hard to handle.
    /// </summary>
    public void InitBullet(){
        
        GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
        if (AutoDestroy)
        {
            Destroy(this.gameObject, DestroyAfterSeconds);
        }
        IsInitialized = true;

    }
    #endregion
}
