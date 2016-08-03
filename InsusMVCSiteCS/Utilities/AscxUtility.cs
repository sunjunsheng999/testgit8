using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Compilation;
using System.Reflection;
using System.Web.UI.HtmlControls;

namespace Insus.NET.Utilities
{
    public class AscxUtility
    {
        public static HtmlString RenderControl<T>(string path)
               where T : UserControl
        {
            //Page page = new Page();
            //T control = (T)page.LoadControl(path);
            //page.Controls.Add(control);


            //2014-04-04修改如下(#24~#30)，
            Page page = new Page();
            page.EnableEventValidation = false;
            HtmlForm form = new HtmlForm();
            form.ID = "form1";
            page.Controls.Add(form);
            T control = (T)page.LoadControl(path);
            form.Controls.Add(control);

            using (StringWriter sw = new StringWriter())
            {
                HttpContext.Current.Server.Execute(page, sw, false);
                return new HtmlString(sw.ToString());
            }
        }

        public static HtmlString RenderControl<T>(string path, Dictionary<string, object> value)
              where T : UserControl
        {
            Page page = new Page();

            HtmlForm form = new HtmlForm();

            T control = (T)page.LoadControl(path);

            AscxSetValue(control, value);

            form.Controls.Add(control);
            page.Controls.Add(form);

            using (StringWriter sw = new StringWriter())
            {
                HttpContext.Current.Server.Execute(page, sw, false);
                return new HtmlString(sw.ToString());
            }
        }

        private static void AscxSetValue(UserControl uc, Dictionary<string, object> dicValue)
        {
            if (dicValue == null) return;

            foreach (KeyValuePair<string, object> kvp in dicValue)
            {
                PropertyInfo pi = uc.GetType().GetProperty(kvp.Key, BindingFlags.Public | BindingFlags.Instance);
                if (null != pi && pi.CanWrite)
                    pi.SetValue(uc, kvp.Value, null);
            }
        }

    }
}