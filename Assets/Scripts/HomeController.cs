using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks.Linq;
using DG.Tweening;

public class HomeController : MonoBehaviour
{
    [SerializeField] Text Title;
    [SerializeField] Button ActionBtn;
    private AskingAnswerPanel panel;
    // Start is called before the first frame update
    void Start()
    {
        ActionBtn.onClick.AddListener(async () =>
        {
            if (panel != null)
            {
                return;
            }

            var asset = await Resources.LoadAsync<GameObject>("AskingAnswerPanel");
            Debug.Log($"Asset is: {asset}");

            GameObject obj = (GameObject)Instantiate(asset, gameObject.transform);
            RectTransform trans = obj.GetComponent<RectTransform>();
            Vector2 position = trans.anchoredPosition;
            position.x = -534;
            trans.anchoredPosition = position;
            panel = obj.GetComponent<AskingAnswerPanel>();
            if (panel != null)
            {
                panel.Add("Hello world!", true);
            }

            // var txt = (await UnityWebRequest.Get("http://baidu.com").SendWebRequest()).downloadHandler.text;
            // Title.text = txt;

            Debug.Log("Before Delay");
            await UniTask.DelayFrame(1000);
            Debug.Log("After Delay");


            // await foreach(var _ in UniTaskAsyncEnumerable.EveryUpdate())
            // {
            //     Debug.Log("update() " + Time.frameCount);
            // }

            obj.transform.DOMoveX(-84, 0.3f);
        });
    }
}
