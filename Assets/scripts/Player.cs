using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float jumpForce = 200f;

    [SerializeField]
    TextMeshProUGUI score;
    [SerializeField]
    TextMeshProUGUI GameOverText;
    [SerializeField]
    TextMeshProUGUI timeText;
    [SerializeField]
    TextMeshProUGUI hSText;
    [SerializeField]
    GameObject[] lives;

    public int health;
    public int puntuation = 0;
    public float timePlayed;

    public bool gameOver;
    [SerializeField]
    public AudioSource coin;
    [SerializeField]
    AudioSource jump;
    [SerializeField]
    AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.gameObject.SetActive(false);
        hSText.gameObject.SetActive(false);
        gameOver = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        health = lives.Length;
    }

    // Update is called once per frame
    void Update()
    {
        timePlayed += Time.deltaTime;
        timeText.text = "Time: " + Mathf.RoundToInt(timePlayed);
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpForce);
                jump.Play();
            }
            score.text = "Score: " + puntuation;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }
        }

    }

    public void LostLife()
    {
        Destroy(lives[health-1]);
        health -= 1;
        hit.Play();
        if(health == 0)
        {
            if(PlayerPrefs.GetInt("HighScore",0) < puntuation)
            {
                hSText.gameObject.SetActive(true);
                PlayerPrefs.SetInt("HighScore", puntuation);
            }
            gameOver = true;
            GameOverText.gameObject.SetActive(true);
            StartCoroutine(LoadMenu());
        }
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }

}
