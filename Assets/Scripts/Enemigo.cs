using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float vidas;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3().normalized * velocidad * Time.deltaTime); 
    }
    public void RecibirDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido; // Me restan X de vida

        anim.SetTrigger("Parpadeo"); // Cuando me dañan, no cuando muero por eso no va dentro del if.
        if (vidas <= 0)
        {
            Destroy(gameObject);
        }


    }
}
