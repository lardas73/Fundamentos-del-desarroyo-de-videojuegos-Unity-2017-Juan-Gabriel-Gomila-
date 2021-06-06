using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    private Transform player;

    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerShip").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        direction.Normalize();
        this.transform.position += direction * speed * Time.deltaTime;
    }
}