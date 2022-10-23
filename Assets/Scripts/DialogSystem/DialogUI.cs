using System.Collections;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text textLabel;

    public bool IsOpen { get; private set; }

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogBox();
    }

    public void ShowDialog(DialogObject dialogObject)
    {
        IsOpen = true;
        dialogBox.SetActive(true);
        StartCoroutine(StepThroughDialog(dialogObject));
    }

    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {
        for (int i = 0; i < dialogObject.Dialog.Length; i++)
        {
            string dialog = dialogObject.Dialog[i];

            yield return RunTypingEffect(dialog);

            textLabel.text = dialog;

            if (i == dialogObject.Dialog.Length - 1 && dialogObject.HasResponses)
                break;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogObject.Responses);
        }
        else
        {
            CloseDialogBox();
        }
    }

    private IEnumerator RunTypingEffect(string s)
    {
        typewriterEffect.Run(s, textLabel);

        while (typewriterEffect.isRunning)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                typewriterEffect.Stop();
            }
        }
    }

    private void CloseDialogBox()
    {
        IsOpen = false;
        dialogBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
