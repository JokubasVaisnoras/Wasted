using System;
using System.Collections.Generic;
using System.ComponentModel;
using wasted_app.Models;
using wasted_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Linq;
using System.Reflection;

namespace wasted_app.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }

        void OnModeChosen(object sender, EventArgs args)
        {
            Picker typePicker = (Picker)sender;

            int type = typePicker.SelectedIndex;
            type2Picker.Items.Clear();

            switch (type)
            {
                case 0: //product
                    type2Picker.IsEnabled = true;

                    /*try
                    {
                        
                        // Directory.GetCurrentDirectory().ToString();
                        // List<string> possibleTypes = new List<string>();

                        //string path = Path.Combine(Directory.GetCurrentDirectory(), "..");

                        //string path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;//ToString();

                        //string path = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName;

                        //string path = Path.GetFullPath(@"/ProductTypes.txt");

                        

                        //DisplayAlert("", path, "", "Cancel");

                        /*using (StreamReader sr = new StreamReader(Path.Combine(path, "ProductTypes.txt")))
                        {
                            string line;

                            while ((line = sr.ReadLine()) != null)
                            {
                                type2Picker.Items.Add(line);
                            }
                        }*/ /*
                    }
                    catch (Exception)
                    {
                        DisplayAlert("Error", "Cannot recover any data.", "", "Cancel");
                    }
                    */

                    var assembly = IntrospectionExtensions.GetTypeInfo(typeof(NewItemPage)).Assembly;
                    Stream stream = assembly.GetManifestResourceStream("wasted_app.Views.ProductTypes.txt");
                    string text;
                    using (var reader = new StreamReader(stream))
                    {
                        text = reader.ReadToEnd();
                    }

                    List<string> possibleTypes = text.Split('\n').ToList();

                    foreach (string line in possibleTypes)
                    {
                        type2Picker.Items.Add(line);
                    }
                    break;
                case 1: //prepared meal
                    type2Picker.IsEnabled = true;

                    var assembly2 = IntrospectionExtensions.GetTypeInfo(typeof(NewItemPage)).Assembly;
                    Stream stream2 = assembly2.GetManifestResourceStream("wasted_app.Views.PreparedFoods.txt");
                    string text2;
                    using (var reader = new StreamReader(stream2))
                    {
                        text2 = reader.ReadToEnd();
                    }

                    List<string> possibleTypes2 = text2.Split('\n').ToList();

                    foreach (string line in possibleTypes2)
                    {
                        type2Picker.Items.Add(line);
                    }
                    break;
                case 2: //package
                    type2Picker.IsEnabled = true;
                    type2Picker.Items.Add("Small");
                    type2Picker.Items.Add("Medium");
                    type2Picker.Items.Add("Large");
                    break;
            }
        }
    }
}