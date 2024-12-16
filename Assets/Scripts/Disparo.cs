using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private float danhoDisparo;

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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemigo")) 
        {
            Destroy(gameObject); //Me destruyo (soy el disparo). Es igual a Destroy(this.gameObject);
            //Destroy(other.gameObject); Lo quito.

            // Acceddmos al enemigo, accedemos al codigo del otro script
            other.gameObject.GetComponent<Enemigo>().RecibirDanho(danhoDisparo);

        }
    }
   
}
