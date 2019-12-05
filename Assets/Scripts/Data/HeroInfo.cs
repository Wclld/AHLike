using UnityEngine;

namespace AHLike.Data
{
    [CreateAssetMenu(fileName = "HeroInfo", menuName = "AHLikeGame/HeroInfo")]
    public class HeroInfo : ScriptableObject 
    {
        public GameObject Prefab;
        public string Name;
        public Sprite Icon;
        public float MaxHP;
        public float AtackSpeed;
        public float AtackDamage;
    }
}