using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tag
{
    Player,
    Enemy
}

public static class TagParser
{
    public static string Parse(Tag tag)
    {
        switch (tag)
        {
            case Tag.Player:
                return "Player";

            case Tag.Enemy:
                return "Enemy";
        }

        return "";
    }
}