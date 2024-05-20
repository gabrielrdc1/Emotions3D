using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.XR; // Biblioteca necessária para suporte a VR

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    private Collider myCollider;

    private void Start()
    {
        myCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        // Suporte para Touch (móvel)
        CheckTouchInput();

        // Suporte para teclado (Windows)
        CheckKeyboardInput();
    }

    private void CheckTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.collider == myCollider)
                {
                    ConversationManager.Instance.StartConversation(myConversation);
                }
            }
        }
    }

    private void CheckKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Assume que o jogador está perto o suficiente para iniciar a conversa
            if (Vector3.Distance(transform.position, Camera.main.transform.position) < 5.0f) // 5 metros de alcance
            {
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }
    }
}
