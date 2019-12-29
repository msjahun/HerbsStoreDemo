using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Services.Security;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HerbsStore.Libraries.HS.Services.TagHelpers
{
    [HtmlTargetElement("secure-content")]
    public class SecureContentTagHelper : TagHelper
    {
        private readonly IPermissionService _permissionService;

        public SecureContentTagHelper(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HtmlAttributeName("asp-require-admin")]
        public bool RequireAdministrator{ get; set; } 
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
          

             output.TagName = null;

            if (_permissionService.Authorize())
                return;


            output.SuppressOutput();


        }
    }
}
