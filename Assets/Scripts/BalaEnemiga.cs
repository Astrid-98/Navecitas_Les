using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemiga : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float temporizador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * velocidad * Time.deltaTime;
        temporizador -= Time.deltaTime;
        if (temporizador <= 0)
        {
            Destroy(gameObject);
        }
    }
}
