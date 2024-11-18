using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.VFX;

public class Talisman: MonoBehaviour
{
    public enum TalismanType
    {
        Static,
        Floating
    }

    public TalismanType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //LanzarTalisman ltJugador = collision.gameObject.GetComponent<LanzarTalisman>();
            LanzarTalisman ltJugador = collision.gameObject.GetComponentInChildren<LanzarTalisman>();
            if (ltJugador.municionActual < ltJugador.municionMax)
            {
                gameObject.SetActive(false);
                ltJugador.municionActual++;
            }
        }

        if (collision.gameObject.CompareTag("Enemy") && type == TalismanType.Floating)
        {
            collision.gameObject.SetActive(false);
            //Le hace dano al guardian y se desactiva
            gameObject.SetActive(false);
        }
    }

}
