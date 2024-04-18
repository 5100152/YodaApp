using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Azure.AI.OpenAI;
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Mvvm.Input;
using YodaApp.Services.Interfaces;

namespace YodaApp.ViewModels
{
    public partial class YodaPageViewModel : BaseViewModel
    {
        private IAiAssistant _helper;

        private ChatMessage _response;

        public ChatMessage Response
        {
            get { return _response; }
            set
            {
                _response = value;

                OnPropertyChanged();
            }
        }

        public YodaPageViewModel(IAiAssistant helper)
        {
            _helper = helper;
        }

        [RelayCommand]
        public async void GetResponses()
        {
            Response = await _helper.GetCompletion();
        }
    }
}