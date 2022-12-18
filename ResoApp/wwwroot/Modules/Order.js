let Order = {
   lstorders:[],
    GetOrders: function ()
    {      
        $.ajax(
            {               
                url: "https://localhost:7074/api/Resturant/GetOrders",
                type: 'get',
                success: function (Data) {
                    this.lstorders = Object.entries(Data);
                    Order.DrawOrders(this.lstorders);
                    
                },
                error: function () {
                    console("Fail");
                }
            });

    },      
    DrawOrders:function (Data) {
        for (var i = 0; i < Data.length; i++) {
            var TableBody = document.getElementById("OrdersTableBody");
            TableBody.innerHTML += "<tr><td>" + Data[i][1].id + "</td><td>" + Data[i][1].invoiceDate +
                "</td><td>" + Data[i][1].invoicetotal +
                "</td><td><div><button onclick='Order.ShowOrderDetails()' class='btn btn-outline-info' >Show More Details</button></div></td></tr>";  
        }
                                                                                                                    
    },  
    ShowOrderDetails: function (Data,id) {       
        var modal = new tingle.modal({
            footer: true,
            stickyFooter: false,
            closeMethods: ['overlay', 'button', 'escape'],
            closeLabel: "Close",
            cssClass: ['custom-class-1', 'custom-class-2'],
            onOpen: function () {
                console.log('modal open');
            },
            onClose: function () {
                console.log('modal closed');
            },
            beforeClose: function () {
                // here's goes some logic
                // e.g. save content before closing the modal
                return true; // close the modal
                return false; // nothing happens
            }
        });

        // set content
        modal.setContent('<table class="table"><thead><th>ItemId</th><th>ItemName</th></thead><tbody><tr><td>8</td><td>mahmoud</td></tr></tbody></table>');
           

        // add a button
        modal.addFooterBtn('Ok', 'tingle-btn tingle-btn--primary', function () {
            // here goes some logic
            modal.close();
        });

        // add another button
        modal.addFooterBtn('Close', 'tingle-btn tingle-btn--danger', function () {
            // here goes some logic
            modal.close();
        });

        // open modal
        modal.open();



    }
    
}
