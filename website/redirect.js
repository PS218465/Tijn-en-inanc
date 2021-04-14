function redirect() {
    for (var i = 1; i < 12; i++) {
        var checkbox = document.getElementById("checkbox" + i);
        if (checkbox.checked == true) {
            location.replace("/website/index.php");
            return;
        }
    }
}