using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestService : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GetCoroutine("https://jsonplaceholder.typicode.com/todos/1"));
    }

    private IEnumerator GetCoroutine(string url)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(url))
        {
            yield return unityWebRequest.SendWebRequest();

            Debug.Log(unityWebRequest.downloadHandler.text);
        }
    }
}
