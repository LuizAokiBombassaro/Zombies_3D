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
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * PlayerSpeed * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        if (ground.Raycast(raio, out rayLength))
        {
            Vector3 pointTolook = raio.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
        }
    }
}
