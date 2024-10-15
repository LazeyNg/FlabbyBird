using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private Transform birdTf;
    private Vector3 direction;
    public float gravityStrength = -0.2f;
    public float upStrength = 10f;

    [Header("Anim")]
    public SpriteRenderer birdRend;
    public List<Sprite> birdSprs;
    public List<ScriptableBird> birdScriptables;

    [Header("Death")]
    public GameObject explosion;

    private void Start()
    {
        birdSprs = birdScriptables[PlayerPrefs.GetInt("Bird", 0)].birdSprs;
        StartCoroutine(IEBirdAnim());
    }

    public void ChangeBirds()
    {
        birdSprs = birdScriptables[PlayerPrefs.GetInt("Bird", 0)].birdSprs;
        birdRend.sprite = birdSprs[0];
    }

    IEnumerator IEBirdAnim()
    {
        int sprIndex = 0;
        
        while (!GameManager.instance.isLost)
        {
            if (!GameManager.instance.isGamePause)
            {
                birdRend.sprite = birdSprs[sprIndex];
                sprIndex++;
                if (sprIndex >= birdSprs.Count) sprIndex = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
        // Animation For Death
    }

    private void Update()
    {
        if (GameManager.instance.isLost) return;
        if (GameManager.instance.isGamePause) return;
        if (!GameManager.instance.isGameStart) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GoUp();
        }

        if (GameManager.instance.isGameStart) direction += Vector3.up * gravityStrength;
        birdTf.position += direction * Time.deltaTime;
    }
    public void GoUp()
    {
        direction = Vector3.up * upStrength;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            // birdRend.color = Color.red;
            GameManager.instance.Lose();

            explosion.SetActive(true);
            explosion.transform.position = this.transform.position;
            this.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Point"))
        {
            GameManager.instance.Score();
        }
    }



}
