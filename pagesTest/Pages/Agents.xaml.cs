using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using pagesTest.Backend;

namespace pagesTest.Pages_
{
    /// <summary>
    /// Interaction logic for Agents.xaml
    /// </summary>
    public partial class Agents : Page
    {
        Agent agent;
        string firstName;
        string lastName;
        string code;
        int hour, minute;
        Time startTime = new Time();
        Time endTime = new Time();
        string extension;
        string extraHours;
        string specialty;

        string auxString;
        public Agents()
        {
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            firstName = AgentFirstName.Text.ToString();
            lastName = AgentLastName.Text.ToString();
            code = AgentCode.Text.ToString();

            if(!Int32.TryParse(AgentHourStart.Text.ToString(), out hour))
            {
                MessagesTextBox.Text = "Only numbers are allowed when adding the start time and end time";
                return;
            }
            if (!Int32.TryParse(AgentMinuteStart.Text.ToString(), out minute))
            {
                MessagesTextBox.Text = "Only numbers are allowed when adding the start time and end time";
                return;
            }
            startTime.setTime(hour, minute);

            if (!Int32.TryParse(AgentHourEnd.Text.ToString(), out hour))
            {
                MessagesTextBox.Text = "Only numbers are allowed when adding the start time and end time";
                return;
            }
            if (!Int32.TryParse(AgentMinuteEnd.Text.ToString(), out minute))
            {
                MessagesTextBox.Text = "Only numbers are allowed when adding the start time and end time";
                return;
            }
            endTime.setTime(hour, minute);

            extension = AgentExtension.Text.ToString();
            extraHours = AgentExtraHours.Text.ToString();
            specialty = AgentSpecialty.Text.ToString();

            agent = new Agent(firstName, lastName, code, startTime, endTime, extension, extraHours, specialty);
        }

        private void NumberTextBoxValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
