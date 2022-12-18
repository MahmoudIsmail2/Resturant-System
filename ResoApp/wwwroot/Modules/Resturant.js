let data;
function GetItemsByCategoryId(id) {
   
    $.ajax(
        {
            url: "/api/Resturant/GetCategoryById/" + id,
            type: 'get',
            
            success: function (Data) {
                data = Data;
               
                DrawItems(Data);
               
            },
            error: function () {
                console("Fail");
            }
        });
}

function DrawItems(Data) {
    
    var itemshtml = document.getElementById("items");
    itemshtml.innerHTML = "";
    for (var i = 0; i < Data.length; i++) {

        itemshtml.innerHTML+= "<button id='" + Data[i].id + "' class='btn btn-group' onclick=' Invoice.AddItemToInvoice(" + Data[i].id + ");' style='width:30%;height:110px;background-color:burlywood" +
            ";margin-left:10px;margin-bottom:10px'><div class='col-8'><h4>"
            + Data[i].itemname + "</h4></div><div><h></br> </br>" + Data[i].itemprice + "$" + "</h4></div></button>"
        
    }

  


   
}
