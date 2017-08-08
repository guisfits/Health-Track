$(document).ready(function(){
    $("#logotipo").mouseover(function(){
        $("#logotipo").animate({width: "260", height: "200"})
    })
    $("#logotipo").mouseout(function(){
        $("#logotipo").animate({width: "230", height: "170"})
    })
});