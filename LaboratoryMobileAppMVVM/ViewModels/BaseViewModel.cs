﻿using LaboratoryMobileAppMVVM.Models;
using LaboratoryMobileAppMVVM.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<ResponseNews> NewsDataStore => DependencyService
            .Get<IDataStore<ResponseNews>>();
        public IDataStore<ResponseService> ServiceDataStore => DependencyService
            .Get<IDataStore<ResponseService>>();
        public ILoginService<Patient> PatientLoginService => DependencyService
            .Get<ILoginService<Patient>>();
        public IRegisterService<Patient> PatientRegisterService => DependencyService
           .Get<IRegisterService<Patient>>();
        public IUpdateService<Patient> PatientUpdateService => DependencyService
       .Get<IUpdateService<Patient>>();

        private Patient currentPatient;

        private bool isBusy = false;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        private string title = string.Empty;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public Patient CurrentPatient
        {
            get => currentPatient; set
            {
                currentPatient = value;
                OnPropertyChanged();
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
