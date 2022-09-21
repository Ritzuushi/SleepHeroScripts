using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RStudio.QuestSystem
{
    public class QuestContainerUi : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _questName;
        public TextMeshProUGUI QuestName => _questName;
        [SerializeField]
        private TextMeshProUGUI _questDifficulty;
        public TextMeshProUGUI QuestDifficulty => _questDifficulty;
        [SerializeField]
        private TextMeshProUGUI _questExpReward;
        public TextMeshProUGUI QuestExpReward => _questExpReward;
        [SerializeField]
        private TextMeshProUGUI _questGoldReward;
        public TextMeshProUGUI QuestGoldReward => _questGoldReward;
        [SerializeField]
        private TextMeshProUGUI _questDuration;
        public TextMeshProUGUI QuestDuration => _questDuration;

        private void Awake()
        {
            _questName = gameObject.transform.Find("QuestName").GetComponent<TextMeshProUGUI>();
            _questDifficulty = gameObject.transform.Find("QuestDifficulty").GetComponent<TextMeshProUGUI>();
            _questExpReward = gameObject.transform.Find("ExpReward").GetComponent<TextMeshProUGUI>();
            _questGoldReward = gameObject.transform.Find("GoldReward").GetComponent<TextMeshProUGUI>();
            _questDuration = gameObject.transform.Find("QuestDuration").GetComponent<TextMeshProUGUI>();
        }

        public void SetTextValues(string questName, string questDifficulty, string questExpReward, string questGoldReward, string questDuration)
        {
            _questName.SetText(questName);
            _questDifficulty.SetText(questDifficulty);
            _questExpReward.SetText(questExpReward);
            _questGoldReward.SetText(questGoldReward);
            _questDuration.SetText(questDuration);
        }
    }
}
