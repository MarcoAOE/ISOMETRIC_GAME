using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private InputActionReference interactAction;
    [SerializeField] private GameObject intaractText;

    private bool isPlayerInRange = false;

    private void OnEnable()
    {
        if(interactAction  != null)
        {
            interactAction.action.Enable();
            interactAction.action.performed += PerformInteraction;
        }
    }

    private void OnDisable()
    {
        if(interactAction != null)
        {
            interactAction.action.performed -= PerformInteraction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            intaractText.SetActive(true);
            Debug.Log("Presiona E para interactuar");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            intaractText.SetActive(false);
            Debug.Log("Ya no estas en rango");
        }
    }

    private void PerformInteraction(InputAction.CallbackContext context)
    {
        if(isPlayerInRange)
        {
            Debug.Log("Interaccion con objeto");
            intaractText.SetActive(false);
            gameObject.SetActive(false);
        }
    }

}
