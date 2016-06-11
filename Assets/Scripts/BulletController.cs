using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float gunRange = 20f;
    EnemyController enemyController;
	void Start () {
        enemyController = GetComponent<EnemyController>();
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector3.up, gunRange);
        Debug.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.green);
        //Ray ray = new Ray(transform.position, Vector3.forward);
        //if()
        //{
        //    if(hit.collider.tag == "enemy")
        //        enemyController.health -= 5;
        //}
        //Destroy(gameObject, 0.5f);   //to destroy the bullet
	}
}
