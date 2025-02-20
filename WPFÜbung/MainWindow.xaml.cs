using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFÜbung;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public bool eingabenameok = false;
    public bool eingabeemailok = false;
    public bool eingabetelefonok = false;
    public bool eingabeipok = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void tbName_KeyUp(object sender, KeyEventArgs e)
    {
        if (Regex.IsMatch(tbName.Text, @"[@#!$&]"))
        {
            labelFeedback.Foreground = Brushes.Red;
            labelFeedback.Content = "Da stimmt etwas nicht!";
            eingabenameok = false;
        }

        else if (Regex.IsMatch(tbName.Text, @"^[^@#!$&]+$"))
        {
            labelFeedback.Foreground = Brushes.Green;
            labelFeedback.Content = "Eingabe OK!";
            eingabenameok = true;
        } 

        else
        { 
            labelFeedback.Content = "";
        }
    }


    


    private void tbEmail_KeyUp(object sender, KeyEventArgs e)
    {
        if (Regex.IsMatch(tbEmail.Text, @"^[A-Za-z0-9-]+@[A-Za-z0-9-]+[.][A-Za-z0-9.-]{2,5}$"))
        {
            labelFeedback.Foreground = Brushes.Green;
            labelFeedback.Content = "E-Mail Adresse ok.";
            eingabeemailok = true;

        }
        else
                {
                    labelFeedback.Foreground = Brushes.Red;
                    labelFeedback.Content = "E-Mail Adresse nicht ok!";
                    eingabeemailok = false;
        }
    }

    private void tbTelefon_KeyUp(object sender, KeyEventArgs e)
    {
        if (Regex.IsMatch(tbTelefon.Text, @"^\+[0-9]{2} [0-9]{3,4} [0-9]{4,8}$"))
        {
            labelFeedback.Foreground = Brushes.Green;
            labelFeedback.Content = "Telefon-Nummer ok.";
            eingabetelefonok = true;
        }
        else
        {
            labelFeedback.Foreground = Brushes.Red;
            labelFeedback.Content = "Telefon-Nummer nicht ok!";
            eingabetelefonok = false;
        }
    }



    private void tbIP_KeyUp(object sender, KeyEventArgs e)
    {
        if (Regex.IsMatch(tbIP.Text, @"^(25[0-5]|2[0-4]\d|1\d{2}|[1-9]\d|\d)\.(25[0-5]|2[0-4]\d|1\d{2}|[1-9]\d|\d)\.(25[0-5]|2[0-4]\d|1\d{2}|[1-9]\d|\d)\.(25[0-5]|2[0-4]\d|1\d{2}|[1-9]\d|\d)$"))
        {
            labelFeedback.Foreground = Brushes.Green;
            labelFeedback.Content = "IP-Adresse ok.";
            eingabeipok = true;
        }
        else
        {
            labelFeedback.Foreground = Brushes.Red;
            labelFeedback.Content = "IP-Adresse nicht ok!";
            eingabeipok = false;
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (eingabenameok && eingabeemailok && eingabetelefonok && eingabeipok)
            {
            string Path = @"C:\Users\ITA7-TN03\Downloads\test\buttonkramoutput.txt";
            StreamWriter writer = new StreamWriter(Path);
            writer.WriteLine($"Anwendername: {tbName.Text}");
            writer.WriteLine($"E-Mail Adresse: {tbEmail.Text}");
            writer.WriteLine($"Telefon: {tbTelefon.Text}");
            writer.WriteLine($"IP Adresse: {tbIP.Text}");
            writer.Close();
            labelFeedback.Content = "Deine Eingabe wurde gespeichert";
        }
        else
        {
            labelFeedback.Foreground = Brushes.Red;
            labelFeedback.Content = "Eingabe ist nicht ok!";
        }



    }
}