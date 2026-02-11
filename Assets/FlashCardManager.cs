using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashCardManager : MonoBehaviour
{
    [System.Serializable]
    public class Flashcard
    {
        public string term;
        public string definition;
    }

    public List<Flashcard> database;
    public TextMeshProUGUI cardText;
    int currentIndex = 0;

    bool showingTerm = true;
    void Start()
    {
        ShuffleandRestart();
    }
    public void ShuffleandRestart()
    {

        for( int i = database.Count - 1; i > 0; i-- )
        {
            int j = Random.Range(0, i + 1);
            Flashcard tmp = database[i];
            database[i] = database[j];
            database[j] = tmp;
        }
        currentIndex = 0;  
        showingTerm = true;
        DisplayCard();
    }
    void DisplayCard()
    {
        Flashcard card = database[currentIndex];
        cardText.text = showingTerm
            ? $"<size=150%><b><color=#00FFFF>{card.term}</color></b></size>"
            : $"<i>\"{card.definition}\"</i>";

        cardText.text += $"\n\n<size=70%><color=#888888>[{currentIndex + 1}/{database.Count}]</color></size>";
    }
    public void FlipCard()
    {
        showingTerm = !showingTerm;
        DisplayCard();
    }
    public void NextCard()
    {
        currentIndex++;
        if (currentIndex >= database.Count)
        {
            currentIndex = 0;
            ShuffleandRestart();
        } else
        {
            showingTerm = true;
            DisplayCard();
        }
    }
    public void PreviousCard()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = 0;

        showingTerm = true;
        DisplayCard();
    }
}
