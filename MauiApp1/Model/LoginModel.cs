using MauiApp1.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    public class LoginModel : BaseBinding
    {
        private string _nombreusuario;
        public string nombreusuario
        {
            get
            {
                return _nombreusuario;
            }
            set
            {
                SetValue(ref _nombreusuario, value);
            }
        }
        private string _contra;
        public string contra
        {
            get
            {
                return _contra;
            }
            set
            {
                SetValue(ref _contra, value);
            }
        }
    }
    
}
