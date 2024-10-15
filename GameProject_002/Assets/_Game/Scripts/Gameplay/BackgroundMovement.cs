using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public Transform bgTf;
    public float speed;
    public float spawnLimit;
    public float spawnLength;

    private void Update()
    {
        if (GameManager.instance.isLost) return;
        if (GameManager.instance.isGamePause) return;

        bgTf.position += Vector3.left * Time.deltaTime * speed;

        if (bgTf.position.x < spawnLimit)
        {
            bgTf.position += Vector3.right * spawnLength;
        }
    }

}
