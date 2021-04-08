using GalaSoft.MvvmLight.Command;
using StrimoUI.Components.Dialogs.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StrimoUI.Components.Dialogs.AlertDialog
{
    public class AlertDialogViewModel:DialogViewModelBase<DialogResult>
    {
        public ICommand OKCommand { get; private set; }

        public AlertDialogViewModel(string title, string message) : base(title, message)
        {
            OKCommand = new RelayCommand<IDialogWindow>(OK);
        }

        private void OK(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResult.Undefined);
        }
    }
}
