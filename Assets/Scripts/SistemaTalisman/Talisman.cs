using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.VFX;

public class Talisman: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Jugador")|| collision.gameObject.GetComponent<LanzarTalisman>() != null)
        {
            LanzarTalisman ltJugador = collision.gameObject.GetComponent<LanzarTalisman>();
            if (ltJugador.municionActual < ltJugador.municionMax)
            {
                gameObject.SetActive(false);
                ltJugador.municionActual++;
            }
        }

        if (collision.gameObject.CompareTag("Enemigo") /*|| collision.gameObject.GetComponent<Guradian>() != null*/)
        {
            //Le hace dano al guardian y se desactiva
            gameObject.SetActive(false);
        }
    }

}
