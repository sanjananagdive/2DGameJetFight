using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;//to move in xaxis
    Rigidbody2D rb;

    bool movePlayer = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && movePlayer)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPos.x < 0)
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

            //blasting effect as soon as collision happens
            movePlayer = false;

            transform.GetChild(0).gameObject.SetActive(true);

            //Coroutine to restart game after 2 seconds
            StartCoroutine("ReloadScene");
            
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene("Game");
        
    }

}
