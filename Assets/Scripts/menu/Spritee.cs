using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spritee : MonoBehaviour
{

    private Image background;
    // Use this for initialization
    void Start()
    {

        background = GetComponent<Image>();
    }

    // Update is called once per frame
    public void changeSprite(Sprite newSprite)
    {

        background.sprite = newSprite;
    }
}
