using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float velocidad;

    [SerializeField] int vidas;
    [SerializeField] TMP_Text textoVidas;

    [SerializeField] int puntos;
    [SerializeField] TMP_Text textoPuntos;

    private GameObject prefabExplosion;
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
        Vector2 movimiento = new Vector2(h, v).normalized;

        rb.velocity = movimiento * velocidad;

        Muerte();
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
    private void Muerte()
    {
        if (vidas <= 0)
        {
            Destroy(gameObject);
            GameObject clon = Instantiate(prefabExplosion);
            clon.transform.position = transform.position;
        }
    }
}
