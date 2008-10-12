using System.Web.UI.WebControls;
namespace Validadores
{
    public class ValidadorTelefone : RegularExpressionValidator
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            this.ValidationExpression = @"\d{2}\s\d{8}$";
        }
    }
}