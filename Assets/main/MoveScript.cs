using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private GameObject controller;
    public GameObject timer;
    private GameObject canvas;
    private GameObject bar;
    private float chargeValue;
    

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("controller");
        StartCoroutine(NextMove());
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        bar = GameObject.FindGameObjectWithTag("bar");
        chargeValue = 0;
    }

    private void Update()
    {
        bar.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(new Vector2(0,100),new Vector2(800,100),chargeValue);
        chargeValue += Time.deltaTime * 0.5f;
    }

    private IEnumerator NextMove()
    {
        yield return new WaitForSeconds(2f);
        GyroController ct = controller.GetComponent<GyroController>();
        if (ct.move < ct.movesCount)
        {
            ct.SpawnMove(ct.combo[ct.move]);
        }
        else
        {
            Instantiate(timer, canvas.transform);
            ct.move = 0;
            ct.comboCounter = 0;
            ct.text.text = "0";
        }
        bar.GetComponent<RectTransform>().sizeDelta = new Vector2(0,100);
        bar.GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }

}
