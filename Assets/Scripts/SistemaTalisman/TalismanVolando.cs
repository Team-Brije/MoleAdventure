using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.VFX;

public class TalismanVolando : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;

    [SerializeField] private float velocidad;

    [Range(0, 10)]
    [SerializeField] private float tiempoDeDesaparecer;

    [SerializeField] private GameObject talismanflotando;
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
        Instantiate(talismanflotando, transform.position, quaternion.identity);
    }


}
