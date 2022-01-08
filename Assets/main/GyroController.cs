using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroController : MonoBehaviour
{    
    public Text text;
    public int points;
    private bool toTop;
    private bool toBottom;
    public float forceY;
    public float forceX;
    private bool toRight;
    private bool toLeft;
    private bool switcher;
    [HideInInspector]
    public bool gameIsWorking;
    [HideInInspector]
    public int movesCount;
    public int maxMovesCount;
    public GameObject[] moves;
    [HideInInspector]
    public int[] combo;
    [HideInInspector]
    public int move;
    private GameObject canvas;
    private Color[] bgColors = new Color[5];
    public GameObject bg;    
    private int globalPoints;
    private GameObject startButton;
    public GameObject[] scores;    
    private int colorCounter;
    public GameObject markParent;
    private GameObject tableButton;
    public GameObject startBG;
    [HideInInspector]
    public int comboCounter;
    public Color[] ballColors;
    private GameObject[] balls;
    public GameObject inputName;
    public InputField fieldName;
    public Text placeHolderName;
    
    
    private void Start()
    {  
        colorCounter = 0;
        points = 0;
        toTop = true;
        toBottom = false;
        toRight = true;
        toLeft = false;
        switcher = false;
        gameIsWorking = false;
        move = 0;
        canvas = GameObject.FindGameObjectWithTag("Canvas");

        balls = GameObject.FindGameObjectsWithTag("ball");
        
        startButton = GameObject.FindGameObjectWithTag("startButton");
        tableButton = GameObject.FindGameObjectWithTag("tableButton");
        
        movesCount = Random.Range(2, maxMovesCount + 1);
        comboCounter = 0;

        bgColors[0] = new Color(0.62f, 0.170f, 0.194f,1);
        bgColors[1] = new Color(0.159f, 0.44f, 0.49f,1);
        bgColors[2] = new Color(0f, 0.222f, 0.173f, 1);
        bgColors[3] = new Color(0.255f, 0.128f, 0.26f, 1);
        bgColors[4] = new Color(0.200f, 0.218f, 0.221f, 1);
        globalPoints = PlayerPrefs.GetInt("points");

        text.text = globalPoints.ToString();

        if (PlayerPrefs.GetString("name") == "")
        {
            inputName.SetActive(true);
        }
    }
    private void Update()
    {
        if (gameIsWorking)
        {
            Shake();
        }        
    }

    private void FixedUpdate()
    {
        Physics2D.gravity = Input.acceleration * 40;
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
        tableButton.SetActive(false);
        startBG.SetActive(false);
        CreateCombo();
        SpawnMove(combo[move]);        
    }

    public void SpawnMove(int moveIndex)
    {
        Instantiate(moves[moveIndex],canvas.transform);

        move++;

        int ranColor = 0;

        if (colorCounter % 5 == 0) ranColor = 0;
        else if (colorCounter % 4 == 0) ranColor = 1;
        else if (colorCounter % 3 == 0) ranColor = 2;
        else if (colorCounter % 2 == 0) ranColor = 3;
        else ranColor = 4;
        colorCounter++;
        bg.GetComponent<SpriteRenderer>().color = bgColors[ranColor];
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].GetComponent<SpriteRenderer>().color = ballColors[ranColor];
        }

        comboCounter++;

        text.text = "combo step: " +  comboCounter.ToString();

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
        int ranColor = 0;
        if (colorCounter % 5 == 0) ranColor = 0;
        else if (colorCounter % 4 == 0) ranColor = 1;
        else if (colorCounter % 3 == 0) ranColor = 2;
        else if (colorCounter % 2 == 0) ranColor = 3;
        else ranColor = 4;
        colorCounter++;
        bg.GetComponent<SpriteRenderer>().color = bgColors[ranColor];
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].GetComponent<SpriteRenderer>().color = ballColors[ranColor];
        }


        if (combo[move] == 0) switcher = true;
        else switcher = false;
        move++;
        if (move < movesCount) StartCoroutine(NextMove());
    }  

    private IEnumerator NextMove()
    {        
        yield return new WaitForSeconds(2f);
        int ranColor = 0;
        if (colorCounter % 5 == 0) ranColor = 0;
        else if (colorCounter % 4 == 0) ranColor = 1;
        else if (colorCounter % 3 == 0) ranColor = 2;
        else if (colorCounter % 2 == 0) ranColor = 3;
        else ranColor = 4;
        colorCounter++;
        bg.GetComponent<SpriteRenderer>().color = bgColors[ranColor];
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].GetComponent<SpriteRenderer>().color = ballColors[ranColor];
        }


        if (combo[move] == 0) switcher = true;
        else switcher = false;
        move++;
        if (move < movesCount) StartCoroutine(NextMove());        
        else
        {
            yield return new WaitForSeconds(2f);
            Instantiate(scores[Formula(points, combo)], markParent.transform);
            markParent.SetActive(true);            
            StartCoroutine(StopMove());
            
            globalPoints += points;
            points = 0;
            move = 0;
            gameIsWorking = false;            
            PlayerPrefs.SetInt("points", globalPoints);
            PlayerPrefs.Save();
        }
    }
   
    private IEnumerator StopMove()
    {        
        yield return new WaitForSeconds(3f);
        text.text = globalPoints.ToString();
        Destroy(GameObject.FindGameObjectWithTag("score"));
        markParent.SetActive(false);
        startButton.SetActive(true);
        tableButton.SetActive(true);
        startBG.SetActive(true);
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

    public void ApplyName()
    {
        string tempText = fieldName.text;

        if (tempText.Length > 8)
        {
            fieldName.text = "";
            placeHolderName.color = new Vector4(1, 0, 0, 1);           
            placeHolderName.text = "max 8 symbols!";
        }
        else if (tempText.Length <= 0)
        {
            placeHolderName.color = new Vector4(1, 0, 0, 1);
            placeHolderName.text = "Enter name!";
        }
        else
        {
            PlayerPrefs.SetString("name", fieldName.text);
        }        
    }
}