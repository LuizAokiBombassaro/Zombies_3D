using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    public GameObject Player;
    public float speed = 7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 direcao = Player.transform.position - transform.position;

        float distancia = Vector3.Distance(transform.position, Player.transform.position);

        if (distancia > 2.3) 
        {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * speed * Time.deltaTime);
        }
        Quaternion NovaRotacao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(NovaRotacao);
    }
}
