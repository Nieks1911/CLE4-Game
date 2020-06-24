using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public procgen Proc;
    public GameObject deathScreen, player;
    public SpriteRenderer playerSprite;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public CapsuleCollider2D cc;
    public CircleCollider2D crc1, crc2;

    public float deathScreenDuration = 2f;
    public bool dead = false;
    public float TT;
    public Vector3 spawnPoint;

    public bool Invincible = false;
    public float Invincitime = 1f;

    private bool counting = false;
    private float Restimer = 0;

    private void Start() {
        deathScreen.SetActive(false);
        spawnPoint = player.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy" && !Invincible && !collision.gameObject.GetComponent<enemyMovement>().Knocked) {
            player _P = gameObject.GetComponent<player>();
            if (_P.TakeHit(collision.gameObject.GetComponent<enemyMovement>().ghostDamage) <= 0)
            {
                Die();
            }
            else
            {
                Invincible = true;
                TT = Time.time + Invincitime;
            }
        }
        else if (collision.gameObject.tag == "Enemy" && collision.gameObject.name == "Buff_Spook")
        {
            player _P = gameObject.GetComponent<player>();
            if (_P.TakeHit(collision.gameObject.GetComponent<Buff_Spook>().BossDamage) <= 0)
            {
                Die();
            }
            else
            {
                Invincible = true;
                TT = Time.time + Invincitime;
            }
        }
    }

    private void Update()
    {
        if (Input.GetButton("Res"))
        {
            if (!counting)
            {
                counting = true;
                Restimer = Time.time + 2f;
            }
            else if (Restimer <= Time.time && counting)
            {
                counting = false;
                Respawn();
            }
        }
        if (Input.GetButtonUp("Res")) 
        {
            Restimer = 0f;
            counting = false;
        }

        if (dead && Time.time > TT)
        {
            dead = false;
            Respawn();
        }
        else if (Invincible && Time.time > TT)
        {
            Invincible = false;
        }
    }

    public void Die()
    {
        // Disables sprite.
        playerSprite.enabled = false;
        GetComponent<player>().enabled = false;
        // Disables BoxCollider and CapsuleCollider.
        if (bc != null)
        {
            bc.enabled = false;
        }
        if (cc != null)
        {
            cc.enabled = false;
        }
        if (crc1 != null)
        {
            crc1.enabled = false;
        }
        if (crc2 != null)
        {
            crc2.enabled = false;
        }

        // Disables physics for character upon death.
        rb.bodyType = RigidbodyType2D.Kinematic;
        // Sets character velocity to 0 upon death.
        rb.velocity = Vector2.zero;
        // Enables death screen.
        deathScreen.SetActive(true);

        if (dead == false)
        {
            dead = true;
            TT = Time.time + deathScreenDuration;
        }
    }

    public void Respawn()
    {
        CameraFollow Cam = (CameraFollow)FindObjectOfType(typeof(CameraFollow));
        Cam.ChangeCam(false);
        deathScreen.SetActive(false);
        player.transform.position = spawnPoint;
        GetComponent<player>().enabled = true;
        GetComponent<player>().stats.ResetStats();
        playerSprite.enabled = true;
        if (bc != null)
        {
            bc.enabled = true;
        }
        if (cc != null)
        {
            cc.enabled = true;
        }
        if (crc1 != null)
        {
            crc1.enabled = true;
        }
        if (crc2 != null)
        {
            crc2.enabled = true;
        }
        rb.bodyType = RigidbodyType2D.Dynamic;

        Proc.ResLvls();
    }
}
