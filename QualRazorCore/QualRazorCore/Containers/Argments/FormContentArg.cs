using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Containers.Argments
{
    public class FormContentArg<TModel>
    {
        public EditForm EditForms { get; }

        public TModel Model { get; }

        public FormContentArg(EditForm editForms, TModel model)
        {
            EditForms = editForms;
            Model = model;
        }
    }
}
