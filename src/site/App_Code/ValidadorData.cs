using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
namespace Validadores
{

    public class ValidadorData : CustomValidator
    {

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.ServerValidate += new ServerValidateEventHandler(Validate);
        }
        private void Validate(object sender, ServerValidateEventArgs e)
        {
            DateTime date;
            e.IsValid = DateTime.TryParse(e.Value, out date);
        }

    }
}