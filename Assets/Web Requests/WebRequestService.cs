using UnityEngine;

public class WebRequestService : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        StartCoroutine(WebRequests.GetCoroutine("https://jsonplaceholder.typicode.com/todos/1"));
        StartCoroutine(WebRequests.GetTextureCoroutine("https://via.placeholder.com/600/92c952", _spriteRenderer));
    }
}
