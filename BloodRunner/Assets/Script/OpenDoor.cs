using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    private bool playerDetected;
    public Transform doorPos;
    public float width;
    public float height;
    public GameObject textPressE;

    public LayerMask whatIsPlayer;
    [SerializeField] private string sceneName;
    SceneSwitch sceneSwitch;
    private void Start()
    {
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        textPressE = GameObject.FindWithTag("pressE");
    }

    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, whatIsPlayer);

        if(playerDetected == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("new scene");
                try
                {
                    textPressE.GetComponent<Text>().color = Color.clear;
                }
                catch
                {
                    print("Error");
                }
                    sceneSwitch.SwitchScene(sceneName);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }
}
