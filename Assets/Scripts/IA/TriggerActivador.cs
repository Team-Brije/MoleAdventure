using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerActivador : MonoBehaviour
{
    public GuardianIA guardian;
    public void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            guardian.playerIsClose = true;
            guardian.Persiguiendo(collision.gameObject.transform);
        }
    }
    public void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            guardian.playerIsClose=false;
        }
    }
}
