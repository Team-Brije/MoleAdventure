using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public static int PlayerLife = 3;
    public ContactFilter2D damage;
    public bool canTakeDamage = true;
    Rigidbody2D rb;
    bool takingDamage=>rb.IsTouching(damage);
    private void Start() {
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
    void TakeDamage(){
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
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}