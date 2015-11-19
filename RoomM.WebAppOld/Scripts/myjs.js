function OnBegin() {
    $("#divMsg").append("<h3>Beginning Ajax request.</h3>");
}
function OnComplete() {
    $("#divMsg").append("<h3>Completing Ajax request.</h3>");
}
function OnSuccess() {
    $("#divMsg").append("<h3>Ajax request successful.</h3>");
}
function OnFailure() {
    $("#divMsg").append("<h3>Ajax request failed.</h3>");
}