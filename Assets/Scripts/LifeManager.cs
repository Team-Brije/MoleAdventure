using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int playerLife = 3;
    public bool gameover;
    public ContactFilter2D damage;
    public bool canTakeDamage = true;
    Rigidbody2D rb;
    public Transform spawnpoint;
    Animator animator;
    bool takingDamage=>rb.IsTouching(damage);
    public Slider lifeSlider; //UI
    private void Start() {
        playerLife = 3;
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isNotHurt", true);
        lifeSlider.maxValue = playerLife;
        lifeSlider.value = playerLife;
    }
    private void Update() {
        print(playerLife);
        lifeSlider.value = playerLife;
    }
    private void FixedUpdate() {
        if(takingDamage==true && canTakeDamage == true){
            TakeDamage();
        }
    }
    public void TakeDamage(){
        if (canTakeDamage)
        {
            StartCoroutine(TDXD());
            StartCoroutine(AnimStop());
            animator.SetTrigger("isHurt");
        }
        if(playerLife <= 0){
            gameOver();
        }
    }
    void gameOver(){
        print("game Over"); 
        ReloadCurrentLevel();
    }

    public IEnumerator AnimStop()
    {
        animator.SetBool("isNotHurt", false);
        yield return new WaitForSeconds(0.36f);
        animator.SetBool("isNotHurt", true);
    }

    public IEnumerator TDXD(){
        canTakeDamage=false;
        playerLife--;
        yield return new WaitForSeconds(2f);
        animator.SetBool("isNotHurt", true);
        canTakeDamage =true;
    }
    public void ReloadCurrentLevel(){
        canTakeDamage = true;
        playerLife = 3;
        gameObject.transform.position = spawnpoint.position;
        gameover = true;
        Invoke(nameof(fuck),0.01f);
    }

    public void fuck()
    {
        animator.SetBool("isNotHurt", true);
        gameover = false;
    }
}