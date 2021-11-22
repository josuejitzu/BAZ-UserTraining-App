﻿using System;
using System.Collections.Generic;

[Serializable]
public class Puzzle
{   
    public Card[] cards;    
    public int moves;
    public int seconds;
    public int score;
    public bool inProgress;
    public int totalMatches;
    public Match current = new Match();
    public List<int> matches;
    public Puzzle (Card[] cards)
    {        
        this.cards = cards;
        current = new Match();
        matches = new List<int>();
        // *** Match number
        totalMatches = cards.Length / 2;
        inProgress = true;                
    }
}