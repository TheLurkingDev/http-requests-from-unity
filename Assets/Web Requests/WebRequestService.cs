using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestService : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

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
                Sprite sprite = Sprite.Create(downloadHandlerTexture.texture, 
                    new Rect(0, 0, downloadHandlerTexture.texture.width, downloadHandlerTexture.texture.height),
                    new Vector2(0.5f, 0.5f));
                _spriteRenderer.sprite = sprite;                
            }
        }        
    }
}
