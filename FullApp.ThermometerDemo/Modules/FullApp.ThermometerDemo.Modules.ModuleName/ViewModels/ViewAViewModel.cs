using FullApp.ThermometerDemo.Core.Mvvm;
using FullApp.ThermometerDemo.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;

namespace FullApp.ThermometerDemo.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        private DelegateCommand<bool?> _MyCommand;

        public DelegateCommand<bool?> MyCommand =>
            _MyCommand ?? (_MyCommand = new DelegateCommand<bool?>(ExecuteMyCommand));

        private void ExecuteMyCommand(bool? obj)
        {
        }
    }
}