﻿using EShope.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EShope.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetailsPage : PageBase
	{
		public ProductDetailsPage ()
		{
			InitializeComponent ();
		}
	}
}