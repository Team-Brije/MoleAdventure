using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.VFX;

public class Talisman : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;
    [SerializeField] private float tiempoDeDesaparecer;
    private void Awake()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
    }
    public void Disparar(Transform dir)
    {
        transform.rotation = dir.rotation;
        rigidbody2D.AddForce( transform.up * velocidad, ForceMode2D.Impulse);
    }
    private void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy) 
        {
            StartCoroutine(TiempoDeDesaparecer());
        }
        
    }
    private IEnumerator TiempoDeDesaparecer()
    {
        yield return new WaitForSeconds(tiempoDeDesaparecer);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
