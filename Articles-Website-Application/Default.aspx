<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Articles_Website_Application._Default" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" id="Content">
        <input runat="server" type="hidden" value="false" id="showContent" />
        
    </div>
    <script>
  $(document).ready(function () {
            if ($("#MainContent_showContent").val() == "false") {
                $(".hiddenPart").css({ "display": "none" });
                $(".visiblePart p a").attr('disabled', true);
                $(".visiblePart p a").css('background-color', "lightgrey");
            }
            else {
                $(".hiddenPart").css({ "display": "none" });
                $(".visiblePart p a").attr('disabled', false);
                $(".visiblePart p a").css('background-color', "#00b3cd");
                $(".visiblePart p a").css('color', "white");
            }

            $('#homeAnchor').addClass("border-bottom");
            balanceHeight();
        })
        function toggle(item) {
            $(item).parents(':eq(2)').find(".hiddenPart").slideDown("slow", function () {
                $(item).parents(':eq(2)').find(".hiddenPart").css({ "display": "block" });
            });
             $(item).parents(':eq(2)').find(".visiblePart").css({ "height": "auto" });
            $(item).css({ "display": "none" });
        }
        $(".visiblePart p a").hover(function () {
            this.style.backgroundColor = "#0099af";
        }, function () {
            this.style.backgroundColor = "#00b3cd";
        });

        function balanceHeight() {
            var maxHeight = 0; 
            $('.visiblePart').each(function () {
                if (this.clientHeight > maxHeight) {
                    maxHeight = this.clientHeight;
                }
            });
            maxHeight = maxHeight + 80;
            $('.visiblePart').each(function () {
                $(this).css("height", maxHeight + "px");
            });
        }
    </script>
  </asp:Content>
