#pragma checksum "C:\Users\felip\Desktop\Odisseia-Web\Odisseia-Web\Odisseia-Web\Views\Missao\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42a96068ab8347dc92e5f0a475f1b471ec72a328"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Missao_Edit), @"mvc.1.0.view", @"/Views/Missao/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Missao/Edit.cshtml", typeof(AspNetCore.Views_Missao_Edit))]
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
#line 1 "C:\Users\felip\Desktop\Odisseia-Web\Odisseia-Web\Odisseia-Web\Views\_ViewImports.cshtml"
using Odisseia_Web;

#line default
#line hidden
#line 2 "C:\Users\felip\Desktop\Odisseia-Web\Odisseia-Web\Odisseia-Web\Views\_ViewImports.cshtml"
using Odisseia_Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42a96068ab8347dc92e5f0a475f1b471ec72a328", @"/Views/Missao/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ea73377fb6dd9b715e6671399f498760c06a6aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Missao_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/action_page.php"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 35, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            EndContext();
            BeginContext(35, 1012, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "956530c23be94a7fb5892d308e5a0f50", async() => {
                BeginContext(41, 999, true);
                WriteLiteral(@"
    <title>Bootstrap Example</title>
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <!--
        <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"" integrity=""sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"" crossorigin=""anonymous"">
        <script src=""https://code.jquery.com/jquery-3.3.1.slim.min.js"" integrity=""sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"" crossorigin=""anonymous""></script>
        <script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"" integrity=""sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1"" crossorigin=""anonymous""></script>
        <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"" integrity=""sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM"" crossorigin=""anonymous""></script>
    -->
");
                EndContext();
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
            EndContext();
            BeginContext(1047, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1049, 7930, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1bb11635f8e74f3380240a8394196b43", async() => {
                BeginContext(1055, 66, true);
                WriteLiteral("\r\n\r\n    <div class=\"container\">\r\n        <h2>Missão</h2>\r\n        ");
                EndContext();
                BeginContext(1121, 913, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccfd125918004a97bf090e2c6635829a", async() => {
                    BeginContext(1153, 874, true);
                    WriteLiteral(@"
            <div class=""form-group"">
                <label for=""txtTitulo"">Titulo:</label>
                <input type=""text"" class=""form-control"" id=""txtTitulo"" name=""text"">
            </div>
            <div class=""form-group"">
                <label for=""txaDescricao"">Descrição:</label>
                <div class=""md-form"">
                    <textarea style=""resize: none; overflow-x: hidden;"" class=""form-control"" id=""txaDescricao"" rows=""5"" cols=""50"" maxlength=""1000"" placeholder=""Fale sobre a missão, liste materais de referência para os alunos, etc...""></textarea>
                </div>
            </div>
            <div class=""form-group"">
                <label for=""datePrazo"">Prazo:</label>
                <input type=""date"" class=""form-control"" id=""datePrazo"" placeholder=""Enter password"" name=""txaDescricao"">
            </div>
        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2034, 6938, true);
                WriteLiteral(@"
        <div class=""container"">
            <h2>Questões</h2>
            <p>Pesquisar por palavras:</p>
            <input class=""form-control"" id=""txtPesquisaQuestao"" type=""text"" placeholder=""Palavra..."">
            <br>
            <!--listar questões-->
        </div>
    </div>

    <!-- Modal -->
    <div class=""modal fade"" id=""modalQuestao"" role=""dialog"">
        <div class=""modal-dialog modal-lg"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <div class=""col"">

                        <div class=""row d-flex flex-nowrap flex-row justify-content-between"">
                            <h4 class=""modal-title"">Questão [N]</h4>
                            <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                        </div>

                        <div class=""row"">
                            <h5 class=""w-100"">Tag:</h5>
                            <p class=""w-100"">Pesquisar por palavras:</p>");
                WriteLiteral(@"
                            <input class=""form-control"" id=""txtPesquisaTag"" type=""text"" placeholder=""Palavra..."">
                        </div>

                        <div style=""overflow: auto;"" class=""d-flex flex-nowrap flex-row justify-content-start row"" id=""tagList"">

                            <div style=""min-width: max-content;"" class=""d-flex flex-nowrap flex-row bd-highlight card text-white bg-info m-2 p-1""><input type=""checkbox"" class=""ckxTag m-2"" value=""Tag1"">NomeTag1</div>
                            <div style=""min-width: max-content;"" class=""d-flex flex-nowrap flex-row bd-highlight card text-white bg-info m-2 p-1""><input type=""checkbox"" class=""ckxTag m-2"" value=""Tag2"">NomeTag2</div>
                            <div style=""min-width: max-content;"" class=""d-flex flex-nowrap flex-row bd-highlight card text-white bg-info m-2 p-1""><input type=""checkbox"" class=""ckxTag m-2"" value=""Tag3"">NomeTag3</div>
                            <div style=""min-width: max-content;"" class=""d-flex flex-nowrap");
                WriteLiteral(@" flex-row bd-highlight card text-white bg-info m-2 p-1""><input type=""checkbox"" class=""ckxTag m-2"" value=""Tag4"">NomeTag4</div>
                            <div style=""min-width: max-content;"" class=""d-flex flex-nowrap flex-row bd-highlight card text-white bg-info m-2 p-1""><input type=""checkbox"" class=""ckxTag m-2"" value=""Tag5"">NomeTag5</div>
                            <div style=""min-width: max-content;"" class=""d-flex flex-nowrap flex-row bd-highlight card text-white bg-info m-2 p-1""><input type=""checkbox"" class=""ckxTag m-2"" value=""Tag6"">NomeTag6</div>
                            <div style=""min-width: max-content;"" class=""d-flex flex-nowrap flex-row bd-highlight card text-white bg-info m-2 p-1""><input type=""checkbox"" class=""ckxTag m-2"" value=""Tag7"">NomeTag7</div>
                            <div style=""min-width: max-content;"" class=""d-flex flex-nowrap flex-row bd-highlight card text-white bg-info m-2 p-1""><input type=""checkbox"" class=""ckxTag m-2"" value=""Tag8"">NomeTag8</div>
                            <");
                WriteLiteral(@"div style=""min-width: max-content;"" class=""d-flex flex-nowrap flex-row bd-highlight card text-white bg-info m-2 p-1""><input type=""checkbox"" class=""ckxTag m-2"" value=""Tag9"">NomeTag9</div>
                            <div style=""min-width: max-content;"" class=""d-flex flex-nowrap flex-row bd-highlight card text-white bg-info m-2 p-1""><input type=""checkbox"" class=""ckxTag m-2"" value=""Tag10"" checked>NomeTag10</div>

                        </div>
                    </div>
                </div>
                <div class=""modal-body"">
                    <label for=""txaEnunciadoQuestao"">Enunciado:</label>
                    <div class=""md-form"">
                        <textarea style=""resize: none; overflow-x: hidden;"" class=""form-control"" id=""txaEnunciadoQuestao"" rows=""5"" cols=""50"" maxlength=""1000""></textarea>

                    </div>

                    <hr>


                    <table class=""table table-bordered table-striped"">
                        <thead>
                           ");
                WriteLiteral(@" <tr>
                                <th>Correto</th>
                                <th>Resposta</th>
                            </tr>
                        </thead>
                        <tbody id=""tblAlternativas"">

                            <tr>
                                <td><input type=""radio"" name=""alternariva"" id=""alternativa1"" value=""1""></td>
                                <td><input type=""text"" id=""alternativa1"" class=""form-control w-100"" value=""resposta1""></td>
                            </tr>

                            <tr>
                                <td><input type=""radio"" name=""alternariva"" id=""alternativa2"" value=""1""></td>
                                <td><input type=""text"" id=""alternativa1"" class=""form-control w-100"" value=""resposta2""></td>
                            </tr>

                            <tr>
                                <td><input type=""radio"" name=""alternariva"" id=""alternativa3"" value=""1""></td>
                                <td");
                WriteLiteral(@"><input type=""text"" id=""alternativa1"" class=""form-control w-100"" value=""resposta3""></td>
                            </tr>

                        </tbody>
                    </table>

                    <button id=""btnAddAlternativa"" type=""button"" class=""btn btn-success"">Adicionar Alternativa</button>

                </div>
                <div class=""modal-footer"">
                    <!--Mandar comando de edição aqui-->
                    <button id=""btnSalvarQuestao"" type=""button"" class=""btn btn-success"" data-dismiss=""modal"">Salvar</button>
                    <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    <script>
            $(document).ready(function(){

              $("".btnStatus"").click(function(){
                  $(""#idMissãoStatus"").val(""#""+this.id);
              });

              $(""#btnMudarStatus"").click(function() {
                  var id = $(""#idM");
                WriteLiteral(@"issãoStatus"").val();
                if($(id).hasClass(""btn-success"")){
                    $(id).removeClass(""btn-success"");
                    $(id).addClass(""btn-danger"");
                    $(id).val(""Recuado"");
                }
                else{
                    $(id).removeClass(""btn-danger"");
                    $(id).addClass(""btn-success"");
                    $(id).val(""Lançado"");
                }
              });

              $(""#txtPesquisaQuestao"").on(""keyup"", function() {
                var value = $(this).val().toLowerCase();
                $(""#tblMissoes tr"").filter(function() {
                  $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
              });

            });
    </script>

");
                EndContext();
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
            EndContext();
            BeginContext(8979, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591