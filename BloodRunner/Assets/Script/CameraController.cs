using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private AudioSource city;
    public Transform player;

    private void Start()
    {

        city = GetComponent<AudioSource>();
    }
    private void Update()
    {
        transform.position = new Vector2(player.position.x,transform.position.z);
    }
    private void citySound()
    {
        city.Play();
    }
}
