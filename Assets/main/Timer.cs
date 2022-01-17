using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    private Text text;
    public GameObject third;
    public GameObject fourth;
    private GameObject controller;

    private void Start()
    {
        text = gameObject.GetComponentInChildren<Text>();

        controller = GameObject.FindGameObjectWithTag("controller");
        third = controller.GetComponent<GyroController>().third;
        fourth = controller.GetComponent<GyroController>().fourth;

        if (PlayerPrefs.GetString("firstPlay") == "")
        {
            Time.timeScale = 0;
            third.SetActive(true);
            fourth.SetActive(true);
            controller.GetComponent<GyroController>().bgTutor.SetActive(true);
            PlayerPrefs.SetString("firstPlay", "1");
        }
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
