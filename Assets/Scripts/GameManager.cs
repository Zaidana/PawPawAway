using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText;
    private static int score = 0;

        
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: " + score.ToString();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint()
    {
        score += 100;
        scoreText.text = "Score: " + score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Start");
        
    }

    
}
