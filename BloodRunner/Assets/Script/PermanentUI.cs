using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PermanentUI : MonoBehaviour
{
    public int blooddrop = 0;
    public int coin = 0;
    public int patient = 0;
    public Text bloodCount;
    public Text coinCount;
    public static int health = 10;
    public Text healthAmount;
    public int medic;
    public Text medicAmount;

    public static PermanentUI perm;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(!perm)
        {
            perm = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    private void Update()
    {
        //dead
        if (GameOver.gameOver)
        {
            Debug.Log("game over");
            Destroy(gameObject);
        }
        //end
        if(EndScene.endGame)
        {
            Debug.Log("game end");
            Destroy(gameObject);
        }
    }
    public void Reset()
    {
        health = 10;
        blooddrop = 0;
        coin = 0;
        coinCount.text = coin.ToString();
        bloodCount.text = blooddrop.ToString();
        Interaction.pickedMedic.Clear();
        PermanentUI.perm.medic = 0;
        PermanentUI.perm.medicAmount.text = ("x") + PermanentUI.perm.medic.ToString();
    }
}
