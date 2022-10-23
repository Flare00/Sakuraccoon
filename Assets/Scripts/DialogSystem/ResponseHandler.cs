using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private DialogUI dialogUI;

    List<GameObject> tmpResponsesButtons = new List<GameObject>();

    private void Start()
    {
        dialogUI = GetComponent<DialogUI>();
    }

    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0;

        foreach (Response response in responses)
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnpickedResponse(response));

            tmpResponsesButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }

    private void OnpickedResponse(Response response)
    {
        responseBox.gameObject.SetActive(false);

        foreach(GameObject button in tmpResponsesButtons)
        {
            Destroy(button);
        }
        tmpResponsesButtons.Clear();

        dialogUI.ShowDialog(response.DialogObject);
    }
}