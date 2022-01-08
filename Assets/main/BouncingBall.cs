using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{   
    private AudioSource aud;


    private void Start()
    {       
        aud = gameObject.GetComponent<AudioSource>();
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "border")
        {
            aud.Play();
        }
    }




}
