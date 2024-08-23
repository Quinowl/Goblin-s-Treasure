using System.Collections.Generic;
using System.Threading.Tasks;

public class CommandQueue {

    private readonly Queue<ICommand> _commandsToExecute;
    private bool _isExecutingCommand;

    public CommandQueue() => _commandsToExecute = new Queue<ICommand>();

    public void AddCommand(ICommand newCommand) {

        _commandsToExecute.Enqueue(newCommand);
        ExecuteNextCommand().WrapErrors();
    }

    private async Task ExecuteNextCommand() {

        if (_isExecutingCommand) return;

        while (_commandsToExecute.Count > 0) {

            _isExecutingCommand = true;
            ICommand currentCommand = _commandsToExecute.Dequeue();
            await currentCommand.Execute();
        }

        _isExecutingCommand = false;
    }
}