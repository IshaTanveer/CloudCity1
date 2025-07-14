using UnityEngine;

public class ArthurController : MonoBehaviour, Interactable
{
    private DialogManager dialogManager;
    private void Awake()
    {
        dialogManager = FindAnyObjectByType<DialogManager>();
    }
    public void interact()
    {
         dialogManager.showDialog();
    }

}
