﻿using System;
using System.Linq;
using System.Text;
using RightPath.Algorithms;
using Xamarin.Forms;

namespace RightPath.Views
{
    public partial class ResultsPage : ContentPage
    {
        private readonly double[] _results;

        public ResultsPage(Questions questions)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            var calcEngine = new CalcEngine(questions);
            _results = calcEngine.GetResults(questions);
            TotalBasicLabel.Text = $"{_results[0]:C0}";
            TotalUpgradeLabel.Text = $"{_results[1]:C0}";

            var bigTicketTotal = _results[2] + _results[3] + _results[4] + _results[5] + _results[6];

            TotalBigLabel.Text = $"{bigTicketTotal:C0}";
            TotalRaritiesLabel.Text = $"{_results[7]:C0}";           

            var total = _results.Sum();
            TotalLabel.Text = $"{total:C0}";
            EstimateLabel.Text = $"{Math.Ceiling(total / 7500d)} weeks";
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void DetailButton_OnClicked(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Roof: {_results[2]:C0}");
            sb.AppendLine($"Foundation: {_results[3]:C0}");
            sb.AppendLine($"HVAC: {_results[4]:C0}");
            sb.AppendLine($"Electrical: {_results[5]:C0}");
            sb.AppendLine($"Plumbing: {_results[6]:C0}");

            DisplayAlert("Estimate Details", sb.ToString(), "Close");
        }
    }
}