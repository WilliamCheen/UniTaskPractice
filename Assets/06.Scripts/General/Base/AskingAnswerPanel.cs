using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AskingAnswerPanel : MonoBehaviour
{
    [SerializeField]
    ScrollRect scrollRect;

    [SerializeField]
    private RectTransform contentTransfrom;

    [SerializeField]
    private GameObject askingPrefab;

    [SerializeField]
    private GameObject answerPrefab;

    private Coroutine delayScrollTask;

    private List<BaseIdentityUIItem> UIItems = new List<BaseIdentityUIItem>();

    /// <summary>
    /// 添加一个元素
    /// </summary>
    /// <param name="content">内容</param>
    /// <param name="isAsking">是否是问题</param>
    public void Add(string content, bool isAsking)
    {
        if (content == null || content == "")
        {
            return;
        }

        if (contentTransfrom == null || askingPrefab == null || answerPrefab == null)
        {
            return;
        }

        GameObject prefab = isAsking ? askingPrefab : answerPrefab;
        GameObject obj = Instantiate(prefab, contentTransfrom);
        if (obj != null)
        {
            obj.SetActive(true);
        }

        BaseIdentityUIItem script = obj.GetComponent<BaseIdentityUIItem>();
        if (script != null && script.Title != null)
        {
            script.Title.text = content;
            UIItems.Add(script);
        }

        if (delayScrollTask != null)
        {
            StopCoroutine(delayScrollTask);
        }

        delayScrollTask = StartCoroutine(DelayScrollBottom());
    }

    /// <summary>
    /// 获取最后一个 Item 的 Postion
    /// </summary>
    /// <returns></returns>
    public Vector3 LastItemPostion()
    {
        int length = UIItems.Count;
        if (length > 0)
        {
            return UIItems[length - 1].gameObject.transform.position;
        }
        return Vector3.zero;
    }

    private void OnDisable()
    {
        if (delayScrollTask != null)
        {
            StopCoroutine(delayScrollTask);
        }
    }

    private IEnumerator DelayScrollBottom()
    {
        yield return null;

        if (scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition = 0;
        }

        delayScrollTask = null;
    }
}
