using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NpcConversation : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation; 

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Personagem"))
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(myConversation); 
            }
        }
    }  
}
