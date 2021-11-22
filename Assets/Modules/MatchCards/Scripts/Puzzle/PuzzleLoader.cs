using System.Collections.Generic;
using UnityEngine;

public class PuzzleLoader: MonoBehaviour
{
    // Build parameters
    [Range(3, 18)] public int matches; 
    Puzzle puzzle;
    PuzzleController controller;
    protected Notifier notifier = new Notifier();
    public readonly static string ON_LOADED = "OnLoaded";

    public void Restart()
    {
        puzzle = Create();
        notifier.Notify(ON_LOADED, puzzle);
        controller.Puzzle = puzzle;
    }
    void Awake()
    {
        controller = GetComponent<PuzzleController>();
    }
    void OnDestroy()
    {
        notifier.UnsubcribeAll();
    }
    void Start()
    {
        puzzle = Create();
        controller.Puzzle = puzzle;
        notifier.Notify(ON_LOADED, puzzle);
    }
    private Puzzle Create()
    {
        Card[] cards = CreateCards();
        return new Puzzle(cards);
    }
    private Card[] CreateCards()
    {
        List<Card> cards = new List<Card>();
        for (int i = 0; i < matches; i++)
        {
            // *** Match number
            for (int j = 0; j < 2; j++)
            {
                Card newCard = new Card(i);
                cards.Add(newCard);
            }
        }        
        ListExtensions.Shuffle(cards);
        return cards.ToArray();
    }   
}