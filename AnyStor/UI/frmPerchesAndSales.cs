using AnyStor.BLL;
using AnyStor.DAL;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace AnyStor.UI
{
    public partial class frmPerchesAndSales : Form
    {
        public frmPerchesAndSales()
        {
            InitializeComponent();
        }

        //Hide Form
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        DeaCustDAL dcDAL = new DeaCustDAL();
        productDAL pDAL = new productDAL();
        userDAL uDAL = new userDAL();
        transactionDAL tDAL = new transactionDAL();
        transactionDetail tdDAL = new transactionDetail();

        DataTable tansactionDT = new DataTable();

        //Form Load
        private void frmPerchesAndSales_Load(object sender, EventArgs e)
        {
            String type = frmUserDashbord.transactionType;
            lblTop.Text = type;

            //Set the Column for our Transaction Table
            tansactionDT.Columns.Add("Product Name");
            tansactionDT.Columns.Add("Rate");
            tansactionDT.Columns.Add("Qty");
            tansactionDT.Columns.Add("total");
        }

        //Delar and Custemer Search Text Box Code
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            //Get the keword for the text box
            String keyword = searchTextBox.Text;

            if (keyword == "")
            {
                //Clear All the texboxes
                nameTextBox.Text = "";
                emailTextBox.Text = "";
                contactTextBox.Text = "";
                addressTextBox.Text = "";
                return;
            }

            //Write the code get the details and set the value on textbox 
            DeaCustBLL dc = dcDAL.SelectDealerCustemorForTransaction(keyword);

            //Transfer or set the value DeaCustBLL to text boxes 
            nameTextBox.Text = dc.name;
            emailTextBox.Text = dc.email;
            contactTextBox.Text = dc.contact;
            addressTextBox.Text = dc.address; 
        }

        //Product Search Text Box Code
        private void productSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            //Get the keyword from product TextBox
            string keyword = productSearchTextBox.Text;

            //Ckeck any vlalue have product search texbox or not
            if (keyword == "")
            {
                productNameTextBox.Text = "";
                inventoryTextBox.Text = "";
                rateTextBox.Text = "";
                qtyTextBox.Text = "";
                return;
            }

            //Search the product and display on respective textboxes
            productBLL p = pDAL.ProductForTransaction(keyword);

            //Set the value for texboxes
            productNameTextBox.Text = p.name;
            inventoryTextBox.Text = p.qty.ToString();
            rateTextBox.Text = p.rate.ToString(); 
        }


        //Add button Code
        private void addButton_Click(object sender, EventArgs e)
        {
            //Get Product name, rate and qty custemer want to buy
            String productName = productNameTextBox.Text;
            decimal rate = decimal.Parse(rateTextBox.Text);
            decimal qty = decimal.Parse(qtyTextBox.Text);

            //Fomula in total = rate * qty
            decimal total = rate * qty;

            //Display Sub Total in the Text Box
            //Get the Sub Total Value for Text Box
            decimal subTotal = decimal.Parse(subTotalTextBox.Text);
            subTotal = subTotal + total; 

            //Check the product is select or not select
            if (productName == "" )
            {
                //Desplay Error Message
                MessageBox.Show("Select the Product First. Try Again..!");
            }
            else
            {
                //Add product for data Grid viwe
                tansactionDT.Rows.Add(productName, rate, qty, total);

                //Display Sub Total in Text Box
                subTotalTextBox.Text = subTotal.ToString();

                //Show in Data Gridviwe
                addedDataGridViwe.DataSource = tansactionDT;

                //Clear the TexBoxes
                productSearchTextBox.Text = "";
                productNameTextBox.Text = "";
                inventoryTextBox.Text = "0.00";
                rateTextBox.Text = "0.00";
                qtyTextBox.Text = "";

            }

        }

        //Discount Text Box Code
        private void discountTextBox_TextChanged(object sender, EventArgs e)
        {
            //Get the Value For Discount Text Box
            String value = discountTextBox.Text;

            if (value == "")
            {
                //Display Error Message
                MessageBox.Show("Please Add Discount First");
            }
            else
            {
                //Get the Discount in Decimal Value
                decimal discount = decimal.Parse(discountTextBox.Text);

                //Get the Sub Total Value
                decimal subTotale = decimal.Parse(subTotalTextBox.Text);

                //Calculate Grand Total Based On The Discount
                decimal grandTotal = ((100 - discount) / 100) * subTotale;

                //Display the Grand Total in the Tex Box
                GrandTotalTextBox.Text = grandTotal.ToString();
            }
        }

        //Calculate Grand Total With the VAT
        //Vat Text Box Code
        private void vatTextBox_TextChanged(object sender, EventArgs e)
        {
            //Check the Grand Totale has value
            String check = GrandTotalTextBox.Text;
            if (check == "")
            {
                //Desplay Error Message First need calcualate Discount
                MessageBox.Show("Calculate the Discount and Set the Grant Total Fist.");
            }
            else
            {
                //Calculate VAT
                //Geting the VAT Present First
                decimal vat = decimal.Parse(vatTextBox.Text);

                //Get the Previus Grand Total 
                decimal previusGT = decimal.Parse(GrandTotalTextBox.Text);

                //Calculate Neew Grand Total
                decimal grandTotalWithVat = ((100 + vat) / 100) * previusGT;

                //Display new Grand Total With the VAT 
                GrandTotalTextBox.Text = grandTotalWithVat.ToString(); 


            }
        }

        //Calculate Retuern Amoun
        //Paid Amount Text Box Code
        private void paidAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            //Get the Paid amount and Grand Total
            decimal grandTotal = decimal.Parse(GrandTotalTextBox.Text);
            decimal paidAmount = decimal.Parse(paidAmountTextBox.Text);

            decimal retuernAmount = paidAmount - grandTotal;

            //Display the return amount at the text box
            rreturnAmountTextBox.Text = retuernAmount.ToString();
        }

        //Save Button Code
        private void saveButton_Click(object sender, EventArgs e)
        {
            //Get the value for Perchase Salse
            transacionBLL transaction = new transacionBLL();

            transaction.type = lblTop.Text;

            //Get hte Id for dealer or custemor here 
            //lest get name of the dealer or custemor firs
            String deCustName = nameTextBox.Text;
            DeaCustBLL dc = dcDAL.GetDeaCustIDFromName(deCustName);

            transaction.dea_cust_id = dc.id;
            transaction.grandTotal = Math.Round(decimal.Parse(GrandTotalTextBox.Text),2);
            transaction.transaction_date = DateTime.Now;
            transaction.tax = decimal.Parse(vatTextBox.Text);
            transaction.discount = decimal.Parse(discountTextBox.Text);

            //Getting Username of Loged User 
            String username = frmLogin.loggedIn; 
            userBLL u = uDAL.GetIdFromUsername(username);

            transaction.added_by = u.id;
            transaction.transactionDetails = tansactionDT;

            //Ceate Boolean Variable and set its Value False 
            bool success = false;

            //Code for Insert transaction and transaction Details
            using (TransactionScope scop = new TransactionScope())
            {
                int transactionID = -1;

                //Create a boolean Vale and Insert the Tansaction
                bool w = tDAL.Insert_Transaction(transaction, out transactionID);

                //Crreate for loop to Insert Transaction Details 
                for (int i = 0; i < tansactionDT.Rows.Count; i++)
                {
                    //Get the all details of the Product
                    transactionDetailsBLL transacionDetail = new transactionDetailsBLL();

                    //Get the product name and convert it to Id
                    String productName = tansactionDT.Rows[i][0].ToString(); 

                    productBLL p = pDAL.GetDeaProductIDFromName(productName);

                    transacionDetail.product_id = p.id;
                    transacionDetail.rate = decimal.Parse(tansactionDT.Rows[i][1].ToString());
                    transacionDetail.qty = decimal.Parse(tansactionDT.Rows[i][2].ToString());
                    transacionDetail.total = Math.Round(decimal.Parse(tansactionDT.Rows[i][3].ToString()),2);
                    transacionDetail.dea_cust_id = dc.id;
                    transacionDetail.added_date = DateTime.Now;
                    transacionDetail.added_by = u.id;

                    //Increase  or Descrease Product Quantity based on Puerchase or Sales
                    String transactionType = lblTop.Text;

                    bool x = false;
                    //Ckeck Transacttion is Perchase or Salse 
                    if (transactionType == "PURCHASE")
                    {
                        //Incrase Product
                        x = pDAL.IncraseProduct(transacionDetail.product_id, transacionDetail.qty);
                    }
                    else if(transactionType == "SALES")
                    {
                        //Descrese Product
                        x = pDAL.DescreasProduct(transacionDetail.product_id, transacionDetail.qty);
                    }

                        //Insert Tansaction Details Insite the Database 
                        bool y = tdDAL.InsertTransactionDetail(transacionDetail);
                    success = w && x && y;

                }
                
                if (success == true)
                {
                    //Transaction Complete 
                    scop.Complete();

                    //Code to Print Bill
                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "\r\n\r\nSTOCK MASTER PVT. LTD. \r\n\r\n";
                    printer.SubTitle = "Matara, Sri Lanka \r\n Phone: 041-2365411 \r\n\r\n";
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Discount: " + discountTextBox.Text + "% \r\n" + "VAT: " + vatTextBox.Text + "% \r\n" + "Grand Total: " + GrandTotalTextBox.Text + "\r\n\r\n" + "Thank you for doing Business with us.";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(addedDataGridViwe);


                    MessageBox.Show("Transaction Completed Sucessfully");

                    //Clear data gridvie and all text Field
                    addedDataGridViwe.DataSource = null;
                    addedDataGridViwe.Rows.Clear();

                    searchTextBox.Text = "";
                    nameTextBox.Text = "";
                    emailTextBox.Text = "";
                    contactTextBox.Text = "";
                    addressTextBox.Text = "";
                    productSearchTextBox.Text = "";
                    productNameTextBox.Text = "";
                    inventoryTextBox.Text = "";
                    rateTextBox.Text = "";
                    qtyTextBox.Text = "";

                    subTotalTextBox.Text = "0";
                    discountTextBox.Text = "0";
                    vatTextBox.Text = "0";
                    GrandTotalTextBox.Text = "0";
                    paidAmountTextBox.Text = "0";
                    rreturnAmountTextBox.Text = "0";
                }
                else
                {
                    //Transaction Faild
                    MessageBox.Show("Transaction Faild");
                } 
            }
        }
    }
}
