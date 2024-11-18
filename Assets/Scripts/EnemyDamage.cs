using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    /*
    public ContactFilter2D xd;
    Rigidbody2D rb;
    public bool takeDamage => rb.IsTouching(xd);
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if(takeDamage==true){
            Destroy(this.gameObject);
        }
    }
    */
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<LifeManager>().TakeDamage();

        }
    }
}
