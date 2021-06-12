using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables //

    // Movimiento
    public float playerSpeed = 4f;

    private float currentSpeed = 0f;

    private Vector3 lastMovement = new Vector3();

    // Disparo
    public Transform laser;
    public float laserDistance = 0.2f;

    public float timeBetweenFires = 0.3f;

    private float timeUntilNextFire = 0f;

    public List<KeyCode> shootButton;

    public AudioClip shootSound;

    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenuBehavior.isPaused){
            Rotate();
            Move();
            Fire();
        }
    }
    
    /// <summary>
    /// Rota con el puntero del raton
    /// </summary>
    /// <returns></returns>
    void Rotate()
    {
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);
        Vector3 spaceShipPos = this.transform.position;
        float difX = spaceShipPos.x - worldPos.x;
        float difY = spaceShipPos.y - worldPos.y;
        float angle = Mathf.Atan2(difY, difX) * Mathf.Rad2Deg;
        Quaternion rotacion = Quaternion.Euler (new Vector3(0, 0, angle + 90));
        this.transform.rotation = rotacion;
    }
    
    /// <summary>
    /// Se desplaza con los controles habituales
    /// </summary>
    /// <returns></returns>
    void Move()
    {
        Vector3 movement = new Vector3();
        movement.x += Input.GetAxis ("Horizontal");
        movement.y += Input.GetAxis ("Vertical");
        movement.Normalize();

        if (movement.magnitude > 0) 
        {
            currentSpeed = playerSpeed;
            this.transform.Translate(movement * Time.deltaTime * currentSpeed, Space.World);
            lastMovement = movement;
        } 
        else 
        {
            // seguimos con la inercia del movimiento
            this.transform.Translate(movement * Time.deltaTime * currentSpeed, Space.World);
            currentSpeed *=  0.9f;
        }
    }

    void Fire(){
        foreach (KeyCode key in shootButton){
            if (Input.GetKey(key) && timeUntilNextFire < 0){
                timeUntilNextFire = timeBetweenFires;
                ShootLaser();
                break;
            }
        }
        timeUntilNextFire -= Time.deltaTime;
    }

    void ShootLaser(){
        audioSource.PlayOneShot(shootSound);
        Vector3 laserPos = this.transform.position;
        float rotationAngle = this.transform.localEulerAngles.z -90;
        laserPos.x += Mathf.Cos (rotationAngle * Mathf.Deg2Rad) * laserDistance;
        laserPos.y += Mathf.Sin (rotationAngle * Mathf.Deg2Rad) * laserDistance;
        Instantiate (laser, laserPos, this.transform.rotation);
    }
}