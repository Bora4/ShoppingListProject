#pragma checksum "C:\Users\borat\source\repos\ShoppingList\Views\Home\Market.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af3581551a332049517ab9031d4d60a718fcf001"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Market), @"mvc.1.0.view", @"/Views/Home/Market.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\borat\source\repos\ShoppingList\Views\_ViewImports.cshtml"
using ShoppingList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\borat\source\repos\ShoppingList\Views\_ViewImports.cshtml"
using ShoppingList.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\borat\source\repos\ShoppingList\Views\Home\Market.cshtml"
using ShoppingListAPI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af3581551a332049517ab9031d4d60a718fcf001", @"/Views/Home/Market.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b59c396acab2a2de2cff75dab5f08dfd6ef368f3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Market : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShoppingList>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <html>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af3581551a332049517ab9031d4d60a718fcf0013956", async() => {
                WriteLiteral("\r\n            \r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af3581551a332049517ab9031d4d60a718fcf0014242", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            \r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        \r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af3581551a332049517ab9031d4d60a718fcf0016089", async() => {
                WriteLiteral("\r\n            <div class=\"mydiv\">\r\n            <div class=\"leftpanel\">\r\n            \r\n                <h4 style = \"text-align: center\">");
#nullable restore
#line 15 "C:\Users\borat\source\repos\ShoppingList\Views\Home\Market.cshtml"
                                            Write(Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n                <ul id = \"final-list\"></ul>\r\n                ");
#nullable restore
#line 17 "C:\Users\borat\source\repos\ShoppingList\Views\Home\Market.cshtml"
           Write(Html.ActionLink("Done", "Index"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n            </div>\r\n\r\n            <div class=\"middlepanel\">\r\n                <h4 style=\"text-align: center\">You are now at the supermarket</h4>\r\n            </div>\r\n\r\n            <div class=\"rightpanel\">\r\n                <h2>");
#nullable restore
#line 26 "C:\Users\borat\source\repos\ShoppingList\Views\Home\Market.cshtml"
               Write(CurrentUser.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n                <h3>");
#nullable restore
#line 27 "C:\Users\borat\source\repos\ShoppingList\Views\Home\Market.cshtml"
               Write(CurrentUser.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                <h4>");
#nullable restore
#line 28 "C:\Users\borat\source\repos\ShoppingList\Views\Home\Market.cshtml"
               Write(CurrentUser.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n                ");
#nullable restore
#line 29 "C:\Users\borat\source\repos\ShoppingList\Views\Home\Market.cshtml"
           Write(Html.ActionLink("My Shopping Lists", "MyShoppingLists"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>      \r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </html>

    <style>

        body {
            margin:0;
            height: 100%;
        }

        ul{
            list-style: none;
            padding-left: 0;
        }

        #searchbar{
            display: none;
        }

        input[type=submit] {
            border: none;
            border-radius: 8px;
            color: white;
            background-color: #007bff;
        }

        .removeButton{
            border: none;
            border-radius: 8px;
            color: white;
            background-color: red;
        }

        .searchButton{
            border: none;
            border-radius: 8px;
            color: white;
            background-color: #05e31e;
            display: none;
        }

        .addButton {
            margin-top: 5px;
            border: none;
            border-radius: 8px;
            color: white;
            background-color: #16a3f5;
        }        

        input[type=text]{
            bor");
            WriteLiteral(@"der: none;
            border-bottom: 1px solid black;
        }

        input[type=text]:focus{
            outline:none;
            border-bottom: 1px solid black
        }

        input[type=number]::-webkit-inner-spin-button, 
        input[type=number]::-webkit-outer-spin-button { 
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            margin: 0; 
        }

        .mydiv {

            position: absolute;
            top: 56px;
            left: 0;
            right: 0;
            bottom: 0;
            height: 100%;
            
        }

        .leftpanel{
            border-right: 1px solid black;
            float: left;
            width: 20%;
            height: 100%;
            box-shadow: 1px 10px 15px black;
            text-align: center;
        }

        #cartname {
            display: block;
            margin: 0 auto;
            margin-top: 30px;
            text-align: center;
");
            WriteLiteral(@"        }

        .leftpanel input[type=submit]{
            display: block;
            margin: 0 auto;
            margin-top: 10px;
        }

        .middlepanel{
            
            float:left;
            width: 60%;
            height: 100%;
            padding: 25px;
        }


        .categoryname{
            color: #dbbd6b;
            font-size: 30px;
            font-weight: bold;
            background: none;
            background-color: #ffffeb;
            border: none;
            padding: 0;
        }

        .itemname{
            background: none;
            border: none;
            padding: 0;
            margin-top: 10px;
        }

        .itemnamexr{
            background: none;
            border: none;
            padding: 0;
            margin-top: 10px;
            text-decoration: line-through;
        }

        .quantity{
            -moz-appearance: textfield;
            display: inline;
            width: 20px;
    ");
            WriteLiteral(@"        margin-right: 5px;
            margin-left: 5px;
            outline:none;
            border: none;
        }

        .quantity:focus{
            border: none;
        }

        

        .rightpanel{
            border-left: 1px solid black;
            float: right;
            width: 20%;
            text-align: center;
            height: 100%;
            box-shadow: 1px 10px 15px black;
        }


    </style>



");
#nullable restore
#line 196 "C:\Users\borat\source\repos\ShoppingList\Views\Home\Market.cshtml"
              
            var id = @Model.Id;
            

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n\r\n        $(document).ready(function getList()\r\n                {\r\n                    $.ajax\r\n                    (\r\n                        {\r\n                            url: \"http://localhost:5997/api/ShoppingListDetails/\" +");
#nullable restore
#line 206 "C:\Users\borat\source\repos\ShoppingList\Views\Home\Market.cshtml"
                                                                              Write(id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@",
                            type: ""GET"",
                            success: function(data)
                            {
                                var str = JSON.stringify(data)
                                console.log(""data: "" + str);
                                var html = """"
                                $.each(data, function(key, value)
                                {
                                    html += ""<li ><p id='cartitem""+ value.itemId +""' class = 'itemname'>""+ value.item.name +"" x ""+ value.quantity + ""<input type = 'checkbox' style= 'margin-left: 5px;' id='checkbox"" + value.itemId +""' onclick = 'crossName(""+ value.itemId +"")'/></p></li>""
                                })
                                $(""#final-list"").html(html);
                        
                            }
                        }
                    )
                })
        
        function crossName(id){
            var cbox = document.getElementById(""checkbox"" + id)");
            WriteLiteral(@"
            var item = document.getElementById(""cartitem"" + id)
            if (cbox.checked == false){
                item.className = ""itemname""
            } else {
                item.className = ""itemnamexr""
            }

        }
                
    </script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShoppingList> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591