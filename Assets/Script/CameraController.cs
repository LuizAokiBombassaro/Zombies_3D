using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject Player;
    Vector3 DistancePlayerCamera;

    // Start is called before the first frame update
    void Start()
    {
        DistancePlayerCamera = this.transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Player.transform.position + DistancePlayerCamera;
    }
}
