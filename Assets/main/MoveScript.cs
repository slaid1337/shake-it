using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private GameObject controller;
    public GameObject timer;
    private GameObject canvas;


    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("controller");
        StartCoroutine(NextMove());
        canvas = GameObject.FindGameObjectWithTag("Canvas");
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
        }
        Destroy(gameObject);
    }

}
