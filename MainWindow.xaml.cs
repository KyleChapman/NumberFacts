// Author:  Kyle Chapman
// Created: September 18, 2025
// Description:
// Form to generate arbitrary facts about numbers using functions that only have one endpoint.

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NumberFacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Constructor for the MainWindow form.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            SetDefaults();
        }

        #endregion
        #region Event Handlers

        /// <summary>
        /// Gets two fun numeric facts based on the input number.
        /// </summary>
        private void GetNumberFact(object sender, RoutedEventArgs e)
        {
            // Validate the number by checking that the textbox value can be treated as a number.
            double factNumber;
            if (double.TryParse(textFactNumber.Text, out factNumber))
            {

                // Get the value of the input number raised to itself as an exponent.
                double numberToItself = Math.Pow(factNumber, factNumber);
                var factorialNumber = Factorial(factNumber);

                // Output!
                textOwnPower.Text = factNumber.ToString() + "^" + factNumber.ToString() + " is equal to " + numberToItself.ToString();

                if (factNumber > 0)
                {
                    textFactorial.Text = factNumber.ToString() + "! is equal to " + factorialNumber.ToString();
                }
                else
                {
                    textFactorial.Text = factNumber.ToString() + " is negative.";
                }

                // Disable input controls until the app is cleared.
                buttonGetFacts.IsEnabled = false;
                textFactNumber.IsEnabled = false;
                buttonClear.Focus();
            }
            else
            {
                // An error has occurred: the input isn't a number.
                MessageBox.Show("Your input '" + textFactNumber.Text + "' is not a valid number.");
                textFactNumber.SelectAll();
                textFactNumber.Focus();
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void CloseForm(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Close", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// Clears all input and output.
        /// </summary>
        private void ClearForm(object sender, RoutedEventArgs e)
        {
            SetDefaults();
        }

        #endregion
        #region Functions

        /// <summary>
        /// Returns the factorial of a whole number.
        /// </summary>
        /// <param name="number">Number to get factorial of.</param>
        /// <returns>Number multiplied by all lower positive integers.</returns>
        private double Factorial(double number)
        {
            if (number == 0)
            {
                return 1;
            }
            return number * Factorial(number - 1);
        }

        /// <summary>
        /// Reset the entire app to its default state.
        /// </summary>
        private void SetDefaults()
        {
            // Clear the input.
            textFactNumber.Clear();
            // Clear the output.
            textOwnPower.Clear();
            textFactorial.Clear();

            // Re-enable the calculation.
            buttonGetFacts.IsEnabled = true;
            textFactNumber.IsEnabled = true;

            // Sets the focus for the next entry.
            textFactNumber.Focus();
        }

        #endregion
    }
}