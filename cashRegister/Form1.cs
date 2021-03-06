﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace cashRegister
{
    public partial class tenderedText : Form
    {

        public tenderedText()
        {
            InitializeComponent();
            scroll.Visible = false;
        }

        const double robesCost = 64.95;
        const double mapCost = 44.95;
        const double cauldronCost = 24.95;
        const double wandCost = 42.95;

        double totalRobes;
        double totalMap;
        double totalCauldron;
        double totalWand;
        double subTotal;
        double tax;
        double totalPrice;
        double change;

        int tendered;
        int robes;
        int map;
        int cauldron;
        int wand;

        int orderNumber = 1070;

        private void SchoolRobesText_TextChanged(object sender, EventArgs e)
        {
            //Change the format of the text to int
            //calculate total of item
            try
            {
                robes = Convert.ToInt16(schoolRobesText.Text);

                totalRobes = robes * robesCost;
            }
            catch
            {
                subTotalText.Text = "Must enter an int";
                return;
            }
        }

        private void MaraudersMapText_TextChanged(object sender, EventArgs e)
        {
            //Change the format of the text to int
            //calculate total of item
            try
            {
                map = Convert.ToInt16(maraudersMapText.Text);

                totalMap = map * mapCost;
            }
            catch
            {
                subTotalText.Text = "Must enter an int";
                return;
            }
        }

        private void CauldronText_TextChanged(object sender, EventArgs e)
        {
            //Change the format of the text to int
            //calculate total of item
            try
            {
                cauldron = Convert.ToInt16(cauldronText.Text);

                totalCauldron = cauldron * cauldronCost;
            }
            catch
            {
                subTotalText.Text = "Must enter an int";
                return;
            }
        }

        private void WandText_TextChanged(object sender, EventArgs e)
        {
            //Change the format of the text to int
            //calculate total of item
            try
            {
                wand = Convert.ToInt16(wandText.Text);

                totalWand = wand * wandCost;
            }
            catch
            {
                subTotalText.Text = "Must enter an int";
                return;
            }
        }

        private void CalculateTotal_Click(object sender, EventArgs e)
        {
            //Calculate subtotal, tax, and total
            subTotal = robesCost * robes + mapCost * map + cauldronCost * cauldron + wandCost * wand;
            tax = 0.13 * subTotal;
            totalPrice = subTotal + tax;

            subTotalText.Text = subTotal.ToString("C");
            taxText.Text = tax.ToString("C");
            totalText.Text = totalPrice.ToString("C");
        }

        private void TenderedBox_TextChanged(object sender, EventArgs e)
        {
            {
                //Change the format of the text to int
                //calculate total of item
                try
                {
                    tendered = Convert.ToInt16(tenderedBox.Text);

                    change = tendered - totalPrice;
                }
                catch
                {
                    subTotalText.Text = "Must enter an int";
                    return;
                }

            }
        }

        private void CalculateChange_Click(object sender, EventArgs e)
        {
            //calculate change and change text to string
            change = tendered - totalPrice;
            changeText.Text = change.ToString("C");
        }

        private void PrintReciept_Click(object sender, EventArgs e)
        {
            //make scroll visible
            scroll.Visible = true;

            //print receipt and make printing sound
            SoundPlayer printing = new SoundPlayer(Properties.Resources.printer);
            printing.Play();

            scroll.Text += "The Wizard Bank";
            Refresh();
            Thread.Sleep(500);

            printing.Play();
            scroll.Text += "\n" + "\n" + "Order Number " + orderNumber;
            Refresh();
            Thread.Sleep(500);

            printing.Play();
            scroll.Text += "\n August 31, 1564";
            Refresh();
            Thread.Sleep(500);

            printing.Play();
            scroll.Text += "\nSchool robes *           " + robes + " @ " + robesCost;
            Refresh();
            Thread.Sleep(500);

            printing.Play();
            scroll.Text += "\nMaurader's map *        " + map + " @ " + mapCost;
            Refresh();
            Thread.Sleep(500);

            printing.Play();
            scroll.Text += "\nCauldron *                " + cauldron + " @ " + cauldronCost;
            Refresh();
            Thread.Sleep(500);

            printing.Play();
            scroll.Text += "\nPhoenix feather wand * " + wand + " @ " + wandCost;
            Refresh();
            Thread.Sleep(500);

            printing.Play();
            scroll.Text += "\nSubtotal  " + subTotal.ToString("C");
            Refresh();
            Thread.Sleep(500);

            printing.Play();
            scroll.Text += "\nTax       " + tax.ToString("C");
            Refresh();
            Thread.Sleep(500);

            printing.Play();
            scroll.Text += "\nTotal     " + totalPrice.ToString("C");
            Refresh();
            Thread.Sleep(500);

            printing.Play();
            scroll.Text += "\nTendered  " + tendered.ToString("C");
            Refresh();
            Thread.Sleep(500);

            printing.Play();
            scroll.Text += "\nChange    " + change.ToString("C");
            Refresh();
            Thread.Sleep(500);

            printing.Play();
            scroll.Text += "\nHAVE A NICE DAY!!!:)";
            Refresh();
            Thread.Sleep(500);

            orderNumber++;
        }

        private void NewOrderButton_Click(object sender, EventArgs e)
        {
            //make scroll invisible
            scroll.Visible = false;

            //Empty all values for a new order
            schoolRobesText.Text = String.Empty;
            maraudersMapText.Text = String.Empty;
            cauldronText.Text = String.Empty;
            wandText.Text = String.Empty;
            subTotalText.Text = String.Empty;
            taxText.Text = String.Empty;
            totalText.Text = String.Empty;
            tenderedBox.Text = String.Empty;
            changeText.Text = String.Empty;
            scroll.Text = String.Empty;

            totalRobes = 0;
            totalMap = 0;
            totalCauldron = 0;
            totalWand = 0;
            subTotal = 0;
            tax = 0;
            totalPrice = 0;
            change = 0;
            tendered = 0;
            robes = 0;
            map = 0;
            cauldron = 0;
            wand = 0;
        }
    }
}
