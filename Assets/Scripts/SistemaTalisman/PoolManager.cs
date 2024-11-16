using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject objeto;
    public List<GameObject> objetosCreados;

    private void Awake()
    {
        objetosCreados = new List<GameObject>();
    }
    public virtual GameObject PedirObjeto()
    {
        for (int i = 0; i < objetosCreados.Count; i++)
        {
            if (!objetosCreados[i].activeInHierarchy)
            {
                return objetosCreados[i];
            }
        }
        GameObject nuevo = CrearObjeto();
        objetosCreados.Add(nuevo);
        return nuevo;
    }
   

    public GameObject CrearObjeto()
    {
        return Instantiate(objeto);
    }

    public virtual GameObject PedirObjetoHijo(Transform padre)
    {
        for (int i = 0; i < objetosCreados.Count; i++)
        {
            if (!objetosCreados[i].activeInHierarchy)
            {
                return objetosCreados[i];
            }
        }
        GameObject nuevo = CrearObjetoHijo(padre);
        objetosCreados.Add(nuevo);
        return nuevo;
    }


    public GameObject CrearObjetoHijo(Transform padre)
    {
        return Instantiate(objeto, padre);
    }

}
