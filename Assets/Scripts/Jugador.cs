using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float velocidad;

    //Vidas
    [SerializeField] int vidas;
    [SerializeField] TMP_Text textoVidas;

    //Puntos
    [SerializeField] int puntos;
    [SerializeField] TMP_Text textoPuntos;

    //Objetos
    [SerializeField] private GameObject prefabExplosion;
    [SerializeField] private GameObject disparo;
    [SerializeField] private GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A y D para horizontal
        float v = Input.GetAxisRaw("Vertical"); // W y S para vertical
        transform.Translate(new Vector2(v,h).normalized * velocidad * Time.deltaTime);

        Muerte();
        Disparar();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BalaEnemiga") // decetan a los objetos a partir del tag
        {
            Destroy(collision.gameObject);
            vidas--;
            //ActivarParpadeo();
        }
    }
    private void Disparar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Instantiate(disparo,spawnPoint.transform.position,Quaternion.identity);
        }
    }
    private void Muerte()
    {
        if (vidas <= 0)
        {
            Destroy(gameObject);
            //GameObject clon = Instantiate(prefabExplosion);
            //clon.transform.position = transform.position;
        }
    }
}
