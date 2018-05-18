using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : UnityEngine.MonoBehaviour
{
    public float characterSpeed;
    public int flowers;
    public int needToGetFlowers; //63 points on first level, 110 points on second level
    public int characterLives = 3;

    public Transform CharacterStartPos;
    public Text FlowersCount;
    public Text LivesCount;
    public GameObject FastBoost;
    public GameObject SlowBoost;
    public GameObject HealthBoost;
    public GameObject LoserPanel;
    public GameObject winCongrats;
    public Flower flower;

    private new Rigidbody2D rigidbody;

    void Start()
    {
        int rndBoost = Random.Range(1, 4);
        PlayerPrefs.SetInt("boost", rndBoost);
        int chooseRandomBoost = PlayerPrefs.GetInt("boost");
        PlayerPrefs.DeleteKey("flowersCount");
        PlayerPrefs.SetInt("livesCount", characterLives);
        transform.position = CharacterStartPos.position;
        rigidbody = GetComponent<Rigidbody2D>();


        if (PlayerPrefs.GetInt("boost") == 1)
        {
            FastBoost.SetActive(true);
        }
        if (PlayerPrefs.GetInt("boost") == 2)
        {
            SlowBoost.SetActive(true);
        }
        if (PlayerPrefs.GetInt("boost") == 3)
        {
            HealthBoost.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(new Vector2(-characterSpeed, 0), ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(new Vector2(characterSpeed, 0), ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.AddForce(new Vector2(0, characterSpeed), ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.AddForce(new Vector2(0, -characterSpeed), ForceMode2D.Force);
        }

        if (!Input.anyKey)
        {
            rigidbody.velocity = new Vector2(0, 0);
        }

        Lose();
    }

    private void Update()
    {
        FlowersCount.text = PlayerPrefs.GetInt("flowersCount").ToString();
        LivesCount.text = PlayerPrefs.GetInt("livesCount").ToString();

        if ((flowers == 63) && (Application.loadedLevelName == "stage_1"))
        {
            Application.LoadLevel("stage_2");
        }
        else if ((flowers == 110) && (Application.loadedLevelName == "stage_2"))
        {
            Application.LoadLevel("stage_3");
        }
        else if ((flowers == 41) && (Application.loadedLevelName == "stage_3"))
        {
            winCongrats.SetActive(true);
            new WaitForSeconds(10);
            Application.LoadLevel("stage_1");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void Lose()
    {
        if (characterLives <= 0)
        {
            Time.timeScale = 0.0001f;
            LoserPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "flower")
        {
            flower.TakeSound();
            flowers += 1;
            PlayerPrefs.SetInt("flowersCount", flowers);
            Destroy(coll.gameObject);
        }

        if (coll.tag == "fastBoost")
        {
            characterSpeed = 9;
            FastBoost.SetActive(false);
        }

        if (coll.tag == "slowBoost")
        {
            characterSpeed = 3;
            Destroy(coll.gameObject);
        }

        if (coll.tag == "healthBoost")
        {
            if (characterLives < 3)
            {
                characterLives += 1;
                Destroy(coll.gameObject);
                PlayerPrefs.SetInt("livesCount", characterLives);
            }
        }
    }
}
