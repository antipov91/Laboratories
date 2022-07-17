using UnityEngine;
using UnityEngine.UI;

public class PageGroupPanel : MonoBehaviour
{
    [SerializeField] private Sprite[] images;

    [SerializeField] private Button nextBtn;
    [SerializeField] private Button backBtn;
    [SerializeField] private Button returnBtn;

    [SerializeField] private Image preview;

    private int currentIndex;

    private void Awake()
    {
        preview.sprite = images[0];
    }

    private void OnEnable()
    {
        nextBtn.onClick.AddListener(NextClick);
        backBtn.onClick.AddListener(BackClick);
        returnBtn.onClick.AddListener(ReturnClick);
    }

    private void NextClick()
    {
        if (currentIndex + 1 < images.Length)
        {
            currentIndex++;
            preview.sprite = images[currentIndex];
            UpdateBtns();
        }
    }

    private void BackClick()
    {
        if (currentIndex - 1 >= 0)
        {
            currentIndex--;
            preview.sprite = images[currentIndex];
            UpdateBtns();
        }
    }

    private void UpdateBtns()
    {
        nextBtn.interactable = currentIndex != images.Length - 1;
        backBtn.interactable = currentIndex != 0;
    }

    private void ReturnClick()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        nextBtn.onClick.RemoveListener(NextClick);
        backBtn.onClick.RemoveListener(BackClick);
        returnBtn.onClick.RemoveListener(ReturnClick);
    }
}