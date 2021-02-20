using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KancaController : MonoBehaviour
{
    public Animator makaraAnimation;

    Rigidbody2D rb;
    float hiz = 400f;
    bool firlatildi = false;

    GameObject yakalananNesne;
    bool nesneVarMi = false;

    GamePlay gamePlay;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        gamePlay = GameObject.FindObjectOfType<GamePlay>();
        
    }

    private void OnBecameInvisible() //Kameranın görüş açısından çıktığında çalışan event
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(transform.up * hiz);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Makara")
        {
            rb.velocity = Vector2.zero;
            makaraAnimation.enabled = true;

            if (nesneVarMi)
            {
                if (yakalananNesne.gameObject.tag == "Altin")
                {
                    gamePlay.PuanArtir(100);
                }
                else if (yakalananNesne.gameObject.tag == "Elmas")
                {
                    gamePlay.PuanArtir(200);
                }

                Destroy(yakalananNesne);
                nesneVarMi = false;
            }

            firlatildi = false;
        }

        if (collision.gameObject.tag == "Altin" ||
            collision.gameObject.tag == "Elmas" ||
            collision.gameObject.tag == "Tas")
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * hiz);

            yakalananNesne = collision.gameObject;
            yakalananNesne.GetComponent<BoxCollider2D>().enabled = false;
            nesneVarMi = true;

            collision.gameObject.transform.parent = transform;
        }
    }

    public void Firlat()
    {
        if (!firlatildi)
        {
            makaraAnimation.enabled = false;
            rb.AddForce(-transform.up * hiz);

            firlatildi = true;
        }
    }


    
}
