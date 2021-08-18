﻿function getSchedule(id) {
    var nameSchedule = "#schedule" + id;
    $.ajax({
        url: '/Film/getSchedule',
        type: "post",
        data: {
            id: id
        },
        success: function (data) {
            if (data.status == "OK") {
                $(nameSchedule).html(data.data);
            } else if (data.status == "ERROR") {
                $('#resultError').html(data.msg);
            }

            console.log(data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}
function getShowtime(id) {
    var nameShowtime = "#showtime" + id;
    var nameSchedule = "#schedule" + id;
    var idSchedule = $(nameSchedule).val();
    $.ajax({
        url: '/Film/getShowtime',
        type: "post",
        data: {
            id: idSchedule
        },
        success: function (data) {
            $(nameShowtime).html(data.data);
            console.log(data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}
function getRoom(id) {
    var nameRoom = "#room" + id;
    $.ajax({
        url: '/Film/getRoom',
        type: "post",
        success: function (data) {
            $(nameRoom).html(data.data);
            console.log(data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}
function getSeat(id) {
    var nameShowtime = "#showtime" + id;
    var nameSchedule = "#schedule" + id;
    var nameRoom = "#room" + id;
    var nameSeat = "#seat" + id;
    $.ajax({
        url: '/Film/getSeat',
        type: "post",
        data: {
            roomId: $(nameRoom).val(),
            showtimeId: $(nameShowtime).val(),
            filmId: id,
            scheduleId: $(nameSchedule).val()
        },
        success: function (data) {
            $(nameSeat).html(data.data);
            console.log(data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}
function bookingTicket(id) {
    var nameShowtime = "#showtime" + id;
    var nameSchedule = "#schedule" + id;
    var nameRoom = "#room" + id;
    var nameSeat = "#seat" + id;
    var nameError = "#resultError" + id;
    var nameModel = "btn-close" + id;
    var idSeat = $(nameSeat).val();
    var idRoom = $(nameRoom).val();
    var idSchedule = $(nameSchedule).val();
    var idShowtime = $(nameShowtime).val();
    if (idSeat.length == 0 || idRoom == '' || idSchedule == '' || idShowtime == '' || idSchedule == 0 || idShowtime == 0 || idRoom == 0) {
        $(nameError).html("❌ Cần chọn đầy đủ thông tin");
    } else {
        $.ajax({
            url: '/Film/bookingTicket',
            type: "post",
            data: {

                film_id: id,
                schedule_id: idSchedule,
                showtime_id: idShowtime,
                room_id: idRoom,
                seat_id: idSeat
            },
            success: function (data) {

                var tongtien = 0;        
                var dataHTML = '';
                if (data.status == "ERROR") {
                    $(nameError).html("❌ Bạn cần phải đăng nhập !");
                } else {
                    dataHTML += `<p ><span style="font-weight:bold">Tên phim : </span>` + data.data1[0].nameFilm + `</p><br>
										<p ><span style="font-weight:bold">Lịch chiếu : </span>`+ data.data1[0].schedulename+ `</p><br>
										<p ><span style="font-weight:bold">Suất chiếu : </span>`+ data.data1[0].showtimeName + `</p><br>
										<p ><span style="font-weight:bold">Phòng chiếu : </span>`+ data.data1[0].roomName + `</p><br>`
                    dataHTML += `<span style="font-weight:bold">Ghế : `
                    for (var i = 0; i < data.data2.length; i++) {
                        dataHTML += `<span>` + data.data2[i] + " " + `</span>`
                        tongtien = tongtien + 3;
                    }
                    dataHTML += `<p style="margin-top: 25px" ><span style="font-weight:bold">Tổng tiền : </span>` + tongtien + `$</p><br>`
                    
                    $('#result').html(dataHTML);
                    $('#linkqr').html(data.data);
                    $('#sessionId').html(data.data3.Id);
                    $(nameError).html("");
                    document.getElementById(nameModel).click();
                    $(document).ready(function () {
                        $('#exampleModaltest').modal('show');
                    });
                }
            },
            error: function (error) {
                console.log(error);
            }
        })
    }

}
function closeModel() {
    $('#exampleModaltest').modal('hide');
}
