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
    Animator animator;
    bool takingDamage=>rb.IsTouching(damage);
    private void Start() {
        PlayerLife = 3;
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isNotHurt", true);
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
        if (canTakeDamage)
        {
            StartCoroutine(TDXD());
            StartCoroutine(AnimStop());
            animator.SetTrigger("isHurt");
        }
        if(PlayerLife <= 0){
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
        PlayerLife--;
        yield return new WaitForSeconds(2f);
        animator.SetBool("isNotHurt", true);
        canTakeDamage =true;
    }
    public void ReloadCurrentLevel(){
        canTakeDamage = true;
        PlayerLife = 3;
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