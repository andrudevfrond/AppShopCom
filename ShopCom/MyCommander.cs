﻿using System.Windows.Input;

namespace ShopCom;

public class MyCommander : ICommand
{
    Action _action;
    private readonly Func<bool> _canExecute;
    public MyCommander( Action action, Func<bool> canExecute)
    {
        _action = action;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;
    public void RaiseCanExecuteChanged() { 
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
    public bool CanExecute(object? parameter)
    {
        return _canExecute();
    }

    public void Execute(object? parameter)
    {
        _action();
    }
}
