using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitBehaviour : MonoBehaviour
{
    LifeManager lifeManager;
    GameObject Player;
    public Transform placeback;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        lifeManager = Player.GetComponent<LifeManager>();
    }

    private void Update()
    {
        if (lifeManager.gameover)
        {
            StopAllCoroutines();
            Player.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Damage());
        }
    }

    public IEnumerator Si()
    {
        yield return new WaitForSeconds(1f);
        Player.SetActive(true);
    }

    public IEnumerator Damage()
    {
        lifeManager.TakeDamage();
        Player.SetActive(false);
        yield return new WaitForSeconds(1f);
        Player.SetActive(true);
        yield return new WaitForEndOfFrame();
        Player.transform.position = placeback.position;
    }
}
