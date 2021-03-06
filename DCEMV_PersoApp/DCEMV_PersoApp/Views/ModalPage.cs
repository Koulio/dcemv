﻿/*
*************************************************************************
DC EMV
Open Source EMV
Copyright (C) 2018  Vicente Da Silva

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published
by the Free Software Foundation, either version 3 of the License, or
any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see http://www.gnu.org/licenses/
*************************************************************************
*/
using System;
using Xamarin.Forms;

namespace DCEMV.PersoApp
{

    public class ModalPage : ContentPage
    {
        public EventHandler PageClosing;

        public void OnPageClosing()
        {
            PageClosing?.Invoke(this, new EventArgs());
        }

        protected void DisplayValidationError(string message)
        {
            DisplayAlert("Validation", message, "ok");
        } 

        public void ClosePage()
        {
            if (Navigation.ModalStack.Count == 0)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    OnPageClosing();
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    OnPageClosing();
                    await Navigation.PopModalAsync();
                });
            }
        }

        public void OpenPage(ContentPage page)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Navigation.PushModalAsync(page);
            });
            
        }
    }
}
