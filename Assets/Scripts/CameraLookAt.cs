using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public GameObject _target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_target.transform.position);
    }
}
