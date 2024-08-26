using System.Collections.Generic;

namespace BehPatterns.Memento1
{
    public class ClassWithStateShouldBeRollBacked
    {
        public string _field { get; set; }
        
        public List<string> SavedData { get; set; }

        public ClassWithStateShouldBeRollBacked()
        {
            SavedData = new List<string>();
        }
        
        public void SaveState()
        {
            SavedData.Add(_field);
        }
    }
}