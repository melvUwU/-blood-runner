using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    public static Animator pState;
    
    
    // Start is called before the first frame update
    void Start()
    {
        pState = GetComponent<Animator>();
    }
    public static void recover()
    {
        
        pState.SetBool("pState", true);
        
    }
    
}
