using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static CardData;

public class RandomManager : MonoBehaviour
{
    [Header("Animationcard")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private UI_RandomManager ui_RandomManager;
    [SerializeField] private AnimationManager animationManager;

    [Header("Show card")]
    [SerializeField] private Transform showCardLayout;
    [SerializeField] private GameObject CardRandom;
    [SerializeField] private List<CardData> cardData;

    [Header("Button")]
    [SerializeField] private Button card_Button;

    private List<GameObject> spawnedCards = new();
    private int maxSpawn = 5;
    private CardDisplay cardDisplay;

    private void Start()
    {
        card_Button.onClick.AddListener(() =>
        {
            animationManager.PlayTear_Animator(() =>
            {
                StartCoroutine(SpawnCards());
            });
        });
    }

    private CardData GetRandomCard()
    {
        float roll = Random.value * 100f;

        var groups = new List<(float threshold, List<CardData> pool)>
    {
        (2f, cardData.Where(c => c.rarity == RarityType.Legendary).ToList()),
        (10f, cardData.Where(c => c.rarity == RarityType.Epic).ToList()),
        (30f, cardData.Where(c => c.rarity == RarityType.Rare).ToList()),
        (100f, cardData.Where(c => c.rarity == RarityType.Common).ToList())
    };

        foreach (var (threshold, pool) in groups)
        {
            if (roll < threshold && pool.Count > 0)
                return pool[Random.Range(0, pool.Count)];
        }

        // fallback
        return cardData[Random.Range(0, cardData.Count)];
    }

    IEnumerator SpawnCards()
    {
        float spacingY = 500f;
        for (int i = 0; i < maxSpawn; i++)
        {

            Vector3 offset = new Vector3(0f, i * spacingY, 0f); // ระยะห่าง spawn ไพ่
            Vector3 spawnPos = spawnPoint.position + offset;
            GameObject card = Instantiate(cardPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);


            cardDisplay = card.GetComponent<CardDisplay>();

            if (cardDisplay != null)
            {
                cardDisplay.Setup(GetRandomCard());
            }

            StartCoroutine(FlyAndStoreCard(card));
            yield return new WaitForSeconds(1f);

        }

        yield return StartCoroutine(animationManager.ResizeDone());
        CardRandom.SetActive(false);

        spawnedCards.Clear();
        StartCoroutine(ArrangeCards());
    }

    IEnumerator FlyAndStoreCard(GameObject card)
    {
        Vector3 startPos = card.transform.position;
        Vector3 targetPos = startPos + new Vector3(0f, 700f, 0f);
        float duration = 1.2f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            card.transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(5f);
        showCardLayout.gameObject.SetActive(true);
        card.transform.SetParent(showCardLayout, false);
        card.transform.localScale = Vector3.one;

        card.transform.localRotation = Quaternion.Euler(0, 0, 0); // คว่ำการ์ด

        spawnedCards.Add(card);
    }

    IEnumerator ArrangeCards()
    {
        yield return new WaitForSeconds(5f);
        ui_RandomManager.GetBack_Button.SetActive(true);

    }

    public List<CardData> GetCardData => cardData;
}
