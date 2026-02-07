using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class CardsController : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    [SerializeField] Transform gridTransform;
    [SerializeField] Sprite[] sprites;
    [SerializeField] TMP_Text scoreText;

    int score = 0;

    private List <Sprite> spritePairs;
    
    Card firstSelected;
    Card secondSelected;

    int matchCounts;
    private void Start()
    {
        PrepareSprite();
        CreatCard();
    }

    private void PrepareSprite()
    {
        spritePairs = new List<Sprite>();
        for (int i = 0; i < sprites.Length; i++)
        {
            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
        }

        ShuffleSprites(spritePairs);
    }

    void CreatCard()
    {
        for (int i = 0; i < spritePairs.Count; i++)
        {
            Card card = Instantiate(cardPrefab, gridTransform);
            card.SetIconSprite(spritePairs[i]);
            card.controller = this;
        }
    }

    public void SetSelected(Card card)
    {
        if (card.isSelected == false)
        {
            card.Show();

            if (firstSelected == null)
            {
                firstSelected = card;
                return;
            }
            if (secondSelected == null)
            {
                secondSelected = card;  
                StartCoroutine(CheckMatching(firstSelected, secondSelected));
                firstSelected = null;
                secondSelected = null;
            }
        }
    }

    void NextRound()
    {
        matchCounts = 0;
        firstSelected = null;
        secondSelected = null;

        foreach (Transform child in gridTransform)
        {
            Destroy(child.gameObject);
        }

        PrepareSprite();
        CreatCard();
    }

    IEnumerator NextRoundDelay()
    {
        yield return new WaitForSeconds(1f);
        NextRound();
    }

    IEnumerator CheckMatching(Card a, Card b)
    {
        yield return new WaitForSeconds(0.3f);
        if (a.iconSprite == b.iconSprite)
        {
            score++;
            UpdateScoreUI();
            matchCounts++;
            if (matchCounts >= spritePairs.Count / 2)
            {
                PrimeTween.Sequence.Create()
                    .Chain(PrimeTween.Tween.Scale(gridTransform, Vector3.one * 1.2f, 0.2f, ease: PrimeTween.Ease.OutBack))
                    .Chain(PrimeTween.Tween.Scale(gridTransform, Vector3.one, 0.1f));
                StartCoroutine(NextRoundDelay());
            }
        }
        else
        {
            a.Hide();
            b.Hide();
        }
    }
        void ShuffleSprites(List<Sprite> spritelist)
    {
        for (int i = spritelist.Count - 1;i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            Sprite temp = spritelist[i];
            spritelist[i] = spritelist[randomIndex];
            spritelist[randomIndex] = temp;
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }


}
