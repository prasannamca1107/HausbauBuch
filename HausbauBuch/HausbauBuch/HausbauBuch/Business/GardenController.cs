﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HausbauBuch.Classes;
using HausbauBuch.Views;

namespace HausbauBuch.Business
{
    public class GardenController : EntityController<GardenIdeas>
    {
        public GardenController() : base(App.SqlConnection)
        {
            App.SqlConnection.CreateTableAsync<GardenIdeas>();
        }
    }
}
