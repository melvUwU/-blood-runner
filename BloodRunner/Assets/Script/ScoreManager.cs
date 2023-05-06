using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int coinScore = 0;
    public int bloodScore = 0;
    public int patientScore = 0;
    public int totalPoint = 0;
    public Text coinCountTotal;
    public Text bloodCountTotal;
    public Text patientCountTotal;
    public Text totalPointText;
    public static ScoreManager sm;
    // Start is called before the first frame update
    void Start()
    {
        coinScore = 0;
        bloodScore = 0;
        patientScore = 0;
        totalPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bloodCountTotal.text = ("x ") + PermanentUI.perm.blooddrop.ToString();
        coinCountTotal.text = ("x ") + PermanentUI.perm.coin.ToString();
        totalPoint = PermanentUI.perm.coin + (PermanentUI.perm.blooddrop * 3)+(PermanentUI.perm.patient * 100);
        patientCountTotal.text = PermanentUI.perm.patient.ToString();
        totalPointText.text = totalPoint.ToString();
    }

}
