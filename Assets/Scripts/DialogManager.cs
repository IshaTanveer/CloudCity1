using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] float lettersPerSecond;
    [SerializeField] int wordsPerMin;
    private List<String> dialogs = new List<String>()
    {
        "Hi, i am Arthur. Welcome to the game.",
        "You have 4 challenges.",
        "Make sure to complete them all before coming back to me."
    };
    public void Awake()
    {
        dialogBox.SetActive(false);
    }
    public void showDialog()
    {
        dialogBox.SetActive(true);
        StartCoroutine(typeSentence(dialogs));
    }
    public IEnumerator typeSentence(List<String> dialogs)
    {
        //dialogText.text = "";
        foreach (string dialog in dialogs)
        {
            StartCoroutine(TypeDialog(dialog));
            yield return new WaitForSeconds(dialog.Length  / wordsPerMin);
        }
        dialogBox.SetActive(false);
    }

    private void SetFalse()
    {
        dialogBox.SetActive(false);
    }
    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1F / lettersPerSecond);
        }
        yield return new WaitForSeconds(1f);
        //dialogBox.SetActive(false);
    }
}
