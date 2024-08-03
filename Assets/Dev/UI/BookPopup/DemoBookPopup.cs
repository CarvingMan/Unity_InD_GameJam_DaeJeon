using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoBookPopup : MonoBehaviour
{
    [SerializeField] private BookPlayableController controller;

    private void OnGUI()
    {
        if (GUILayout.Button("Open"))
        {
            StartCoroutine(OpenBook());
        }
        
        if (GUILayout.Button("Close"))
        {
            StartCoroutine(CloseBook());
        }
        if (GUILayout.Button("NextPage"))
        {
            StartCoroutine(NextPage());
        }
    }

    private IEnumerator OpenBook()
    {
        controller.gameObject.SetActive(true);
        yield return controller.OpenBookCoroutine();
        Debug.Log("Open Complete!");
    }

    private IEnumerator CloseBook()
    {
        yield return controller.CloseBookCoroutine();
        controller.gameObject.SetActive(false);
        Debug.Log("Close Complete");
    }

    private IEnumerator NextPage()
    {
        if (controller.gameObject.activeInHierarchy)
        {
            yield return controller.NextPageCoroutine();
        }
        else
        {
            Debug.Log("Need to open book first!");
        }
    }
}
