using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorControl : MonoBehaviour
{
    public Text doorText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject doorText = GameObject.FindWithTag("pressE");
            if (GameObject.FindWithTag("pressE") != null)
            {
                doorText.GetComponent<Text>().color = Color.white;
            }
           
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
 
        if (collision.tag == "Player")
        {
            
            GameObject doorText = GameObject.FindWithTag("pressE");
            if (GameObject.FindWithTag("pressE"))
            {
                doorText.GetComponent<Text>().color = Color.clear;
            }
        }

    }
}
