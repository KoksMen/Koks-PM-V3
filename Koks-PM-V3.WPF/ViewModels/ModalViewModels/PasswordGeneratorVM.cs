using DevExpress.Mvvm;
using Koks_PM_V3.WPF.Commands;
using Koks_PM_V3.WPF.Commands.ClosePageCommands;
using Koks_PM_V3.WPF.Services;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Telegram.Bot.Types.Passport;

namespace Koks_PM_V3.WPF.ViewModels.ModalViewModels
{
    public class PasswordGeneratorVM : BindableBase
    {
		private readonly PasswordGeneratorDataStore passwordGeneratorDataStore;
		private readonly ModalPageNavigator modalPagenavigator;

        public PasswordGeneratorVM(PasswordGeneratorDataStore passwordGeneratorDataStore, ModalPageNavigator modalPagenavigator)
        {
            this.passwordGeneratorDataStore = passwordGeneratorDataStore;
            this.modalPagenavigator = modalPagenavigator;

			PasswordGeneratorService passwordGeneratorService = new PasswordGeneratorService(passwordLenght, isHaveUpperChars, isHaveLowerChars, isHaveDigits, isHaveSpecialChars);
			generatedPassword = passwordGeneratorService.Generate();
        }

        private string _generatedPassword = string.Empty;

		public string generatedPassword
        {
			get { return _generatedPassword; }
			set { _generatedPassword = value; RaisePropertiesChanged(nameof(generatedPassword));  }
		}

		private int _passwordLenght = 8;

		public int passwordLenght
        {
			get { return _passwordLenght; }
			set { _passwordLenght = value; RaisePropertiesChanged(nameof(passwordLenght)); RaisePropertiesChanged(nameof(regeneratePasswordCommand)); }
		}

		private bool _isHaveUpperChars = false;

		public bool isHaveUpperChars
        {
			get { return _isHaveUpperChars; }
			set { _isHaveUpperChars = value; RaisePropertiesChanged(nameof(isHaveUpperChars)); RaisePropertiesChanged(nameof(regeneratePasswordCommand)); }
		}

		private bool _isHaveLowerChars = true;

		public bool isHaveLowerChars
        {
			get { return _isHaveLowerChars; }
			set { _isHaveLowerChars = value; RaisePropertiesChanged(nameof(isHaveLowerChars)); RaisePropertiesChanged(nameof(regeneratePasswordCommand)); }
		}

		private bool _isHaveDigits = false;

		public bool isHaveDigits
        {
			get { return _isHaveDigits; }
			set { _isHaveDigits = value; RaisePropertiesChanged(nameof(isHaveDigits)); RaisePropertiesChanged(nameof(regeneratePasswordCommand)); }
		}

		private bool _isHaveSpecialChars = false;


        public bool isHaveSpecialChars
        {
			get { return _isHaveSpecialChars; }
			set { _isHaveSpecialChars = value; }
		}

		public ICommand regeneratePasswordCommand => new RelayCommand(parameter =>
		{
			PasswordGeneratorService generatorService = new(passwordLenght, isHaveUpperChars, isHaveLowerChars, isHaveDigits, isHaveSpecialChars);
			generatedPassword = generatorService.Generate();
		});
		public ICommand copyPasswordCommand => new RelayCommand(parameter => 
		{
			Clipboard.SetText(generatedPassword);
		});
		public ICommand savePasswordCommand => new RelayCommand(parameter =>
		{
			passwordGeneratorDataStore.generatedPassword = generatedPassword;
			cancelCommand.Execute(this);
		}, parameter => !generatedPassword.IsNullOrEmpty());
		public ICommand cancelCommand => new CloseModalPageCommand(modalPagenavigator);

    }
}
