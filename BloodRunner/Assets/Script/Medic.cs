using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Medic : MonoBehaviour
{
    //interaction type
    public enum InteractionType {none,PickUp,Examine}
    public InteractionType type;
    
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
    }
    
    public void Interact()
    {
        switch(type)
        {
            case InteractionType.PickUp:
                //add the object to the PickedUpItem list
                FindObjectOfType<Interaction>().PickUpItem(gameObject);
                //disable obj
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                Debug.Log("Examine");
                break;
            default:
                Debug.Log("Null Item");
                break;
        }
    }
}
