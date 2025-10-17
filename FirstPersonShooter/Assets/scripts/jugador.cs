using UnityEngine;

public class jugador : MonoBehaviour
{
    CharacterController characterController;
    Vector3 velocidad;

    GameObject objetoRotacionCamara;
    GameObject Camara;

    Vector3 posicionAnteriorMouse;
    Vector3 rotacionCamara;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        velocidad = Vector3.zero;

        objetoRotacionCamara = new GameObject();
        Camara = GameObject.FindGameObjectWithTag("MainCamera");

        posicionAnteriorMouse = Input.mousePosition;

        rotacionCamara = Camara.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        velocidad.x = Input.GetAxis("Horizontal") * 3;
        velocidad.z = Input.GetAxis("Vertical") * 3;

        objetoRotacionCamara.transform.rotation = Camara.transform.rotation;
        objetoRotacionCamara.transform.rotation = Quaternion.Euler(0, objetoRotacionCamara.transform.rotation.eulerAngles.y, 0);

        characterController.Move(objetoRotacionCamara.transform.TransformDirection(velocidad) * Time.deltaTime);

        Vector3 movimientoMouse = Input.mousePosition - posicionAnteriorMouse;

        Debug.Log(movimientoMouse);

        rotacionCamara.y += movimientoMouse.x *0.5f;
        rotacionCamara.x -= movimientoMouse.y * 0.5f;


        posicionAnteriorMouse = Input.mousePosition;

        Camara.transform.rotation = Quaternion.Euler(rotacionCamara);

    }
}
