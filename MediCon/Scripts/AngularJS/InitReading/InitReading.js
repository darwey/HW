app.controller('InitReadingCtrl', ['$scope', '$http', function (s, h) {
  
    s.hideTable = true;
    s.showLabResult = false;
    s.medHistLoader_modal = false;
    s.bpLoader = false;
    s.labResultLoader = false;
    s.consID = "";
    s.ir = "";

    var userTypeIDValue = document.getElementById('sessionUserTypeID').innerText;

    s.dateTosend = new Date();

     s.filterResult = function(dateFilter) {
       
         s.dateTosend = dateFilter;

        indexNo = 1;
  
        if ($.fn.DataTable.isDataTable("#labexam_tbl")) {
            $("#labexam_tbl").DataTable().clear().destroy();
        } 
        
          //............. LIST OF CLIENTS WITH VITAL SIGNS TABLE
          var tableLabList = $("#labexam_tbl").DataTable({
            "ajax": {
                "url": "../InitialReading/getIRLists?consultDate=" + moment(dateFilter).format('YYYY-MM-DD').toString(),
              "type": "POST",
              "dataSrc": "",
              "recordsTotal": 20,
              "recordsFiltered": 20,
              "deferRender": true,
            },
            "pageLength": 10,
            "searching": true,
            "language": {
              "loadingRecords":
                '<div class="sk-spinner sk-spinner-double-bounce"><div class="sk-double-bounce1"></div><div class="sk-double-bounce2"></div></div><text><i>Please wait, we are loading your data...</i></text>',
              "emptyTable":
                '<label class="text-danger">NO INFORMATION FOUND!</label>',
            },
            "processing": false,
            "columns": [
              {
                "data": null,
                render: function (data, type, row, meta) {
                  return parseInt(meta.row) + 1;
                }
              },
              {
                "data": null, render: function () {
                    return '<button class="btn-success btn btn-xs" id="viewDataRecord"> Show <i class="fa fa-external-link"></i></button>'
                }
              },
              //  {
              //      "data": null,
              //      render: function () {
              //          // Check if userTypeIDValue is 10, disable the button if true
              //          var disabled = (userTypeIDValue == 10) ? 'disabled' : '';

              //          return '<button class="btn-success btn btn-xs" id="viewDataRecord" ' + disabled + '> Show <i class="fa fa-external-link"></i></button>';
              //      }
              //  },
              {
                "data": null,
                render: function (row) {
                  return "<strong>" + row.firstName + "</strong>";
                },
              },
              {
                "data": null,
                render: function (row) {
                    return row.sex == 1 ? "M" : "F";
                },
              },
              // {
              //   "data": null,
              //   render: function (row) {
              //     var age = moment().diff(
              //       moment(row.birthdate).format("L"),
              //       "years"
              //     );
              //     return '<span class="label label-success">' + age + "</span>";
              //   },
              // },
              {
                "data": null,
                render: function (row) {
                  return row.Age;
                },
              },
              {
                "data": null,
                render: function (row) {
                  return row.docTorName;
                },
              },
              {
                "data": null,
                 render: function (row) {
                     return row.doneTest == "1" ? '<span class="label label-primary"> DONE </span>' : row.doneTest == "2" ? '<span class="label label-warning"> NOT COMPLETE </span>' : '<span class="label label-danger"> NOT YET UPLOADED </span>' ;
                 },
               },
               {
                "data": null,
                render: function (row) {
                    return row.doneUpload == "1" ? '<span class="label label-primary"> DONE </span>' : row.doneUpload == "2" ? '<span class="label label-warning"> NOT COMPLETE </span>' : '<span class="label label-danger"> NOT YET UPLOADED </span>' ;
                },
               },
              {
                "data": null,
                render: function (row) {
                  return row.initReading == null 
                  ? '<span class="label label-danger">PENDING</span>' 
                  : row.initReading == 1 
                  ? '<span class="label label-primary">NORMAL</span>' 
                  : '<span class="label label-warning">ABNORMAL</span>';
              
                },
              },
              {
                "data": null,
                render: function (row) {
                    return row.remarks ;
                },
              },
            ],
            order: [[0, "asc"]],
          });

           // Disable or Enable the Print Button Based on DataTable Rows
            tableLabList.on('draw', function() {
              var dataCount = tableLabList.rows().count();
              if (dataCount === 0) {
                  $('#printButton').attr('disabled', true);  // Disable Print button if no data
              } else {
                  $('#printButton').attr('disabled', false); // Enable Print button if data exists
              }
          });
  
          $("#labexam_tbl tbody").off("click");
  
          $("#labexam_tbl tbody").on("click", "#viewDataRecord", function () {
              var rec = tableLabList.row($(this).parents('tr')).data();
              console.log(rec);
              s.ir = rec;
              if (rec.initReading !== null) s.ir.initReading = rec.initReading.toString();
              s.hideTable = false;
              s.consID = rec.consultID;
              s.showLabResult = true;
              s.labHistoryList = [];
              s.patientName = "";
              s.patientName = rec.firstName;
              s.$apply();
              h.post('../InitialReading/getLabHistory', { qrCode: rec.qrCode, consultDate: moment(s.dateTosend).format('YYYY-MM-DD') }).then(function (d) {
                  if (d.data.status == 'error') {
                      swal({
                          title: "ERROR",
                          text: d.data.msg,
                          type: "error"
                      });
                  }

                  else {
                      angular.forEach(d.data, function (value) {
                          value.dateTested = moment(value.dateTested).format('lll');
                      });

                      s.labHistoryList = d.data;
                  }
                  s.bpLoader = false;
              });
             
          });
      };


    s.back = function() {
        s.hideTable = true;
        s.showLabResult = false;
        s.consID = "";
    }

    s.viewLabResult = function (data) 
    {
        viewingLabData = angular.copy(data);
        s.modalTitle = data.labTestName;
        $('#modalLabResult').modal('show');
        
        retrievingFile(data);
    };

    function retrievingFile(data) { 
        s.imgCount = 0;
        s.currentImgIndex = 0;
        s.ImgCollection = [];
        s.displayFileName = '';
        s.labResultLoader = true;
        h.post('../LaboratoryResult/getScannedList', { qrCode: data.qrCode, labID: data.labID }).then(function (d) {
            s.imgCount = d.data.length;
          
            if(s.imgCount > 0) {
                for (var i = 0; i < d.data.length; i++) {
                    s.ImgCollection.push({ FileName: d.data[i].Name, Type: d.data[i].Type, Path: 'getScannedLabResult?qrCode=' + data.qrCode + '&fileName=' + d.data[i].Name });
                }
            
                s.displayFileName = d.data[0].Name;
                //document.getElementById('labResult').innerHTML = '<img id="APreview" style="text-align: center;height:100%; width:100%;" src="getScannedLabResult?qrCode=' + data.qrCode + '&fileName=' + d.data[0] + '" height="60%" width="100%" />';
                document.getElementById('labResult').innerHTML = '<embed id="APreview" style="text-align: center;height:100%; width:100%;" src="getScannedLabResult?qrCode=' + data.qrCode + '&fileName=' + d.data[0].Name + '" height="100%" width="100%">'; 
                //document.getElementById('APreview').setAttribute("type", d.data[0].Type == ".pdf" ? "application/pdf" : "image/png");
            }

            else {
                $('#modalLabResult').modal('hide');
                s.getLabtest(data.qrCode);
            }
            
            s.labResultLoader = false;
        });
    };

    s.irBtnSave = function(a) {
      var irData = {};
      irData = a;
      irData.consultID = s.consID;
  
      h.post('../InitialReading/saveReading', irData).then(function (d) {
          if (d.data.status == 'success') {
              swal({
                  title: "SUCCESS",
                  text: d.data.msg,
                  type: "success"
              });
  
              s.ir = {}; // Clear the form after saving
  
              // Find the row by consultID (or any unique identifier)
              var table = $('#labexam_tbl').DataTable();
  
              // Use table.rows().every() to loop through each row and find the correct one
              table.rows().every(function(rowIdx, tableLoop, rowLoop) {
                  var data = this.data(); // Get row data
                  
                  if (data.consultID === irData.consultID) { // Match the row using consultID
                      // Update the value of `initReading` to the new value (e.g., NORMAL, ABNORMAL, etc.)
                      data.initReading = irData.initReading;
  
                      // Update the row data and redraw without a full table refresh
                      this.data(data).draw(false); // 'this' refers to the current row
                  }
              });
          } else {
              swal({
                  title: "ERROR",
                  text: d.data.msg,
                  type: "error"
              });
          }
      });
  };

  s.clearFilter = function() {
    // Clear the date input model
    s.FilterDate = null;

    // Clear and destroy the existing DataTable if it exists
    if ($.fn.DataTable.isDataTable("#labexam_tbl")) {
        $("#labexam_tbl").DataTable().clear().destroy();
    }

    // Reset the Print button to disabled state
    $('#printButton').attr('disabled', true);
};



  s.printResult = function(datetoPrint) {
   // moment(datetoPrint).format('YYYY-MM-DD').toString()
   h.post('../Print/printReading?consultDate=' + moment(datetoPrint).format('YYYY-MM-DD').toString()).then(function (d) {
       window.open("../Report/MediConRpt.aspx?type=initialReading");
    });

  }
  

  
}]);