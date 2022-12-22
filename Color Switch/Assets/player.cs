using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float jump = 10f;
    public string next_level;
    public Rigidbody2D rb;
    public Transform cmra;
    public SpriteRenderer sr;
    public string currentColor;
    public Color Blue;
    public SpriteRenderer blu;
    public Color Yellow;
    public SpriteRenderer yllw;
    public Color Pink;
    public SpriteRenderer jesse;
    public Color Purple;
    public SpriteRenderer prpl;
    public bool move;
    public void RandomColor()
    {
        int color = Random.Range(0, 4);
        string oldcolor = currentColor;
        if (color == 0)
        {
            sr.color = Blue;
            currentColor = "blu";
        }
        else if (color == 1)
        {
            currentColor = "yellow";
            sr.color = Yellow;
        }
        else if (color == 2)
        {
            currentColor = "jesse";
            sr.color = Pink;
        }
        else
        {
            currentColor = "purple";
            sr.color = Purple;
        }
        if (oldcolor == currentColor)
        {
            RandomColor();
        }
    }
    private void Start()
    {
        RandomColor();
        move = false;
    }
    public void game_over()
    {
        Debug.Log("game over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void winner()
    {
        SceneManager.LoadScene(next_level);
    }
    void Update()
    {
        if (move != true)
        {
            rb.Sleep();
        }
        else
        {
            rb.WakeUp();
        }
        if (cmra.position.y - 4.5 > transform.position.y || transform.position.y < 0)
        {
            move = false;
            rb.Sleep();
        }
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * jump;
            move = true;
            rb.WakeUp();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (currentColor != collision.tag && "color changer" != collision.tag)
        {
            game_over();
        }
        if (collision.tag == "color changer")
        {
            RandomColor();
            Destroy(collision);

        }
        if (collision.tag == "end")
        {
            winner();
        }
    }
}
