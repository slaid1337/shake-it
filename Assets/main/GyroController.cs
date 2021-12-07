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
    public float forceY;
    public float forceX;
    private bool toRight;
    private bool toLeft;
    private bool switcher;
    [HideInInspector]
    public bool gameIsWorking;
    public int movesCount;
    public GameObject[] moves;
    [HideInInspector]
    public int[] combo;
    [HideInInspector]
    public int move;
    private GameObject canvas;
    private Color[] bgColors = new Color[2];
    private GameObject bg;    
    private int globalPoints;
    private GameObject startButton;
    public GameObject[] scores;


    private void Start()
    {        
        gyro = Input.gyro;
        gyro.enabled = true;
        points = 0;
        toTop = true;
        toBottom = false;
        toRight = true;
        toLeft = false;
        switcher = false;
        gameIsWorking = false;
        move = 0;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        bg = GameObject.FindGameObjectWithTag("bg");
        startButton = GameObject.FindGameObjectWithTag("startButton");

        bgColors[0] = new Color(0.62f, 0.170f, 0.194f,1);
        bgColors[1] = new Color(0.159f, 0.44f, 0.49f,1);
        globalPoints = 0;
    }
    private void Update()
    {
        if (gameIsWorking)
        {
            Shake();
        }       
    }

    private void Shake()
    {
        if (switcher)
        {
            if (Input.acceleration.y >= forceY && toTop)
            {
                points++;
                text.text = points.ToString();
                toTop = false;
                toBottom = true;
            }
            else if (Input.acceleration.y <= -forceY && toBottom)
            {
                points++;
                text.text = points.ToString();
                toTop = true;
                toBottom = false;                
            }
        }
        else
        {
            if (Input.acceleration.x >= forceX && toRight)
            {
                points++;
                text.text = points.ToString();
                toRight = false;
                toLeft = true;
            }
            else if (Input.acceleration.x <= -forceX && toLeft)
            {
                points++;
                text.text = points.ToString();
                toRight = true;
                toLeft = false;
            }           
        }
    }

    public void StartGame()
    {        
        text.gameObject.SetActive(true);
        CreateCombo();
        SpawnMove(combo[move]);        
    }

    public void SpawnMove(int moveIndex)
    {
        Instantiate(moves[moveIndex],canvas.transform);
        move++;
        if (move % 2 == 0)
        {
            bg.GetComponent<Image>().color = bgColors[0];            
        }
        else
        {
            bg.GetComponent<Image>().color = bgColors[1];            
        }
    }

    public void CreateCombo()
    {        
        int[] arr = new int[movesCount];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Range(0, 2);
        }
        combo = arr;
    }

    public void StartMoves()
    {
        gameIsWorking = true;
        if (move % 2 == 0)
        {
            bg.GetComponent<Image>().color = bgColors[0];
        }
        else
        {
            bg.GetComponent<Image>().color = bgColors[1];
        }
        if (combo[move] == 0) switcher = true;
        else switcher = false;
        move++;
        if (move < movesCount) StartCoroutine(NextMove());
    }

    private IEnumerator NextMove()
    {        
        yield return new WaitForSeconds(2f);
        if (move % 2 == 0)
        {
            bg.GetComponent<Image>().color = bgColors[0];
        }
        else
        {
            bg.GetComponent<Image>().color = bgColors[1];
        }
        if (combo[move] == 0) switcher = true;
        else switcher = false;
        move++;
        if (move < movesCount) StartCoroutine(NextMove());
        else
        {
            yield return new WaitForSeconds(2f);
            Instantiate(scores[Formula(points, combo)], canvas.transform);            
            text.gameObject.SetActive(false);
            globalPoints += points;
            points = 0;
            move = 0;
            gameIsWorking = false;
            Debug.Log(globalPoints);
            yield return new WaitForSeconds(3f);
            Destroy(GameObject.FindGameObjectWithTag("score"));
            startButton.SetActive(true);
        }
    }

    private int Formula(int pointsForGame,int[] arr)
    {  
        int count = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == 0)
            {
                count += 15;
            }
            else
            {
                count += 10;
            }
        }
        if (pointsForGame >= count)
        {
            return 0;
        }
        else if (pointsForGame < count && pointsForGame > count - 10)
        {
            return 1;
        }
        return 2;
    }
}
