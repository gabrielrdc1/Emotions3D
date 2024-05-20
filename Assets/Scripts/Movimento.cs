using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private Vector3 entradasJogador;
    private CharacterController characterController;
    private float velocidadeJogador = 4f;
    private Transform myCamera;

    private bool estaNoChao;
    [SerializeField] private Transform verificadorChao;
    [SerializeField] private LayerMask cenarioMask;

    [SerializeField] private float alturaDoSalto = 1f;
    private float gravidade = -9.81f;
    private float velocidadeVertical;

    [SerializeField] private float sensibilidadeMouse = 100f; 
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        myCamera = Camera.main.transform;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse * Time.deltaTime;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, myCamera.eulerAngles.y + mouseX, transform.eulerAngles.z);

        entradasJogador = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        entradasJogador = transform.TransformDirection(entradasJogador);

        characterController.Move(entradasJogador * Time.deltaTime * velocidadeJogador);
        estaNoChao = Physics.CheckSphere(verificadorChao.position, 0.3f, cenarioMask);

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            velocidadeVertical = Mathf.Sqrt(alturaDoSalto * -2f * gravidade);
        }

        if (estaNoChao && velocidadeVertical < 0)
        {
            velocidadeVertical = -1f;
        }

        velocidadeVertical += gravidade * Time.deltaTime;
        characterController.Move(new Vector3(0, velocidadeVertical, 0) * Time.deltaTime);
    }
}
