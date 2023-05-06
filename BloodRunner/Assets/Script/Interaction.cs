using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public AudioClip medicSound;
 
    [Header("Detection Parameters")]
    //Detection Point
    public Transform detectionPoint;
    //Detection Radius
    private const float detectionRadius = 0.2f;
    //Detection Layer
    public LayerMask detectionLayer;
    //cached trigger object
    public GameObject detectedObject;

    [Header("others")]
    //List of PickedUp medic
    [SerializeField] public static List<GameObject> pickedMedic = new List<GameObject>();
    
    void Update()
    {
        if(DetectObject())
        {
            if(InteractInput())
            {
                detectedObject.GetComponent<Medic>().Interact();
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius,detectionLayer);
        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }

    }

    public void PickUpItem(GameObject medic)
    {
        AudioSource.PlayClipAtPoint(medicSound, transform.position);
        pickedMedic.Add(medic);
        PermanentUI.perm.medic += 1;
        PermanentUI.perm.medicAmount.text = ("x") + PermanentUI.perm.medic.ToString();
    }


}
