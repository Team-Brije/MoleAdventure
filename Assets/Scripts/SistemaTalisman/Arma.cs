using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : PoolManager
{
    //Cadencia
    public float cadencia = 0.25f;
    //Disparo
    [SerializeField] private float ultimoDisparo;
    public float cooldown;
    [SerializeField] Transform jugador;
    [SerializeField] KeyCode kya;

    private void Awake()
    {
        ultimoDisparo = Time.time;


    }
    void Update()
    {
        //Disparar

            if (Input.GetKey(kya)) /////////////////////////////////////////////////////////////////
            {
                if (ultimoDisparo < Time.time)
                {
                    ultimoDisparo = Time.time + cadencia;
                    PedirObjeto();
                    cooldown = 0;
                }
            }
        

        cooldown += Time.deltaTime;
        cooldown = Mathf.Clamp(cooldown, 0, cadencia);
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



