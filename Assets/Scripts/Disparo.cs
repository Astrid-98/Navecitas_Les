using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnearNaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnearNaves()
    {
        // Bucle infinito
        while (true) 
        {
            Instantiate(enemigoPrefab, new Vector3(transform.position.x, Random.Range(-4.4f, 4.4f) ,0), Quaternion.identity);

            // Espera de X segundos
            yield return new WaitForSeconds(2);
        }
    }
}
