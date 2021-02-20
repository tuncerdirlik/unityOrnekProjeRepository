using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakaraController : MonoBehaviour
{

    private LineRenderer ip;
    public Transform kanca;

    private void Start()
    {
        ip = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        ip.SetPosition(0, transform.position);
        ip.SetPosition(1, kanca.position);
    }
}
