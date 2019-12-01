using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class WebRequests
{

    public static IEnumerator GetCoroutine(string url)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            {
                Debug.Log(unityWebRequest.error);
            }
            else
            {
                Debug.Log(unityWebRequest.downloadHandler.text);
            }
        }
    }

    public static IEnumerator GetTextureCoroutine(string url, SpriteRenderer spriteRenderer)
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
                spriteRenderer.sprite = sprite;
            }
        }
    }
}