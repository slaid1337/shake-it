using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroController : MonoBehaviour
{
    private Gyroscope gyro;
    public Text text;
    private int points;
    private bool toTop;
    private bool toBottom;

    private void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        points = 0;
        toTop = true;
        toBottom = false;
    }
    private void Update()
    {
        Debug.Log(Input.acceleration.y);
        if (Input.acceleration.y >= 2f && toTop)
        {
            points++;
            text.text = points.ToString();
            toTop = false;
            toBottom = true;
        }
        else if (Input.acceleration.y <= -2f && toBottom)
        {
            points++;
            text.text = points.ToString();
            toBottom = false;
            toTop = true;
        }
    }
}
