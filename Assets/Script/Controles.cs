using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    public float PlayerSpeed;
    Vector3 direcao;
    public LayerMask MascaraChao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float EixoX = Input.GetAxis("Horizontal");
        float EixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(EixoX,0, EixoZ);

        //transform.Translate(direcao * PlayerSpeed * Time.deltaTime);

        if (direcao != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Running", true);
        }
        else 
        {
            GetComponent<Animator>().SetBool("Running", false);
        }

    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition
    (GetComponent<Rigidbody>().position +
    (direcao * PlayerSpeed * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
    }
}
