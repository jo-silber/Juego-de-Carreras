using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MostrarTexto : MonoBehaviour
{

    public TextMeshProUGUI _textoTiempo;
    public TextMeshProUGUI _textoVueltas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si no lo pongo en un if me da error en unity
       if (_textoTiempo != null && _textoVueltas != null) {
        float tiempo = GameManager.Instance.GetTiempoActual();
        System.TimeSpan t = System.TimeSpan.FromSeconds(tiempo);
        _textoTiempo.text = "Tiempo: " + t.ToString(@"mm\:ss\:fff");
        
        int vueltas = GameManager.Instance._vueltasCompletadas;
        _textoVueltas.text = "Vueltas: " + vueltas;
    }
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
