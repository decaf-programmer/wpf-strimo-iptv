using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StrimoUI.Dialogs.References
{
    public class DialogService:IDialogService
    {
        public T OpenDialog<T>(DialogViewModelBase<T> viewModel)
        {
            DialogWindow window = new DialogWindow();
            window.DataContext = viewModel;

            try
            {
                window.ShowDialog();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                window.Close();
            }
            return viewModel.DialogResult;
        }
    }
}
