using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EL.MAUI.BlackList.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.ViewModel
{
    internal partial class ShellPageViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task PressButton()
        {
            var stack = Shell.Current.Navigation.NavigationStack.ToArray();
            if (stack.Length > 0)
            {
                for (int i = stack.Length - 1; i > 0; i--)
                {
                    Shell.Current.Navigation.RemovePage(stack[i]);
                }
            }
            await Shell.Current.GoToAsync($"{nameof(HomePage)}?{nameof(HomePageViewModel)}");
        }
    }
}
