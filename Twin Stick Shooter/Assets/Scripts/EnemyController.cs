using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 2;

    void OnTriggerEnter2D(Collider2D other) {
        
        // El enemigo choca con el laser
        if(other.gameObject.CompareTag("Laser")){
            LaserController laser = other.gameObject.GetComponent<LaserController>();
            health -= laser.damage;
            Destroy (other.gameObject);
            if (health <=0){
                DestruirEnemigo();
            }
        }

        // El enemigo choca contra el jugador
        if(other.gameObject.CompareTag("Player")){

        }
    }

    void DestruirEnemigo(){
        GameController _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        _gameController.KillEnemy();
        Destroy (this.gameObject);
    }

    /*
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("he colisionado con : " + other.gameObject.name);
    }
    */
}
