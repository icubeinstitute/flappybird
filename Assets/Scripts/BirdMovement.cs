using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite dieSprite;

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    AudioSource audios;

    [SerializeField]
    AudioClip dieAudioClip;

    bool isJumping = false;
    bool isAlive = true;

    void Start()
    {
        rb.velocity = Vector2.right * speed;
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }

        if (isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping=false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (isAlive)
        {
            audios.clip = dieAudioClip;
            audios.Play();
        }
        isAlive = false;
        GetComponent<Animator>().enabled = false;
        spriteRenderer.sprite = dieSprite;
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

}
