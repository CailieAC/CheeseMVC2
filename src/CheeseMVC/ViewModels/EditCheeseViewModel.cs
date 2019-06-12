using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class EditCheeseViewModel: AddCheeseViewModel
    {
        public int cheeseId { get; set; }

        public void Persist(int id)
        {
            Cheese cheese = new Cheese
            {
                CheeseId = id,
                Name = this.Name,
                Description = this.Description,
                Type = this.Type,
            };
            CheeseData.Update(cheese);
        }
    }
}
