﻿using possibilityZC.Models;
using possibilityZC.ViewModels.Navigation;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace possibilityZC.Views.Profile
{
    /// <summary>
    /// Page to show the article profile
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePage" /> class.
        /// </summary>
        public ProfilePage()
        {
            InitializeComponent();
        }
    }
}