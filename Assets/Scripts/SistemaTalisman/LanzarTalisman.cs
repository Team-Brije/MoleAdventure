using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarTalisman : PoolManager
{
    //Disparo
    private float ultimoDisparo;
    [Range(0, 1)]
    [SerializeField] private float cooldown;//Tiempo max recarga
    private float tiempoDRecarga; //Esto es el tiempo en vivo de la recarga

    [SerializeField] Transform jugador;

    [SerializeField] KeyCode tecla;

    private void Awake()
    {
        ultimoDisparo = Time.time;
    }
    void Update()
    {
        //Disparar
        if (Input.GetKey(tecla)) 
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
    }
    public override GameObject PedirObjeto()
    {
        GameObject Objeto = base.PedirObjeto();
        Objeto.transform.position = transform.position;
        Objeto.transform.rotation = jugador.rotation;
        Objeto.SetActive(true);
        //Objeto.GetComponent<Bala>().Disparar(jugador);

        return Objeto;
    }
    
}



