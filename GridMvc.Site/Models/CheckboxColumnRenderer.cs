using System.Web.Mvc;
using System.Web.Mvc.Html;
using GridMvc.Columns;

namespace GridMvc.Site.Models
{
    public class CheckboxColumnRenderer : GridHeaderRenderer
    {
        private readonly HtmlHelper _helper;

        public CheckboxColumnRenderer(HtmlHelper helper)
        {
            _helper = helper;
        }

        protected override string RenderAdditionalContent(IGridColumn column)
        {
            return _helper.CheckBox("check-all", false, new { @class = "check-all" }).ToHtmlString();
        }
    }
}