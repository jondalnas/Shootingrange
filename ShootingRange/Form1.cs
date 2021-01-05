﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShootingRange
{
	public partial class Form1 : Form {
		public byte dist, currDist;
		public Form1() {
			InitializeComponent();
			progressBar1.Maximum = 90*15;
			dist = 0;
		}

		private void button1_Click(object sender, EventArgs e) {
			currDist = dist; //Todo: currDist needs to equal readings
			progressBar1.Value = currDist*15; //Todo: This should constantly update
			//Todo: Send signal to motor, compare currDist to dist
			dist = 0;
		}

		private void btn7_Click(object sender, EventArgs e) {
			dist = (byte) (dist * 10 + 7);
			if (dist > 90) {
				dist = 90;
			}
			this.label3.Text = dist + "";
		}

		private void btn8_Click(object sender, EventArgs e) {
			dist = (byte)(dist * 10 + 8);
			if (dist > 90) {
				dist = 90;
			}
			this.label3.Text = dist + "";
		}

		private void btn9_Click(object sender, EventArgs e) {
			dist = (byte)(dist * 10 + 9);
			if (dist > 90) {
				dist = 90;
			}
			this.label3.Text = dist + "";
		}

		private void btn4_Click(object sender, EventArgs e) {
			dist = (byte)(dist * 10 + 4);
			if (dist > 90) {
				dist = 90;
			}
			this.label3.Text = dist + "";
		}

		private void btn5_Click(object sender, EventArgs e) {
			dist = (byte)(dist * 10 + 5);
			if (dist > 90) {
				dist = 90;
			}
			this.label3.Text = dist + "";
		}

		private void btn6_Click(object sender, EventArgs e) {
			dist = (byte)(dist * 10 + 6);
			if (dist > 90) {
				dist = 90;
			}
			this.label3.Text = dist + "";
		}

		private void btn3_Click(object sender, EventArgs e) {
			dist = (byte)(dist * 10 + 3);
			if (dist > 90) {
				dist = 90;
			}
			this.label3.Text = dist + "";
		}

		private void btn2_Click(object sender, EventArgs e) {
			dist = (byte)(dist * 10 + 2);
			if (dist > 90) {
				dist = 90;
			}
			this.label3.Text = dist + "";
		}

		private void btn1_Click(object sender, EventArgs e) {
			dist = (byte)(dist * 10 + 1);
			if (dist > 90) {
				dist = 90;
			}
			this.label3.Text = dist + "";
		}

		private void btn0_Click(object sender, EventArgs e) {
			dist = (byte)(dist * 10);
			if (dist > 90) {
				dist = 90;
			}
			this.label3.Text = dist + "";
		}

		private void delBtn_Click(object sender, EventArgs e) {
			dist = (byte) (dist / 10);
			this.label3.Text = dist + "";
		}

		private void label3_Click(object sender, EventArgs e) {

		}

		private void Form1_Load(object sender, EventArgs e) {

		}
	}
}
