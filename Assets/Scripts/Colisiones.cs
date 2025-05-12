
using System;
using UnityEngine;

public class Colisiones : MonoBehaviour
{
    public GameObject _lineaComienzo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = _lineaComienzo.transform.position;
        transform.rotation = _lineaComienzo.transform.rotation;
        
        GameManager.Instance.EstableceCheckpoint(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TagCheckpoint"))
        {
            Debug.Log("Nuevo Checkpoint" + other.name);
            GameManager.Instance.EstableceCheckpoint(other.transform);
        }

        if (other.CompareTag("TagPasto"))
        {
            GameManager.Instance.ReiniciarJugador(transform);
        }

        if (other.CompareTag("TagSalida"))
        {
            GameManager.Instance.LineaDeSalidaPasada();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



}