using System;

namespace BehPatterns.Command2
{
    public interface ICommand
    {
        public void Execute();
    }

    public class CopyCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Copying...");
        }
    }
    
        
    public class Button
    {
        private ICommand _command;
        
        public void Click()
        {
            _command.Execute();
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }
        
        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
    
    public class Checkbox
    {
        private ICommand _command;
        
        public void Click()
        {
            _command.Execute();
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }
        
        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }

    public class Editor
    {
        public Button Button { get; set; }
        public Checkbox Checkbox { get; set; }

        public Editor()
        {
            Button = new Button();
            Checkbox = new Checkbox();
        }

        public void DoCopy()
        {
            var command = new Command2.CopyCommand();
            Button.SetCommand(command);
        }
    }

}