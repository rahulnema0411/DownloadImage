using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DownloadImage : MonoBehaviour
{

    public static DownloadImage instance;

    public Sprite defaultSprite;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    public IEnumerator FetchAndSetImage(string MediaUrl, Image image) {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(MediaUrl);
        www.timeout = 10;
        yield return www.SendWebRequest();
        if (www.error != null) {
            Debug.Log(www.error);
            image.overrideSprite = defaultSprite;
        } else {
            Texture2D tex = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            image.overrideSprite = sprite;
        }
    }
}
