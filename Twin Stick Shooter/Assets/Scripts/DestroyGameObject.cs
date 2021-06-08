using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public float timeToLife = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy (this.gameObject, timeToLife);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
