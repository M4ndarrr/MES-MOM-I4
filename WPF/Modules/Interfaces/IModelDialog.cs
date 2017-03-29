//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-29
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : IModelDialog.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-29
//  Change History: 
// 
// ==================================
namespace WPF.Modules.Interfaces
{
    public interface IModalDialog
    {
        void BindViewModel<TViewModel>(TViewModel viewModel); //bind to viewModel

        void ShowDialog();  //show the modal window 

        void Close();  //close the dialog   
    }
}