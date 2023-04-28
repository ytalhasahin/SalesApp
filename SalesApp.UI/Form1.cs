using SalesApp.DAL.Concrete;
using SalesApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesApp.UI
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
            cbProductFill();
            cbCustomerFill();
            GridFill();
		}

        private void cbCustomerFill()
        {
            cbCustomer.DisplayMember = "Name";
            cbCustomer.ValueMember = "Id";
            cbCustomer.DataSource = customerDAL.GetAll();
        }

        private void cbProductFill()
        {
            cbProduct.DisplayMember = "Name";
            cbProduct.ValueMember = "Id";
            cbProduct.DataSource = productDAL.GetAll();
        }

        CategoryDAL categoryDAL = new CategoryDAL();
        ProductDAL productDAL = new ProductDAL();
        CustomerDAL customerDAL = new CustomerDAL();
        OrderDAL orderDAL = new OrderDAL();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(isAdd)
            {
                Order order = new Order(dtp.Value,int.Parse(txtQuantity.Text));
                order.Product = productDAL.Get((int)cbProduct.SelectedValue);
                order.CustomerId = (int)cbCustomer.SelectedValue;
                order.TotalPrice = order.Product.Price*order.Quantity;

                orderDAL.Add(order);
            }
            else
            {
                Order order = orderDAL.Get(id);
                order.Product = productDAL.Get((int)cbProduct.SelectedValue);
                order.CustomerId = (int)cbCustomer.SelectedValue;
                order.OrderDate = dtp.Value;
                order.Quantity = int.Parse(txtQuantity.Text);
                order.TotalPrice = order.Product.Price * order.Quantity;
                orderDAL.Update(order);
            }
            GridFill();
            GridFill();
        }
        private void GridFill()
        {
            //Lambda
            var query = orderDAL.GetAll().Join(productDAL.GetAll(),o=>o.ProductId,p=>p.Id,(o,p)=>new
            {
                o,p
            }).Join(customerDAL.GetAll(),o=>o.o.CustomerId,c=>c.Id,(o,c)=> new
            {
                o.o.Id,
                o.p.Name,
                Ad=c.Name,
                c.Surname,
                o.o.OrderDate,
                o.o.Quantity,
                o.o.TotalPrice
            }).ToList();
            //Linq
            var query2 = (from o in orderDAL.GetAll()
                         join p in productDAL.GetAll() on o.ProductId equals p.Id
                         join c in customerDAL.GetAll() on o.CustomerId equals c.Id
                         select new
                         {
                             o.Id,
                             p.Name,
                             Ad = c.Name,
                             c.Surname,
                             o.OrderDate,
                             o.Quantity, 
                             o.TotalPrice
                         }).ToList();
            dgv.DataSource = query;
        }
        bool isAdd=true;
        int id;
        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAdd = true;
        }

        private void değiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAdd = false;
            id = (int)dgv.CurrentRow.Cells[0].Value;
            cbProduct.SelectedIndex = cbProduct.FindStringExact(dgv.CurrentRow.Cells[1].Value.ToString());
            cbCustomer.SelectedIndex = cbCustomer.FindStringExact(dgv.CurrentRow.Cells[2].Value.ToString());
            dtp.Value = (DateTime)dgv.CurrentRow.Cells[4].Value;
            txtQuantity.Text = dgv.CurrentRow.Cells[5].Value.ToString();

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = (int)dgv.CurrentRow.Cells[0].Value;
            orderDAL.Delete(id);
            GridFill();
        }
    }
}
