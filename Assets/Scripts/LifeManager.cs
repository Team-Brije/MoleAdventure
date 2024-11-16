using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public static int PlayerLife = 3;
    public bool gameover;
    public ContactFilter2D damage;
    public bool canTakeDamage = true;
    Rigidbody2D rb;
    public Transform spawnpoint;
    bool takingDamage=>rb.IsTouching(damage);
    private void Start() {
        PlayerLife = 3;
        rb=GetComponent<Rigidbody2D>();
    }
    private void Update() {
        print(PlayerLife);
    }
    private void FixedUpdate() {
        if(takingDamage==true && canTakeDamage == true){
            TakeDamage();
        }
    }
    public void TakeDamage(){
        StartCoroutine(TDXD());
        if(PlayerLife <= 0){
            gameOver();
        }
    }
    void gameOver(){
        print("game Over"); 
        ReloadCurrentLevel();
    }

    public IEnumerator TDXD(){
        canTakeDamage=false;
        PlayerLife--;
        yield return new WaitForSeconds(2f);
        canTakeDamage=true;
    }
    public void ReloadCurrentLevel(){
        PlayerLife = 3;
        gameObject.transform.position = spawnpoint.position;
        gameover = true;
        Invoke(nameof(fuck),0.01f);
    }

    public void fuck()
    {
        gameover = false;
    }
}