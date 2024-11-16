using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.VFX;

public class TalismanVolando : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [Range(0, 10)]
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
        rigidbody2D.AddForceAtPosition(dir.up * velocidad, transform.position, ForceMode2D.Impulse);
        StartCoroutine(TiempoDeDesaparecer());
    }

    private IEnumerator TiempoDeDesaparecer()
    {
        yield return new WaitForSeconds(tiempoDeDesaparecer);
        gameObject.SetActive(false);
        Instantiate(talismanflotando, gameObject.transform.position, quaternion.identity);
    }

}
