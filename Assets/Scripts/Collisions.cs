using Unity.Multiplayer.Center.Common.Analytics;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Collisions : MonoBehaviour {

    public Interactable currentInteractable;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            InteractWithCurrent();
        }
    }
     private void InteractWithCurrent()
    {
        if (currentInteractable != null)
        {
            currentInteractable.interact();
        }
        else
        {
            Debug.Log("No interactable in range!");
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        currentInteractable = null;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        currentInteractable = other.gameObject.GetComponent<Interactable>();
        if (currentInteractable == null)
        {
            Debug.Log("Oops, I just hit the wall.");
        }
    }
}
