var time = new Date();
function change() {
    if (time.getDay() == 7) {
        document.getElementById("OofD").innerHTML = "Gesloten!";
    }
    else if (time.getDay() == 1 && time.getHours() < 12.5 && time.getHours() > 18) {
        document.getElementById("OofD").innerHTML = "Gesloten!";
    }
    else if (time.getDay() == 2,3,4 && time.getHours() < 8.5 || time.getHours() > 18) {
        document.getElementById("OofD").innerHTML = "Gesloten!";
    }
    else if (time.getDay() == 5 && time.getHours() < 8.5 || time.getHours() > 19.5) {
        document.getElementById("OofD").innerHTML = "Gesloten!";
    }
    else if (time.getDay() == 6 && time.getHours() < 9 || time.getHours() > 17) {
        document.getElementById("OofD").innerHTML = "Gesloten!";
    }
    else{
        document.getElementById("OofD").innerHTML = "Geopend!";
    }
}
