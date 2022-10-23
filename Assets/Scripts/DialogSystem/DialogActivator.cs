using UnityEngine;

public class DialogActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogObject dialogObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.TryGetComponent(out Player player))
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.TryGetComponent(out Player player))
        {
            if (player.Interactable is DialogActivator dialogActivator && dialogActivator == this)
            {
                player.Interactable = null;
            }
        }
    }

    public void Interact(Player player)
    {
        player.DialogUI.ShowDialog(dialogObject);
        this.gameObject.SetActive(false);
    }
}