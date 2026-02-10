using System.Collections.Generic;
using UnityEngine;

public class FlashCardManager : MonoBehaviour
{
    [System.Serializable]
    public class Flashcard
    {
        public string term;
        public string definition;
    }

    public List<Flashcard> database;
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
    }
    void DisplayCard()
    {
        Flashcard card = database[currentIndex];
        if (showingTerm)
        {
            Debug.Log("Term: " + card.term);
        } else
        {
            Debug.Log("Definition: " + card.definition);
        }
    }
    public void FlipCard()
    {
        showingTerm = !showingTerm;
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
            DisplayCard();
        }
    }
}
