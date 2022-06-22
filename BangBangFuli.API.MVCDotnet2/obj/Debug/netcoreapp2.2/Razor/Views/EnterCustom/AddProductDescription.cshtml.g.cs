#pragma checksum "E:\BangbangFuli\source2\BangBangFuli.API.MVCDotnet2\Views\EnterCustom\AddProductDescription.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9dd333c1b9bc3305c8c3a9b017af2b4cbf4a1f40"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EnterCustom_AddProductDescription), @"mvc.1.0.view", @"/Views/EnterCustom/AddProductDescription.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EnterCustom/AddProductDescription.cshtml", typeof(AspNetCore.Views_EnterCustom_AddProductDescription))]
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
#line 1 "E:\BangbangFuli\source2\BangBangFuli.API.MVCDotnet2\Views\_ViewImports.cshtml"
using BangBangFuli.API.MVCDotnet2;

#line default
#line hidden
#line 2 "E:\BangbangFuli\source2\BangBangFuli.API.MVCDotnet2\Views\_ViewImports.cshtml"
using BangBangFuli.API.MVCDotnet2.Models;

#line default
#line hidden
#line 1 "E:\BangbangFuli\source2\BangBangFuli.API.MVCDotnet2\Views\EnterCustom\AddProductDescription.cshtml"
using BangBangFuli.H5.API.Core.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9dd333c1b9bc3305c8c3a9b017af2b4cbf4a1f40", @"/Views/EnterCustom/AddProductDescription.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"869bc3105167e9dd4b3ce0ee5ffc553ce1a63b36", @"/Views/_ViewImports.cshtml")]
    public class Views_EnterCustom_AddProductDescription : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductInformation>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "E:\BangbangFuli\source2\BangBangFuli.API.MVCDotnet2\Views\EnterCustom\AddProductDescription.cshtml"
  
    ViewData["Title"] = "商品描述";
    Layout = "~/BasePages/_Layout.cshtml";

#line default
#line hidden
            BeginContext(153, 1344, true);
            WriteLiteral(@"<form class=""layui-form"" method=""post"" id=""addform"">
    <div class=""layui-form-item layui-form-text"">
        <label class=""layui-form-label"">说明</label>
        <div class=""layui-input-block"">
            <textarea class=""layui-textarea layui-hide"" name=""Rem"" lay-verify=""content"" id=""Rem"" required></textarea>
        </div>
    </div>
    <div class=""layui-form-item"">
        <div class=""layui-input-inline"">
            <button class=""layui-btn"" lay-submit lay-filter=""logform"">立即提交</button>
        </div>
    </div>
</form>

<script type=""text/javascript"">
        var layer
        layui.use(['layer', 'form','layedit'], function () {
            layer = layui.layer;
            var form = layui.form;
            var layedit = layui.layedit;
            // 创建一个编辑器
            layedit.set({
                uploadImage: {
                    url: '/UploadApi/uploadImage' //接口url
                    , type: 'post' //默认post
                }
            });

            var editIndex =");
            WriteLiteral(@" layedit.build('Rem', {
                height: 370 //设置编辑器高度
            });
            form.on('submit(logform)', function (data) {
                layedit.sync(editIndex)
                data.field.Rem = layedit.getContent(editIndex);

                $.post(""/EnterCustom/SaveProductDescriptionLog?ProductId=");
            EndContext();
            BeginContext(1498, 8, false);
#line 42 "E:\BangbangFuli\source2\BangBangFuli.API.MVCDotnet2\Views\EnterCustom\AddProductDescription.cshtml"
                                                                    Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1506, 704, true);
            WriteLiteral(@""", data.field, function (res) {
                    if (res.code == 1) {
                        layer.msg('保存成功', { icon: 6 });
                        window.location = '/EnterCustom/QueryProductList';
                    } else {
                        layer.msg('保存失败', { icon: 5 });
                    }
                })
                return false;
            });
            form.verify({
                Rem: function (value, item) { //value：表单的值、item：表单的DOM对象
                    layedit.sync(editIndex);
                    if (value.length < 30) {
                        return '说明至少要50个字';
                    }
                }
            });
        })
</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductInformation> Html { get; private set; }
    }
}
#pragma warning restore 1591