using System.Collections;
using UnityEngine;

public class GuardianIA : MonoBehaviour
{
    Rigidbody2D enemyrb;
    public float velocidad;
    public float[] MaxPositions;
    public float maxTimeWait;
    float startPos;
    bool isWaiting;
    Animator animator;
    [HideInInspector]
    public bool playerIsClose=false;
    void Start()
    {
        enemyrb = this.GetComponent<Rigidbody2D>();
        startPos = this.transform.position.x;
        animator = this.GetComponent<Animator>();
        StartCoroutine(SemiPensamiento());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!playerIsClose){
            if(isWaiting){
                Esperando();
            }else{
                Caminando();
            }
        }
    }
    
    public void Caminando(){
        animator.SetTrigger("walkin");
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        Debug.Log("q1");
        Debug.Log(transform.localPosition.x > MaxPositions[0]);
        Debug.Log("q2");
        Debug.Log(transform.localPosition.x < MaxPositions[1]);
        if(transform.localPosition.x > MaxPositions[0]){
            SpinSpriteRight();
        }
        if(transform.localPosition.x < MaxPositions[1]){
            SpinSpriteLeft();
        }
    }
    public void SpinSpriteRight(){
        transform.eulerAngles = new Vector3(0,-180,0);
    }
    public void SpinSpriteLeft(){
        transform.eulerAngles = new Vector3(0,0,0);
    }

    public void Esperando(){
        animator.SetTrigger("nowalkin");
    }
    public IEnumerator SemiPensamiento(){
        isWaiting=true;
        yield return new WaitForSeconds(Random.Range(0,maxTimeWait));
        isWaiting =false;
        StartCoroutine(EsperarTimeOut());
    }

    public IEnumerator EsperarTimeOut(){
        yield return new WaitForSeconds(Random.Range(3,8));
        StartCoroutine(SemiPensamiento());
    }

    public virtual void Persiguiendo(Transform plyPos){
        animator.SetTrigger("walkin");
        if(plyPos.position.x <= transform.position.x){
        transform.Translate(Vector3.right*(velocidad*1.5f)*Time.deltaTime);
        transform.eulerAngles = new Vector3(0,-180,0);
        }
        if(plyPos.position.x >= transform.position.x){
        transform.Translate(Vector3.right*(velocidad*1.5f)*Time.deltaTime);
        transform.eulerAngles = new Vector3(0,0,0);
        }
    }
}
