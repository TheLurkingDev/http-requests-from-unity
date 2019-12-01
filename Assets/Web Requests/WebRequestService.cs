using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestService : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GetCoroutine("https://jsonplaceholder.typicode.com/todos/1"));
        StartCoroutine(GetTextureCoroutine("https://via.placeholder.com/600/92c952"));
    }

    private IEnumerator GetCoroutine(string url)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if(unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            {
                Debug.Log(unityWebRequest.error);                
            }
            else
            {
                Debug.Log(unityWebRequest.downloadHandler.text);
            }
        }
    }

    private IEnumerator GetTextureCoroutine(string url)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            {
                Debug.Log(unityWebRequest.error);
            }
            else
            {
                DownloadHandlerTexture downloadHandlerTexture = unityWebRequest.downloadHandler as DownloadHandlerTexture;
                var texture = downloadHandlerTexture.texture;
            }
        }        
    }
}
