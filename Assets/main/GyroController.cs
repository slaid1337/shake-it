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
    public GameObject canvas;
    private Color[] bgColors = new Color[5];
    public GameObject bg;
    private int globalPoints;
    private int colorCounter;
    public GameObject markParent;
    public GameObject startBG;
    [HideInInspector]
    public int comboCounter;
    public Color[] ballColors;
    private GameObject[] balls;
    public GameObject inputName;
    public InputField fieldName;
    public Text placeHolderName;
    public Text markText;
    public GameObject scoreTable;
    [Header("stars")]
    public GameObject[] stars;
    public GameObject[] emptyStars;
    [Header("buttons")]
    public GameObject startButton;
    public GameObject tableButton;
    public GameObject tableCloseButton;
    public Text tableButtonText;
    public GameObject nextButton;
    [Header("localization")]
    public GameObject localisation;
    private string currentLanguage;
    [Header("tutorial")]
    public GameObject bgTutor;
    public GameObject canvasTutor;
    public GameObject third;
    public GameObject fourth;
    [Header("ads")]    
    public GameObject adController;
    private int countPlays;


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
        countPlays = 0;

        balls = GameObject.FindGameObjectsWithTag("ball");
                        
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
            
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].SetActive(false);
            }
        }       

        if (!PlayerPrefs.HasKey("Language"))
        {
            if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian)
            {
                PlayerPrefs.SetString("Language", "Russian");
            }
            else
            {
                PlayerPrefs.SetString("Language", "English");
            }
        }
        currentLanguage = PlayerPrefs.GetString("Language");
        localisation.GetComponent<Lean.Localization.LeanLocalization>().CurrentLanguage = currentLanguage;
    }

    public void StartTutor()
    {
        bgTutor.SetActive(true);
        canvasTutor.SetActive(true);
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
        movesCount = Random.Range(2, maxMovesCount + 1);
        tableButton.SetActive(false);
        startBG.SetActive(false);
        CreateCombo();
        SpawnMove(combo[move]);
    }

    public void Awake()
    {
        UpdateScoreNumber();
    }    

    public void UpdateScoreNumber()
    {
        tableButton.GetComponent<Button>().onClick.Invoke();
        tableCloseButton.GetComponent<Button>().onClick.Invoke();
        tableButtonText.text = (scoreTable.GetComponent<ScoreTable>().playerIndexInTable + 1).ToString();
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
            markParent.SetActive(true);
            markText.text = points.ToString();
            globalPoints += points;
            move = 0;
            gameIsWorking = false;
            PlayerPrefs.SetInt("points", globalPoints);
            PlayerPrefs.Save();
            yield return new WaitForSeconds(1f);
            text.gameObject.SetActive(false);
            switch (Formula(points, combo))
            {
                case 0:
                    nextButton.SetActive(true);
                    break;
                case 1:
                    stars[2].SetActive(true);
                    emptyStars[2].SetActive(false);
                    stars[2].GetComponent<Animator>().SetBool("enter", true);
                    yield return new WaitForSeconds(0.1f);
                    stars[2].GetComponent<Animator>().SetBool("enter", false);
                    yield return new WaitForSeconds(1f);
                    nextButton.SetActive(true);
                    break;
                case 2:
                    stars[2].SetActive(true);
                    emptyStars[2].SetActive(false);
                    stars[2].GetComponent<Animator>().SetBool("enter", true);
                    yield return new WaitForSeconds(0.1f);
                    stars[2].GetComponent<Animator>().SetBool("enter", false);
                    yield return new WaitForSeconds(1f);
                    stars[1].SetActive(true);
                    emptyStars[1].SetActive(false);
                    stars[1].GetComponent<Animator>().SetBool("enter", true);
                    yield return new WaitForSeconds(0.1f);
                    stars[1].GetComponent<Animator>().SetBool("enter", false);
                    yield return new WaitForSeconds(1f);
                    nextButton.SetActive(true);
                    break;
                case 3:
                    stars[2].SetActive(true);
                    emptyStars[2].SetActive(false);
                    stars[2].GetComponent<Animator>().SetBool("enter", true);
                    yield return new WaitForSeconds(0.1f);
                    stars[2].GetComponent<Animator>().SetBool("enter", false);
                    yield return new WaitForSeconds(1f);
                    stars[1].SetActive(true);
                    emptyStars[1].SetActive(false);
                    stars[1].GetComponent<Animator>().SetBool("enter", true);
                    yield return new WaitForSeconds(0.1f);
                    stars[1].GetComponent<Animator>().SetBool("enter", false);
                    yield return new WaitForSeconds(1f);
                    stars[0].SetActive(true);
                    emptyStars[0].SetActive(false);
                    stars[0].GetComponent<Animator>().SetBool("enter", true);
                    yield return new WaitForSeconds(0.1f);
                    stars[0].GetComponent<Animator>().SetBool("enter", false);
                    yield return new WaitForSeconds(1f);
                    nextButton.SetActive(true);
                    break;
            }            
            points = 0;
            countPlays++;
            if (countPlays % 2 == 0)
            {
                adController.GetComponent<AdController>().ShowAd();
            }
        }
    }
   
    public void StopMove()
    {        
        text.text = globalPoints.ToString();
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(false);
            emptyStars[i].SetActive(true);
        }
        markParent.SetActive(false);
        startButton.SetActive(true);
        tableButton.SetActive(true);
        startBG.SetActive(true);
        UpdateScoreNumber();
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
        
        if (pointsForGame >= count + 8)
        {
            return 3;
        }
        else if (pointsForGame >= count)
        {
            return 2;
        }
        else if (pointsForGame < count && pointsForGame >= count - 10)
        {
            return 1;
        }        
        return 0;
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
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].SetActive(true);
            }
        }
    }

    public void PouseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}

//combo number


//доделать рекламу
//добавить inApp чтобы убирать рекламу
