var dtable;


$(document).ready(function () {
    dtable = $('#mydatatable').DataTable({



        "ajax": {

            "url": "/Admin/Product/AllProducts"
        },


        "columns": [
            { data: 'name' },
            { data: 'description' },
            { data: 'price' },
            { data: 'category.name' },

            {

                "data": "id",
                "render": function (data) {
              return
                  
                    `
< a href = "/Admin/Product/CreateUpdate?id=${data}" > create</a >


                     `
                        
                    
              
              
                  

                }
            }



        ]


    });
});