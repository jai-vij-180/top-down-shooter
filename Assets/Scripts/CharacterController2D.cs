using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {

    public float speed = 5f;
    Rigidbody2D rb;
	
	void Start () {
       rb = GetComponent<Rigidbody2D>();
	}
	
    
	void FixedUpdate () {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        rb.AddForce( new Vector3( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed);
  
	}
}
