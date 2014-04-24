using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Folferine.Website.Models
{
    public class PlayerScoreViewModel
    {
        public string UserName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Score must be 1 or greater.")]
        public int Score { get; set; }
    }
}