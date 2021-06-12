using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform enemy;

    [Header ("Oleadas de enemigos")]
    public float timeBeforeSpawning = 1.5f;
    public float timeBetweenEnemies = 0.25f;
    public float timeBetweenWaves = 2f;

    private int enemiesPerWare = 1;
    private int currentNuemberOfEnemies = 0;

    [Header ("Interfaz Grafica de Usuario")]
    private int score = 0;
    private int wave = 0;

    public Text scoreText;
    public Text waveText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (SpawnEnemies());
    }

    IEnumerator SpawnEnemies(){
        // Indicamos que queremos esperar "timeBeforeSpawning" segundos antes de empezar la coorrutina
        yield return new WaitForSeconds (timeBeforeSpawning);
        // Despues de ese tiempo de espera inicial, arrancamos el bucle de las oleadas
        while (true){
            // No crees nada hasta que la oleada de enemigos previa haya sido eleminada
            if (currentNuemberOfEnemies <= 0){
                // No quedan enemigos. hay que crear 10 nuevos enemigos
                for (int i = 0; i < enemiesPerWare; i++){
                    // Generamos aleatoriamente el enemigo fuera de la pantalla
                    float randDistance = Random.Range(10, 25); // Distancia de aparicion
                    Vector2 randDirection = Random.insideUnitCircle; // Punto al azar sobre la circunferencia
                    Vector3 enemyPos = this.transform.position; // Posicion del Game Controller (0,0,0);
                    enemyPos.x += randDirection.x * randDistance;
                    enemyPos.y += randDirection.y * randDistance;
                    // Instaciamos el enemigo en pantalla
                    Instantiate (enemy, enemyPos, this.transform.rotation);
                    currentNuemberOfEnemies++;
                    yield return new WaitForSeconds (timeBetweenEnemies);
                }
                enemiesPerWare++;
                IncreaseWave();
            }
            
            // Si llego hasta aqui es que aun tengo enemigmos, le indico al bucle principal que espere otros 2 segundos mas
            yield return new WaitForSeconds (timeBetweenWaves);
        }
    }

    public void KillEnemy(){
        currentNuemberOfEnemies--;
    }

    public void IncreaseScore(int increaseScore){
        score += increaseScore;
        scoreText.text = "SCORE : " + score;
    }

    private void IncreaseWave(){
        wave++;
        waveText.text = "WAVES : " + wave;
    }
}
