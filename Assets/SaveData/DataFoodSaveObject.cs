using UnityEngine;

namespace CarterGames.Assets.SaveManager
{
    [CreateAssetMenu(fileName = "DataFoodSaveObject")]
    public class DataFoodSaveObject : SaveObject
    {
        public SaveValue<int> StarPoints = new SaveValue<int>("StarPoints");
        public SaveValue<string> FoodName = new SaveValue<string>("Food Name");
        public SaveValue<bool> FoodStatus = new SaveValue<bool>("Food Status");
    }
}