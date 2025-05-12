using UnityEngine;

public class MovimientoAutoConFisica : MonoBehaviour
{
    public float _velocidadRotacion = 100f;
    public float _fuerzaMovimiento = 5f;
   
    private float _movimientoVertical;
    private float _rotacionHorizontal;
    
    private Rigidbody _rigidbody;
    
    private float _controlDeslizamientoLateral = 0.9f; // 0 = sin deslizamiento, 1 = sin corrección
    private float _factorFrenado = 2f; // Qué tan rápido frena al soltar el input
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); //obtiene una referencia al componente rigidbody presente en el game object donde corre este script
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = false;
        _rigidbody.angularDamping = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _movimientoVertical = Input.GetAxis("Vertical");
        _rotacionHorizontal = Input.GetAxis("Horizontal");
        
       //Debug.Log(_movimientoVertical + ":::" + _rotacionHorizontal);
    }
    
    void FixedUpdate()
    {
        float rotacion = _rotacionHorizontal * _velocidadRotacion * Time.fixedDeltaTime;
        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, rotacion, 0));

        // Corregir deslizamiento lateral
        Vector3 velocidadLocal = transform.InverseTransformDirection(_rigidbody.linearVelocity);
        velocidadLocal.x *= _controlDeslizamientoLateral;
        _rigidbody.linearVelocity = transform.TransformDirection(velocidadLocal);

        if (_movimientoVertical != 0f)
        {
            Vector3 direccion = transform.forward * _movimientoVertical;
            _rigidbody.AddForce(direccion * _fuerzaMovimiento * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        else
        {
            // Frenado progresivo
            Vector3 velocidad = _rigidbody.linearVelocity;
            Vector3 direccionFreno = -velocidad.normalized;

            // Magnitud del freno proporcional a la velocidad actual
            Vector3 fuerzaFreno = direccionFreno * _factorFrenado * Time.fixedDeltaTime;

            // Evita que se pase de frenar demasiado
            if (fuerzaFreno.magnitude > velocidad.magnitude)
            {
                _rigidbody.linearVelocity = Vector3.zero;
            }
            else
            {
                _rigidbody.AddForce(fuerzaFreno, ForceMode.VelocityChange);
            }
        }
    }


}
