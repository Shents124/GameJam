using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Assets.Scripts.DataCsv
{
    public class CardDataCsv : SerializedScriptableObject
    {
        public Dictionary<int, CardDataConfig> cardDict = new();
        private CardDataConfig[] _cardCsvs;

        public void CovertEnemyData()
        {
            cardDict = new();
            foreach (var item in _cardCsvs)
            {
                cardDict.Add(item.id, item);
            }
        }

        public struct CardDataConfig
        {
            public int id;

            public string GetPath()
            {
                return $"CardData{id}";
            }
        }
    }
}