using System.Collections;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogObject testDialogue;

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogBox();
        ShowDialog(testDialogue);
    }

    public void ShowDialog(DialogObject dialogObject)
    {
        dialogBox.SetActive(true);
        StartCoroutine(StepThroughDialog(dialogObject));
    }

    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {
        for (int i = 0; i < dialogObject.Dialog.Length; i++)
        {
            string dialog = dialogObject.Dialog[i];
            yield return typewriterEffect.Run(dialog, textLabel);

            if (i == dialogObject.Dialog.Length - 1 && dialogObject.HasResponses)
                break;

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

    private void CloseDialogBox()
    {
        dialogBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
