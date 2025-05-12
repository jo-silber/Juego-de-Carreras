using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public Vector3 _posiCheckpoint;
    public Vector3 _rotCheckpoint;
    
    public List<string> listaCheckpoints;
    private HashSet<string> checkpointsVisitados = new HashSet<string>();

    public int _vueltasCompletadas = 0;
    private float _tiempoActual = 0f;
    
    private bool _corriendo = false;
    private bool _primeraPasada = true;
    
    
    //para poder acceder mas facil al GameManager
    void Awake()
    {
        Instance = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.IniciarVuelta();
    }
    // Update is called once per frame
    void Update()
    {
        if (_corriendo)
        {
            _tiempoActual += Time.deltaTime;
        }
    }

    public void EstableceCheckpoint(Transform t)
    {
       _posiCheckpoint = t.position + Vector3.up * 0.2f;
        _rotCheckpoint = t.eulerAngles;
        
        //markar el checkpoint ya pasado
        string _nombre = t.name;
        if (listaCheckpoints.Contains(_nombre))
        {
            checkpointsVisitados.Add(_nombre);
        }
    }

    public void ReiniciarJugador(Transform player)
    {
        
        player.position = _posiCheckpoint;
        player.eulerAngles = _rotCheckpoint;
    }
    

    public void IniciarVuelta()
    {
        _tiempoActual = 0f;
        _vueltasCompletadas = 0;
        checkpointsVisitados.Clear();
        _corriendo = true;
    }

    public void LineaDeSalidaPasada()
    {
        if (_primeraPasada)
        {
            //para poder ignorar la primera pasada por la salida asi empieza en 0
            _primeraPasada = false;
            return;
        }
        
        if (checkpointsVisitados.Count == listaCheckpoints.Count)
        {
            _vueltasCompletadas++;
            Debug.Log("Vuelta completada! total de vueltas: " + _vueltasCompletadas);
            checkpointsVisitados.Clear();
        }
    }

    public float GetTiempoActual()
    {
        return _tiempoActual;
    }

   
   
}
