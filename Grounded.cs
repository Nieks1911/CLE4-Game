using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;

    [SerializeField]
    GameObject DustCloud;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals ("Ground"))
        {
            Instantiate(DustCloud, transform.position, DustCloud.transform.rotation);
        }

    }

    private void Start() {
        // Gets parent object "Player" 
        Player = gameObject.transform.parent.gameObject;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Ground") {
            Player.GetComponent<PlayerMovement>().isGrounded = true;
        }
    }

    

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "Ground") {
            Player.GetComponent<PlayerMovement>().isGrounded = false;
        }
    }
}
