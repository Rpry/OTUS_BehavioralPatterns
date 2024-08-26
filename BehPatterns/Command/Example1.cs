namespace BehPatterns.Command1
{
    public class Editor
    {
        public Button Button { get; set; }
        public Checkbox Checkbox { get; set; }
    }

    public class Button
    {
        public void Click()
        {
            //делаем действие A
        }
    }
    
    public class Checkbox
    {
        public void Click()
        {
            //делаем действие B
        }
    }
}