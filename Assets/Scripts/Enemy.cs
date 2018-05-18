using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : UnityEngine.MonoBehaviour
{
    public float enemySpeed;
    public float distToActive;

    public Transform EnemyStartPos;
    public GameObject character;
    public Character CharacterClass;
    public AudioSource takeDamageSound;

    private new Rigidbody2D rigidbody;

    void Start()
    {
        transform.position = EnemyStartPos.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, character.transform.position) <= distToActive)
        {
            transform.position = Vector2.MoveTowards(transform.position, character.transform.position, Time.deltaTime * enemySpeed);
        }
        if (Vector2.Distance(transform.position, character.transform.position) <= 0.75f)
        {
            CharacterClass.characterLives -= 1;
            PlayerPrefs.SetInt("livesCount", CharacterClass.characterLives);
            CharacterClass.characterSpeed = 6;
            takeDamageSound.Play();
            new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }
}
