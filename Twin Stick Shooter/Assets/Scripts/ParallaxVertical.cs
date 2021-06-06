using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxVertical : MonoBehaviour
{
    public float speed = 20f;
    public float yLimite = -10f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= yLimite)
        {
            this.transform.position = new Vector3(0f, yLimite * -1f, 0f);
        }
    }
}
