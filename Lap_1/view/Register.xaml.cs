using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Lap_1.entity;
using Newtonsoft.Json;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lap_1.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        private int checkGender;
        private string getDate;
        private int countError = 0;

        public Register()
        {
            this.InitializeComponent();
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            var check = sender as RadioButton;
            switch (check.Content)
            {
                case "Male":
                    checkGender = 1;
                    break;
                case "Fermale":
                    checkGender = 2;
                    break;
                case "Other":
                    checkGender = 3;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = new User() {
                FirstName = firstName.Text,
                LastName = lastName.Text,
                Address = address.Text,
                Email = email.Text,
                Password = password.Password,
                Phone = phone.Text,
                Avatar = avatar.Text,
                Gender = checkGender,
                Content = intro.Text,
                BirthDay = getDate
            };

            var jsonString = JsonConvert.SerializeObject(user);

            Validate(firstName.Text, lastName.Text, email.Text, address.Text, phone.Text, password.Password);

            if(countError == 0)
            {
                Debug.WriteLine(jsonString);

            };
        }

    

        private void birthday_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            var date = sender;
            getDate = date.Date.Value.ToString("dd-MM-yyyy");
        }

        private void Validate(string Fname, string Lname, string Email, string Address, string Phone, string Password)
        {
            if (string.IsNullOrEmpty(Fname))
            {
                firstNameError.Text = "FirstName is required";
                countError++;
            }
            if (string.IsNullOrEmpty(Lname))
            {
                lastNameError.Text = "LastName is required";
                countError++;
            }
            if (string.IsNullOrEmpty(Email))
            {
                emailError.Text = "Email is required";
                countError++;
            }
            if (string.IsNullOrEmpty(Address))
            {
                addressError.Text = "Address is required";
                countError++;
            }
            if (string.IsNullOrEmpty(Phone))
            {
                phoneError.Text = "Phone is required";
                countError++;
            }
            if (string.IsNullOrEmpty(Password))
            {
                passwordError.Text = "Password is required";
                countError++;
            }
        }
    }
}
