using System.Collections;
using UnityEngine;

public class GuardianCorrrrruptoIA : MonoBehaviour
{
    [Tooltip("La velocidad a la que se moverá")]
    public float velocidad;
    [Tooltip("Establecer la distancia que se moverá, el [0] Tiene que ser positivo y el [1] Tiene que ser negativo")]
    public float[] MaxPositions;
    [Tooltip("Tiempo max para que el enemigo espere, va de 0 al establecido")]
    public float maxTimeWait;
    [Tooltip("La distancia del raycast")]
    public float dist;
    [Tooltip("El layer el cual se checara el raycast")]
    public LayerMask groundNombre;
    [Tooltip("El origen desde donde saldrá el raycast")]
    public Vector2[] rayCastsOrigins;
    [Tooltip("La fuerza de salto")]
    public float JumpForce;
    float startPos;
    bool isWaiting;
    Rigidbody2D enemyrb;
    Animator animator;
    [HideInInspector]
    public bool canJump=true;
    public bool playerIsClose=false;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

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
        GroundCheckJump();
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Caminando(){
        animator.SetTrigger("walkin");
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
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

    public void GroundCheckJump(){
        Vector2 origen1 = rayCastsOrigins[0]+ new Vector2(transform.position.x,transform.position.y);
        Vector2 origen2 = rayCastsOrigins[1]+ new Vector2(transform.position.x,transform.position.y);

        RaycastHit2D hit1 = Physics2D.Raycast(origen1, Vector2.down,dist,groundNombre);
        RaycastHit2D hit2 = Physics2D.Raycast(origen2, Vector2.down,dist,groundNombre);
            if(hit1.collider != null){canJump=true;
                }else{
                    if(canJump && isGrounded()){
                        enemyrb.AddForce(Vector2.up*JumpForce, ForceMode2D.Impulse);
                        canJump=false;
                    }
            }
            if(hit2.collider != null){canJump=true;
                }else{
                    if(canJump && isGrounded()){
                        enemyrb.AddForce(Vector2.up*JumpForce, ForceMode2D.Impulse);
                        canJump=false;
                    }
        }
    }
    public void Saltoxd(){
        enemyrb.AddForce(Vector2.up*JumpForce*2, ForceMode2D.Impulse);
    }
    [ExecuteInEditMode]
    void OnDrawGizmos(){
        Vector2 origen1 = rayCastsOrigins[0]+ new Vector2(transform.position.x,transform.position.y);
        Vector2 origen2 = rayCastsOrigins[1]+ new Vector2(transform.position.x,transform.position.y);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(origen1,Vector2.down*dist);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(origen2,Vector2.down*dist);
    }
}
