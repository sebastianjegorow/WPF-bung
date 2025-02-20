using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CheckSumAufgabe
{
    public partial class MainWindow : Window
    {
        public ChecksumCalculator calculator;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e) //Feedback zur Moduswahl
        {
            if (rbValidate.IsChecked == true)
            {
                labelResult.Content = "Modus: Validieren";
            }
            else if (rbCalculate.IsChecked == true)
            {
                labelResult.Content = "Modus: Berechnen";
            }
        }

        private void ddAuswahl_SelectionChanged(object sender, SelectionChangedEventArgs e)     //DropdownAction (Calc-Auswahl)
        {
            ChecksumFactory cf = new ChecksumFactory();
            if (ddAuswahl.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedAlgorithm = selectedItem.Content.ToString();

                switch (selectedAlgorithm)
                {
                    case "Luhn":
                        labelResult.Content = "Luhn-Algorithmus ausgewählt";
                        
                        calculator = cf.GetCalculator("luhn");
                        break;
                    case "ISBN10":
                        labelResult.Content = "ISBN-10-Algorithmus ausgewählt";
                        
                        calculator = cf.GetCalculator("ISBN10");
                        break;
                    case "ISBN13":
                        labelResult.Content = "ISBN-13-Algorithmus ausgewählt";
                        
                        calculator = cf.GetCalculator("ISBN13");
                        break;
                    default:
                        labelResult.Content = "Keine gültige Auswahl";
                        break;
                }
            }
        }

        private void tbInput_KeyUp(object sender, KeyEventArgs e)
        {
            labelResult.Foreground = Brushes.Black;

            if (calculator == null)                                         //Nur Feedback zur Befüllung
            {
                labelResult.Content = "Wählen Sie den Algorithmus";
                return;
            }
            if (string.IsNullOrWhiteSpace(tbInput.Text))
            {
                labelResult.Content = "Geben Sie Ihre Nummer ein";
                return;
            }

            if (rbValidate.IsChecked == true)                               //Validierung
            {
                if (calculator.Validate(tbInput.Text))
                {
                    labelResult.Foreground = Brushes.Green;
                    labelResult.Content = "Eingegebene Nummer ist gültig";
                }
                else
                {
                    labelResult.Foreground = Brushes.Red;
                    labelResult.Content = "Eingegebene Nummer ist nicht gültig";
                }
            }
            else if (rbCalculate.IsChecked == true)                         //Berechnung
            {
                int pruefziffer = calculator.CalculateCheckDigit(tbInput.Text);

                if (pruefziffer == -1)
                    labelResult.Content = $"Ihre Eingabe ist zu kurz oder zu lang";
                else

                    labelResult.Content = $"Die Prüfziffer für deine Nummer ist {pruefziffer}";
            }
        }

    }
}
