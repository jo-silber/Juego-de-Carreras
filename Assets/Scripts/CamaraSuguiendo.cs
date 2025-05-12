using UnityEngine;

public class CamaraSuguiendo : MonoBehaviour
{ 
    public Vector3 cameraOffset;
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void LateUpdate()
    {
        moveCamera();
    }

    void moveCamera()
    {
        // Set camera position relative to the target's Z translation
        transform.position = target.position + target.TransformDirection(cameraOffset);

        // Set camera rotation to match the target's X-axis rotation
        transform.rotation = Quaternion.Euler(target.eulerAngles.x, target.eulerAngles.y, 0f);

    }
}
