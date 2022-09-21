using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace RStudio.QuestSystem
{
    [CreateAssetMenu]
    public class QuestData : ScriptableObject
    {
        private List<KeyValuePair<string, string[]>> _questNamesList => _questNames.ToList();

        private Dictionary<string, string[]> _questNames = new Dictionary<string, string[]>()
        {
            {"Hunt", new string[]{"Rabbit", "Boar", "Wolf"}},
            {"Slay", new string[]{"Goblin", "Orc", "Demon", "Demon Lord"}},
            {"Defend", new string[]{"Town", "Village", "Castle", "Kingdom"}},
            {"Assasinate", new string[]{"Merchant", "Noble", "King", "Demon Lord"}},
        };

        public string GetRandomQuestName()
        {
            var keyRand = UnityEngine.Random.Range(0, _questNamesList.Count);
            var valueRand = UnityEngine.Random.Range(0, _questNamesList[keyRand].Value.Length);

            return $"{_questNamesList[keyRand].Key} {_questNamesList[keyRand].Value[valueRand]}";
        }

        public int GetQuestDifficulty(int level)
        {
            var getHigherDifficulty = UnityEngine.Random.value <= 0.5f;

            var difficulty = 0;

            if (level <= 15) difficulty = 0;
            else if (level <= 30) difficulty = 1;
            else if (level <= 45) difficulty = 2;
            else if (level <= 60) difficulty = 3;
            else if (level <= 75) difficulty = 4;
            else if (level <= 90) difficulty = 5;
            else return difficulty = 6;

            if (getHigherDifficulty)
            {
                difficulty++;
            }

            return difficulty;
        }

        public string GetQuestDifficultyText(int difficulty) =>
        difficulty switch
        {
            0 => "F",
            1 => "E",
            2 => "D",
            3 => "C",
            4 => "B",
            5 => "A",
            6 => "S",
            _ => ""
        };

        public int GetExpReward(int difficulty) =>
        difficulty switch
        {
            0 => UnityEngine.Random.Range(45, 70),
            1 => UnityEngine.Random.Range(70, 95),
            2 => UnityEngine.Random.Range(95, 120),
            3 => UnityEngine.Random.Range(120, 145),
            4 => UnityEngine.Random.Range(145, 170),
            5 => UnityEngine.Random.Range(195, 220),
            6 => UnityEngine.Random.Range(220, 250),
            _ => 0
        };

        public int GetGoldReward(int difficulty) =>
        difficulty switch
        {
            0 => UnityEngine.Random.Range(45, 70),
            1 => UnityEngine.Random.Range(70, 95),
            2 => UnityEngine.Random.Range(95, 120),
            3 => UnityEngine.Random.Range(120, 145),
            4 => UnityEngine.Random.Range(145, 170),
            5 => UnityEngine.Random.Range(195, 220),
            6 => UnityEngine.Random.Range(220, 250),
            _ => 0
        };

        public float GetDuration(int difficulty) =>
        difficulty switch
        {
            0 => UnityEngine.Random.Range(30, 45),
            1 => UnityEngine.Random.Range(45, 65),
            2 => UnityEngine.Random.Range(65, 80),
            3 => UnityEngine.Random.Range(80, 95),
            4 => UnityEngine.Random.Range(95, 115),
            5 => UnityEngine.Random.Range(115, 130),
            6 => UnityEngine.Random.Range(130, 150),
            _ => 0
        };
    }
}
