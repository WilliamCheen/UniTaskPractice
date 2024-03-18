using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 通用类型 UI Item
/// </summary>
public class BaseIdentityUIItem : MonoBehaviour
{
    public string Identifier;
    /// <summary>
    /// 时间按钮，可为空不关联
    /// </summary>
    public Button ActionButton;
    /// <summary>
    /// 标题，非空
    /// </summary>
    public Text Title;
    /// <summary>
    /// 描述信息，可为空不关联
    /// </summary>
    public Text Description;
    /// <summary>
    /// 删除按钮，可为空不关联
    /// </summary>
    public Button DeleteButton;
    /// <summary>
    /// 背景，可为空不关联
    /// </summary>
    public Image Background;
}
