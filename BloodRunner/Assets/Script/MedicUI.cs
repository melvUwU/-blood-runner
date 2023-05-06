using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedicUI : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject doorText = GameObject.FindWithTag("medicE");
            if (GameObject.FindWithTag("medicE") != null)
            {
                doorText.GetComponent<Text>().color = Color.white;

            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            GameObject doorText = GameObject.FindWithTag("medicE");
            if (GameObject.FindWithTag("medicE"))
            {
                doorText.GetComponent<Text>().color = Color.clear;
            }

        }

    }
}
