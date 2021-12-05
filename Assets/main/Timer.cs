using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    private Text text;

    private void Start()
    {
        text = gameObject.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        int tm = System.Convert.ToInt32(time);
        text.text = tm.ToString();
        time -= Time.deltaTime;
        if (time < 1f)
        {
            GyroController gc = GameObject.FindGameObjectWithTag("controller").GetComponent<GyroController>();
            gc.StartMoves();
            Destroy(gameObject);
        }
    }
}
