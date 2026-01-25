using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      float input = Input.GetAxis("Vertical");
      transform.Translate(Vector3.up * input * speed * Time.deltaTime);

        
    }
}
