using UnityEngine;

public class pietrigger : MonoBehaviour
{
        public LayerMask groundNombre;
    public void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.layer == groundNombre){
            Debug.Log("tocando layer"+collision.gameObject.layer);
        }
    }
}
