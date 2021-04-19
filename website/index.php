<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="images/logo20x20.png" />
    <link rel="stylesheet" href="css/MainStylesheet.css">
    <link rel="stylesheet" href="css/navbar.css">
    <link rel="stylesheet" href="css/xtra.css">
    <script src="redirect.js"></script>
    <title>Home</title>
</head>

<body style="height: max-content;">
    <div class="container">
        <div class="logo">
            <img id="logo" src="images/logo.png">
            <h1 class="txtcenter" id="name">De Fluitende fietser</h1>
            <div class="zoekbalk">
                <img id="zoek" src="images/zoek.png">
                <input type="text">
            </div>
        </div>
        <nav>
            <ul>
                <li><a href="home.html">Home</a></li>
                <li><a href="fietss.html">Fietspagina</a></li>
                <li><a href="fietverhuur.php">Fietsverhuur</a></li>
                <li><a href="contact.html">Contact</a></li>
                <li><a href="opening.html">Openingtijden</a></li>
                <li><a href="overons.html">Over ons</a></li>
            </ul>
        </nav>
        <div class="idx"> <form>
                <?php
                if(!isset($_POST['lang'])){
                    echo"je hebt geen fiets gekozen! </br>";
                    echo"<input type='button' onclick='goback()' value='Ga terug naar huur pagina'><br>";
                    echo"<img src='images/whoops.jpg' id='whoops'>";
                }
                else{
                echo"
                    <div class='invoer'>
                        <div class='formulier'>
                    <h3>naam</h3>
                    <textarea class='txtinput' id='naam' type='text' ></textarea> <h3>e-mail</h3>
                    <textarea class='txtinput' id='mail' pattern='[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$' type='text' ></textarea>
                    <h3>adres</h3>
                    <textarea class='txtinput' id='adres' type='text' ></textarea>
                    <h3>stad</h3>
                    <textarea class='txtinput' id='stad' type='text' ></textarea>
                    <h3>postcode</h3>
                    <textarea class='txtinput' id='postcode' pattern='[1-9][0-9]{3}\s?[a-zA-Z]{2}' type='text' ></textarea>
                    <input type='submit' id='download-btn' value='Gegevens verzenden'></div>
                    <div class='fietsen'>";
                }
                    if(!empty($_POST['lang'])) {    
                        foreach($_POST['lang'] as $value){
                            echo $value.'<br/>';
                        }
                    }

                    echo "</div></div>";
                    
                ?>

                </form></div>

        <script src="./FileSaver.min.js"></script><!--save as library-->
        <script>
            //maak tekst bestand aan
            document.getElementById("download-btn").addEventListener("click", function () {
                if(document.getElementById("mail").value == '' || document.getElementById("adres").value == '' || document.getElementById("stad").value == '' || document.getElementById("postcode").value == '' || document.getElementById("naam").value == ''){
                    alert("je hebt niet alles ingevoerd");
                    return;
                }
                alert("Gegevens verstuurd!");
                var txt = "Naam = " + document.getElementById("naam").value +  "\nE-mail = "+ document.getElementById("mail").value +  "\nAdres = " + document.getElementById("adres").value +  "\nStad = " + document.getElementById("stad").value +  "\nPostcode = " + document.getElementById("postcode").value;
                var filename = "Uw-Bestelling.txt"

                var blob = new Blob([txt], {
                    type: "text/plain;charset=utf-8"
                });
                saveAs(blob, filename);
            }, false);
        </script>
        <footer>
            <div class="socials">
                <h2 class="txtcenter" id="white">Social media</h2>
                <a href="https://www.facebook.com/fietsmagazine"><img id="fcbook" src="images/fcbook.png"></a>
                <p class="txtcenter"><a class="white id="fcb" href="#facebook">Facebook</a></p>
            </div>
            <div class="contact">
                <h2 class="txtcenter" id="white">Contact</h2>
                <h3 class="txtcenter" id="white">info@defluitendefietser.nl</h3>
            </div>
            <div class="alg">
                <h3 class="txtcenter" id="white">&#169; 2021 Fluitende fietser</h3>
                <a href="https://www.bovag.nl/BovagWebsite/media/BovagMediaFiles/Downloads/Garantie%20en%20voorwaarden/Algemene-voorwaarden-BOVAG-tweewielerbedrijven-april-2018.pdf "><p class="txtcenter" id="white"><u>Algemene voorwaarde</u></p></a>
                <p class="txtcenter" id="white" >KVK: 88599665 | BTW NL999888492Z09</p>
            </div>
        </footer>
    </div>
</body>

</html>