using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReedTask1_1VictorianMoneyTracker
{
    /// <summary>
    /// An App that helps keep track of Victorian Money Amounts.
    /// Michael Reed 20056066
    /// 31/01/24
    /// 
    /// Note: Conversion Rates are as follows
    /// 1 pound = 4 crowns
    /// 1 crown = 5 shillings
    /// 1 shilling = 12 pence
    /// 1 penny = 4 farthings
    /// 
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Constant conversion rates for denominations
        const int crownsToPounds = 4; 
        const int shillingsToCrowns = 5;
        const int penceToShillings = 12;
        const int farthingsToPence = 4;

        public MainPage()
        {
            this.InitializeComponent();
            UpdateTotalWorth(); // initialise the display and check for correct amounts
        }

        private void AmountDecrease_Click(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine("decrease");
            Button button = (Button)sender;
            int result;

            switch (button.Name)
            {
                case "poundsDecrease":
                    // do something for button1
                    Debug.WriteLine("decrease pounds");
                    result = Int32.Parse(poundsAmount.Text);
                    if (result > 0)
                    {
                        result -= 1;
                        poundsAmount.Text = result.ToString();
                    }
                    break;
                case "crownsDecrease":
                    // do something for button2
                    Debug.WriteLine("decrease crowns");
                    result = Int32.Parse(crownsAmount.Text);
                    if (result > 0)
                    {
                        result -= 1;
                        crownsAmount.Text = result.ToString();
                    }
                    break;
                case "shillingsDecrease":
                    // do something for button2
                    Debug.WriteLine("decrease shillings");
                    result = Int32.Parse(shillingsAmount.Text);
                    if (result > 0)
                    {
                        result -= 1;
                        shillingsAmount.Text = result.ToString();
                    }
                    break;
                case "penceDecrease":
                    // do something for button2
                    Debug.WriteLine("decrease pence");
                    result = Int32.Parse(penceAmount.Text);
                    if(result > 0)
                    {
                        result -= 1;
                        penceAmount.Text = result.ToString();
                    }
                    break;
                case "farthingsDecrease":
                    // do something for button2
                    Debug.WriteLine("decrease farthings");
                    result = Int32.Parse(farthingsAmount.Text);
                    if (result > 0)
                    {
                        result -= 1;
                        farthingsAmount.Text = result.ToString();
                    }
                    break;
            }

            UpdateTotalWorth();
        }

        private void AmountIncrease_Click(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine("increase");
            Button button = (Button)sender;
            int result;

            switch (button.Name)
            {
                case "poundsIncrease":
                    // do something for button1
                    Debug.WriteLine("increase pounds");
                    result = Int32.Parse(poundsAmount.Text);
                    result += 1;
                    poundsAmount.Text = result.ToString();
                    break;
                case "crownsIncrease":
                    // do something for button2
                    Debug.WriteLine("increase crowns");
                    result = Int32.Parse(crownsAmount.Text);
                    result += 1;
                    crownsAmount.Text = result.ToString();
                    break;
                case "shillingsIncrease":
                    // do something for button2
                    Debug.WriteLine("increase shillings");
                    result = Int32.Parse(shillingsAmount.Text);
                    result += 1;
                    shillingsAmount.Text = result.ToString();
                    break;
                case "penceIncrease":
                    // do something for button2
                    Debug.WriteLine("increase pence");
                    result = Int32.Parse(penceAmount.Text);
                    result += 1;
                    penceAmount.Text = result.ToString();
                    break;
                case "farthingsIncrease":
                    // do something for button2
                    Debug.WriteLine("increase farthings");
                    result = Int32.Parse(farthingsAmount.Text);
                    result += 1;
                    farthingsAmount.Text = result.ToString();
                    break;
            }

            UpdateTotalWorth();
        }

        private void AmountConvertUp_Click(object sender, RoutedEventArgs e)
        {
            //.WriteLine("Convert Up");
            Button button = (Button)sender;

            // calculate money on hand from string to integer
            int poundsOnHand = GetActualMoneyOnHand("pounds");
            int crownsOnHand = GetActualMoneyOnHand("crowns");
            int shillingsOnHand = GetActualMoneyOnHand("shillings");
            int penceOnHand = GetActualMoneyOnHand("pence");
            int farthingsOnHand = GetActualMoneyOnHand("farthings");

            switch (button.Name)
            {
                case "crownsConvertUp":
                    Debug.WriteLine("convert crowns up");
                    //quotient = crownsOnHand / crownsToPounds;
                    //remainder = crownsOnHand % crownsToPounds;
                    //crownsAmount.Text = remainder.ToString();
                    //poundsAmount.Text = (poundsOnHand + quotient).ToString();
                    if (crownsOnHand >= crownsToPounds)
                    {
                        crownsAmount.Text = (crownsOnHand - crownsToPounds).ToString();
                        poundsAmount.Text = (poundsOnHand + 1).ToString();
                    }
                    break;
                case "shillingsConvertUp":
                    Debug.WriteLine("shillings convert up");
                    //quotient = shillingsOnHand / shillingsToCrowns;
                    //remainder = shillingsOnHand % shillingsToCrowns;
                    //shillingsAmount.Text = remainder.ToString();
                    //crownsAmount.Text = (crownsOnHand + quotient).ToString();
                    if (shillingsOnHand >= shillingsToCrowns)
                    {
                        shillingsAmount.Text = (shillingsOnHand - shillingsToCrowns).ToString();
                        crownsAmount.Text = (crownsOnHand + 1).ToString();
                    }
                    break;
                case "penceConvertUp":
                    Debug.WriteLine("pence convert up");
                    //quotient = penceOnHand / penceToShillings;
                    //remainder = penceOnHand % penceToShillings;
                    //penceAmount.Text = remainder.ToString();
                    //shillingsAmount.Text = (shillingsOnHand + quotient).ToString();
                    if (penceOnHand >= penceToShillings)
                    {
                        penceAmount.Text = (penceOnHand - penceToShillings).ToString();
                        shillingsAmount.Text = (shillingsOnHand + 1).ToString();
                    }
                    break;
                case "farthingsConvertUp":
                    Debug.WriteLine("farthings convert up");
                    //quotient = farthingsOnHand / farthingsToPence;
                    //remainder = farthingsOnHand % farthingsToPence;
                    //farthingsAmount.Text = remainder.ToString();
                    //penceAmount.Text = (penceOnHand + quotient).ToString();
                    if (farthingsOnHand >= farthingsToPence)
                    {
                        farthingsAmount.Text = (farthingsOnHand - farthingsToPence).ToString();
                        penceAmount.Text = (penceOnHand + 1).ToString();
                    }
                    break;
            }

            UpdateTotalWorth();
        }

        private void AmountConvertDown_Click(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine("Convert Down");
            Button button = (Button)sender;

            // calculate money on hand from string to integer
            int poundsOnHand = GetActualMoneyOnHand("pounds");
            int crownsOnHand = GetActualMoneyOnHand("crowns");
            int shillingsOnHand = GetActualMoneyOnHand("shillings");
            int penceOnHand = GetActualMoneyOnHand("pence");
            int farthingsOnHand = GetActualMoneyOnHand("farthings");

            switch (button.Name)
            {
                case "poundsConvertDown":
                    Debug.WriteLine("pounds convert down");
                    // 1 pound = 4 crowns
                    if (poundsOnHand > 0)
                    {
                        crownsAmount.Text = (crownsOnHand + (crownsToPounds)).ToString();
                        poundsAmount.Text = (poundsOnHand - 1).ToString();
                    }
                    break;
                case "crownsConvertDown":
                    Debug.WriteLine("crowns convert down");
                    // 1 crown = 5 shillings
                    if (crownsOnHand > 0)
                    {
                        shillingsAmount.Text = (shillingsOnHand + (shillingsToCrowns)).ToString();
                        crownsAmount.Text = (crownsOnHand - 1).ToString();
                    }
                    break;
                case "shillingsConvertDown":
                    Debug.WriteLine("shillings convert down");
                    //1 shilling = 12 pence
                    if (shillingsOnHand > 0)
                    {
                        penceAmount.Text = (penceOnHand + (penceToShillings)).ToString();
                        shillingsAmount.Text = (shillingsOnHand - 1).ToString();
                    }
                    break;
                case "penceConvertDown":
                    Debug.WriteLine("penceConvertDown");
                    // 1 pence = 4 farthings
                    if (penceOnHand > 0)
                    {
                        farthingsAmount.Text = (farthingsOnHand + (farthingsToPence)).ToString();
                        penceAmount.Text = (penceOnHand - 1).ToString();
                    }
                    break;
            }
            
            UpdateTotalWorth();
        }

        public int GetActualMoneyOnHand(string denomination)
        {
            int amount = 0;
            
            // calculate money on hand from string to integer
            switch (denomination)
            {
                case "pounds":
                    amount = Int32.Parse(poundsAmount.Text);
                    return amount;

                case "crowns":
                    amount = Int32.Parse(crownsAmount.Text);
                    return amount;

                case "shillings":
                    amount = Int32.Parse(shillingsAmount.Text);
                    return amount;

                case "pence":
                    amount = Int32.Parse(penceAmount.Text);
                    return amount;

                case "farthings":
                    amount = Int32.Parse(farthingsAmount.Text);
                    return amount;
            }
            return amount;
        }

        public void UpdateTotalWorth()
        {

            // calculate money on hand from string to integer
            int poundsOnHand = GetActualMoneyOnHand("pounds");
            int crownsOnHand = GetActualMoneyOnHand("crowns");
            int shillingsOnHand = GetActualMoneyOnHand("shillings");
            int penceOnHand = GetActualMoneyOnHand("pence");
            int farthingsOnHand = GetActualMoneyOnHand("farthings");

            /// <summary>
            /// Convert Total Worth to Actual value of holdings
            /// Convert up denominations if required and give Total Value in correct format
            /// If required adjust denomination title to be either singular or plural
            /// <summary>

            // convert farthings to pence
            int farthingsConverted = farthingsOnHand / farthingsToPence;
            penceOnHand += farthingsConverted;
            int farthingsRemainder = farthingsOnHand % farthingsToPence;
            
            // check if farthings is multiple or singkle and adjust title
            if (farthingsRemainder == 1)
            {
                farthingsTitle.Text = "Farthing";
            }
            else
            {
                farthingsTitle.Text = "Farthings";
            }

            // pence to shillings
            int penceConverted = penceOnHand / penceToShillings;
            shillingsOnHand += penceConverted;
            int penceRemainder = penceOnHand % penceToShillings;

            // check if pence is multiple or single and adjust title
            if (penceRemainder == 1)
            {
                penceTitle.Text = "Penny";
            }
            else
            {
                penceTitle.Text = "Pence";
            }

            // shillings to crowns
            int shillingsConverted = shillingsOnHand / shillingsToCrowns;
            crownsOnHand += shillingsConverted;
            int shillingsRemainder = shillingsOnHand % shillingsToCrowns;

            // check if shillings is multiple or single and adjust title
            if (shillingsRemainder == 1)
            {
                shillingsTitle.Text = "Shilling";
            }
            else
            {
                shillingsTitle.Text = "Shillings";
            }

            // crowns to pounds
            int crownsConverted = crownsOnHand / crownsToPounds;
            poundsOnHand += crownsConverted;
            int crownsRemainder = crownsOnHand % crownsToPounds;

            // check if crowns is multiple or single and adjust title
            if (crownsRemainder == 1)
            {
                crownsTitle.Text = "Crown";
            }
            else
            {
                crownsTitle.Text = "Crowns";
            }

            // check if pounds is multiple or single and adjust title
            if (poundsOnHand == 1)
            {
               poundsTitle.Text = "Pound";
            }
            else
            {
                poundsTitle.Text = "Pounds";
            }

            // Display the Total Worth Correctly
            totalWorthAmount.Text = "£" + poundsOnHand + " " + crownsRemainder + "c " + shillingsRemainder + "s "
                    + penceRemainder + "d " + farthingsRemainder + "f";

        }
    } 
}
