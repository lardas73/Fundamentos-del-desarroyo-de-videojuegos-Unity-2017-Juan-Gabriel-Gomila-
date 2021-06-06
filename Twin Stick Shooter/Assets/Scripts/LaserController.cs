using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float lifeTime = 2f;
    public float speed = 5f;

    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        Destroy (gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
