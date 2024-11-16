using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarTalisman : PoolManager
{
    [SerializeField] Transform jugador;

    [SerializeField] KeyCode tecla;

    [Header ("Cooldown")]
    private float ultimoDisparo;
    [Range(0, 1)]
    [SerializeField] private float cooldown; //Tiempo max recarga
    private float tiempoDRecarga; //Esto es el tiempo en vivo de la recarga

    [Header("Municion")]
    [Range(0, 10)]
    [SerializeField] public int municionMax;
    public int municionActual;

    private void Awake()
    {
        ultimoDisparo = Time.time;
    }
    void Update()
    {
        if (Input.GetKey(tecla) && municionActual>0) 
        {
            if (ultimoDisparo < Time.time)
            {
                ultimoDisparo = Time.time + cooldown;
                PedirObjeto();
                tiempoDRecarga = 0;
            }
        }
        tiempoDRecarga += Time.deltaTime;
        tiempoDRecarga = Mathf.Clamp(tiempoDRecarga, 0,cooldown);

        municionActual = Mathf.Clamp(municionActual, 0, municionMax);
    }
    public override GameObject PedirObjeto()
    {
        GameObject Objeto = base.PedirObjeto();
        Objeto.transform.position = transform.position;
        Objeto.transform.rotation = jugador.rotation;
        Objeto.SetActive(true);
        Objeto.GetComponent<TalismanVolando>().Disparar(jugador);

        return Objeto;
    }
    
}



