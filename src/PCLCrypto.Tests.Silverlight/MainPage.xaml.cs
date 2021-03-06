﻿namespace PCLCrypto.Tests.Silverlight
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using PCLTesting.Runner;

    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void RunTestsButton_Click(object sender, RoutedEventArgs e)
        {
            this.RunTestsButton.IsEnabled = false;
            this.TestRunProgress.Visibility = Visibility.Visible;
            this.TextSummaryText.Visibility = Visibility.Collapsed;

            try
            {
                var testRunner = new TestRunner(Assembly.GetExecutingAssembly());
                await TaskEx.Run(() => testRunner.RunTestsAsync());
                this.TextSummaryText.Text = string.Format(
                    CultureInfo.CurrentCulture,
                    "{0}/{1} tests passed ({2}%)",
                    testRunner.PassCount,
                    testRunner.TestCount,
                    100 * testRunner.PassCount / testRunner.TestCount);
                this.TextSummaryText.Visibility = Visibility.Visible;
                this.ResultsTextBox.Text = testRunner.Log;
            }
            catch (Exception ex)
            {
                this.ResultsTextBox.Text = ex.ToString();
            }
            finally
            {
                this.RunTestsButton.IsEnabled = true;
                this.TestRunProgress.Visibility = Visibility.Collapsed;
            }
        }
    }
}
