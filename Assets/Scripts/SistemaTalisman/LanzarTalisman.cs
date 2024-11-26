using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanzarTalisman : PoolManager
{
    [SerializeField] Transform lanzadorDeTalismanes;

    [SerializeField] KeyCode teclaDisparar;
    [SerializeField] KeyCode teclaPegar;

    [Header ("Cooldown")]
    private float ultimoDisparo;
    [Range(0, 1)]
    [SerializeField] private float cooldown; //Tiempo max recarga
    private float tiempoDRecarga; //Esto es el tiempo en vivo de la recarga

    [Header("Municion")]
    [Range(0, 10)]
    [SerializeField] public int municionMax;
    public int municionActual;
    public TextMeshProUGUI municionTexto;

    private bool pegar;


    private void Awake()
    {
        ultimoDisparo = Time.time;
    }
    private void Start()
    { 
        municionActual = municionMax; 
        ActualizarMunicionUI();
    }
    void Update()
    {
        if (Input.GetKey(teclaDisparar) && municionActual>0) 
        {
            if (ultimoDisparo < Time.time)
            {
                pegar = false;
                ultimoDisparo = Time.time + cooldown;
                PedirObjeto();
                tiempoDRecarga = 0;
                municionActual--;
                ActualizarMunicionUI();
            }
        }
        if (Input.GetKey(teclaPegar) && municionActual > 0)
        {
            if (ultimoDisparo < Time.time)
            {
                pegar = true;
                ultimoDisparo = Time.time + cooldown;
                PedirObjeto();
                tiempoDRecarga = 0;
                municionActual--;
                ActualizarMunicionUI();
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
        Objeto.SetActive(true);
        Objeto.GetComponent<TalismanVolando>().Disparar(lanzadorDeTalismanes, pegar);

        return Objeto;
    }
    void ActualizarMunicionUI()
    {
        municionTexto.text = municionActual.ToString();
    }
}



