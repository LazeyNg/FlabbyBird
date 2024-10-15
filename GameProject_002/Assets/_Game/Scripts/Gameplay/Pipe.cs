using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Transform pipeTf;
    public float speed;

    private void Start()
    {
        pipeTf.position = new Vector2(pipeTf.position.x, GetRandomY());
    }

    private void Update()
    {
        if (GameManager.instance.isLost || !GameManager.instance.isGameStart) return;
        if (GameManager.instance.isGamePause) return;

        pipeTf.position += Vector3.left * Time.deltaTime * speed;

        if (pipeTf.position.x <= -5)
        {
            pipeTf.position = new Vector2(10f, GetRandomY());
        }
    }

    private float GetRandomY()
    {
        return Random.Range(-1, 3);
    }
}
