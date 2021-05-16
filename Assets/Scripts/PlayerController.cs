using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Properties")]
    public float speed;
    public Rigidbody2D rb;
    public float jumpForce;

    public GameObject winTextGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        rb.gravityScale = 10f;
        yield return new WaitForSeconds(0.3f);
        rb.gravityScale = 2f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BlueBox") {
            winTextGo.SetActive(true);
        }
        if (other.gameObject.tag == "Death")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
