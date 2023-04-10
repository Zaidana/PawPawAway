using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static int life = 3;
    private int damage = 1;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart;
    public bool isAlive = true;
    
    public GameObject deathScreen;
    public GameObject winScreen;
    
    private Vector3 respawnPoint;
    public GameObject fallDetector;

    private void Start()
    {
        respawnPoint = transform.position;
        
    }

    private void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

        foreach (Image img in hearts)
        {
            img.sprite = EmptyHeart;
        }

        for (int i = 0; i < life; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Damage();
            Respawn();
            
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            respawnPoint = transform.position;
        }

        if (other.gameObject.CompareTag("House"))
        {
            winScreen.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Damage();
            StartCoroutine(GetHurt());
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }

    private void Respawn()
    {
        transform.position = respawnPoint;
        
    }

    public void Damage()
    {        
        if (!isAlive)
             return;
        life -= damage;
        
        if (life <=0)
        {
            isAlive = false;
            Destroy(gameObject,0.2f);
            deathScreen.SetActive(true);
          
        }
        
        
    }
}