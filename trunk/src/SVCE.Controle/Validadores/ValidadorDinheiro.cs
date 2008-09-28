using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace SVCE.Controle.Validadores
{
    public class ValidadorDinheiro : CustomValidator
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.ServerValidate+=new ServerValidateEventHandler(Validate);

        }
        private void Validate(object sender, ServerValidateEventArgs e)
        {
            decimal d;
            e.IsValid = decimal.TryParse(e.Value, out d);
        }
    }
}
