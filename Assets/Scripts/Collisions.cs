using Unity.Multiplayer.Center.Common.Analytics;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Collisions : MonoBehaviour {
    private bool isTouchingArthur;
    private bool isTouchingMerchant;
    private Animator animator;
    void Start() {

    }
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            interactWithArthur();
            interactWithMerchant();
        }
    }
    private void interactWithArthur() {
        if (isTouchingArthur) {
                Debug.Log("Hi, Arthur");
            }
    }
    private void interactWithMerchant() {
        if (isTouchingMerchant) {
                Debug.Log("Hi, you guy got new goods?");
            }
    }
    private void OnCollisionExit2D(Collision2D other) {
        isTouchingArthur = false;
        isTouchingMerchant = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Arthur") {
            isTouchingArthur = true;
        }
        else if (other.gameObject.tag == "Merchant") {
            isTouchingMerchant = true;
        }
        else {
            Debug.Log("Oops, I just hit the wall.");
        }
    }
}
