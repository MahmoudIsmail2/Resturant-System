var Invoice = {
    lstitems: [],
    totalinvoice: 0,
    AddItemToInvoice: function (ItemId) {
        oitem = {};
        var invoiceItem = this.GetRecord(ItemId)
        if (Invoice.CheckItemExists(ItemId) == true) {
            for (var i = 0; i < this.lstitems.length; i++) {
                if (this.lstitems[i].Id === ItemId) {
                    this.lstitems[i].Qty++;
                    this.lstitems[i].Total = this.lstitems[i].Price * this.lstitems[i].Qty;
                }
            }
            this.DrawInvoicerecord(this.lstitems);

        }
        else {
            oitem.Id = invoiceItem.id;
            oitem.Name = invoiceItem.itemname,
                oitem.Price = invoiceItem.itemprice,
                oitem.Qty = 1,
                oitem.Total = oitem.Price * oitem.Qty;
            this.lstitems.push(oitem);
            this.DrawInvoicerecord(this.lstitems);

        }


    },
    GetRecord: function (itemid) {
        for (var i = 0; i < data.length; i++) {
            if (data[i].id === itemid) {
                return data[i];
            }
        }
    },
    DrawInvoicerecord: function (items) {
        console.log(this.lstitems);
        var body = document.getElementById("tablebody");
        body.innerHTML = "";
        //var Totalinvoice = document.getElementById("invoicetotal");
        for (var i = 0; i < items.length; i++) {
            body.innerHTML += "<tr><td>" + items[i].Name + "</td > <td>"
                + items[i].Price + "</td><td> " + items[i].Qty +
                "</td><td>" + items[i].Total +
                "</td><td><button  class='btn btn-danger' onclick='Invoice.DeleteRecord(" + items[i].Id + ")'>Delete</button></td ></tr > "
        }
        var result = document.getElementById("invoicetotal");
        result.value = 0;
        for (var i = 0; i < this.lstitems.length; i++) {

            result.value = parseInt(result.value) + parseInt(this.lstitems[i].Total);

        }
        this.totalinvoice = result.value;

    },

    CheckItemExists: function (id) {
        for (var i = 0; i < this.lstitems.length; i++) {
            if (this.lstitems[i].Id === id) {

                return true;
            }
        }
        return false;
    },
    DeleteRecord: function (recordid) {


        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                for (var i = 0; i < this.lstitems.length; i++) {
                    if (this.lstitems[i].Id == recordid) {
                        this.lstitems.splice(i, 1);
                        Invoice.DrawInvoicerecord(this.lstitems);
                    }
                }

                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            }
        })



      
    },
    Save: function () {
        let order = {
            Count: this.totalinvoice,
            Items: JSON.stringify(this.lstitems),           
        }
        console.log(JSON.stringify(order));
        $.ajax({
            url: "https://localhost:7074/api/Resturant/Postorder",
            data: JSON.stringify(order),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                alert("Done");
            },
            error: function () {
               
            },
            type: 'POST'
        });
        alert("Invoice Saved");
        this.lstitems = [];
       Invoice. DrawInvoicerecord(this.lstitems);
    }

}


